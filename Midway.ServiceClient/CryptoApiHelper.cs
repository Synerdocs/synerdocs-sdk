using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Midway.Crypto
{
    public static class CryptoApiHelper
    {
        private const int PKCS_7_ASN_ENCODING = 0x00010000;
        private const int X509_ASN_ENCODING = 0x00000001;
        private const int ENCODING = X509_ASN_ENCODING | PKCS_7_ASN_ENCODING;
        private const int CERT_STORE_PROV_SYSTEM = 10;
        private const int CERT_STORE_READONLY_FLAG = 0x00008000;
        private const int CERT_SYSTEM_STORE_CURRENT_USER = 0x00010000;
        private const int CERT_SYSTEM_STORE_LOCAL_MACHINE = 0x00020000;


        [DllImport("Crypt32.dll", SetLastError = true)]
        private static extern IntPtr CertCreateCertificateContext(
            Int32 dwCertEncodingType,
            Byte[] pbCertEncoded,
            Int32 cbCertEncoded);

        [DllImport("Crypt32.dll", SetLastError = true)]
        private static extern bool CryptEncryptMessage(
            ref CRYPT_ENCRYPT_MESSAGE_PARA pEncryptPara,
            Int32 cRecipientCert,
            IntPtr[] rgpRecipientCert,
            IntPtr pbToBeEncrypted,
            Int32 cbToBeEncrypted,
            IntPtr pbEncryptedBlob,
            ref int pcbEncryptedBlob);

        [DllImport("Crypt32.dll", SetLastError = true)]
        private static extern bool CryptDecryptMessage(
            ref CRYPT_DECRYPT_MESSAGE_PARA pDecryptPara,
            IntPtr pbEncryptedBlob,
            Int32 cbEncryptedBlob,
            IntPtr pbDecrypted,
            ref int pcbDecrypted,
            IntPtr ppXchgCert);

        [DllImport("Crypt32.dll", SetLastError = true)]
        private static extern IntPtr CertOpenStore(
            IntPtr lpszStoreProvider,
            Int32 dwMsgAndCertEncodingType,
            IntPtr hCryptProv,
            Int32 dwFlags,
            Byte[] pvPara);

        [DllImport("Crypt32.dll", SetLastError = true)]
        private static extern Boolean CertCloseStore(
            IntPtr store,
            Int32 flags);

        [StructLayout(LayoutKind.Sequential)]
        private struct CRYPT_ENCRYPT_MESSAGE_PARA
        {
            public Int32 cbSize;
            public Int32 dwMsgEncodingType;
            public IntPtr hCryptProv;
            public CRYPT_ALGORITHM_IDENTIFIER ContentEncryptionAlgorithm;
            public IntPtr pvEncryptionAuxInfo;
            public Int32 dwFlags;
            public Int32 dwInnerContentType;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CRYPT_ALGORITHM_IDENTIFIER
        {
            public string pszObjId;
            public byte[] Parameters;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CRYPT_DECRYPT_MESSAGE_PARA
        {
            public Int32 cbSize;
            public Int32 dwMsgAndCertEncodingType;
            public Int32 cCertStore;
            public IntPtr rghCertStore;
            public Int32 dwFlags;
        }


        private static IntPtr OpenStore(String name, int flags)
        {
            IntPtr storeHandle = CertOpenStore(new IntPtr(CERT_STORE_PROV_SYSTEM), 0, IntPtr.Zero, flags, Encoding.Unicode.GetBytes(name));
            if (storeHandle == IntPtr.Zero) throw new Win32Exception();
            return storeHandle;
        }

        private static void CloseStore(IntPtr storeHandle)
        {
            CertCloseStore(storeHandle, 0);
        }

        public static byte[] Decrypt(byte[] enCryptedData, bool useLocalSystemStorage = false)
        {
            var storeHandle = OpenStore("my", CERT_STORE_READONLY_FLAG | (useLocalSystemStorage ? CERT_SYSTEM_STORE_LOCAL_MACHINE : CERT_SYSTEM_STORE_CURRENT_USER));
            var pinnedStoreHandle = GCHandle.Alloc(storeHandle, GCHandleType.Pinned);

            var decryptParameters =
                new CRYPT_DECRYPT_MESSAGE_PARA
                    {
                        cbSize = Marshal.SizeOf(typeof (CRYPT_DECRYPT_MESSAGE_PARA)),
                        dwMsgAndCertEncodingType = ENCODING,
                        cCertStore = 1,
                        rghCertStore = pinnedStoreHandle.AddrOfPinnedObject()
                    };
            var bufferLength = (int)0;
            var inBufferHandle = GCHandle.Alloc(enCryptedData, GCHandleType.Pinned);
            try
            {
                try
                {

                    if (!CryptDecryptMessage(ref decryptParameters, inBufferHandle.AddrOfPinnedObject(),
                                             enCryptedData.Length, IntPtr.Zero, ref bufferLength, IntPtr.Zero))
                        throw new Win32Exception();
                    var buffer = new byte[bufferLength];
                    var outBufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                    try
                    {
                        if (!CryptDecryptMessage(ref decryptParameters, inBufferHandle.AddrOfPinnedObject(),
                                                 enCryptedData.Length, outBufferHandle.AddrOfPinnedObject(),
                                                 ref bufferLength,
                                                 IntPtr.Zero))
                            throw new Win32Exception();
                        var finalBuffer = new byte[bufferLength];
                        Array.Copy(buffer, finalBuffer, bufferLength);
                        return finalBuffer;
                    }
                    finally
                    {
                        outBufferHandle.Free();
                    }
                }
                finally
                {
                    inBufferHandle.Free();
                }
            }
            finally
            {
                CloseStore(storeHandle);
            }
        }


        /// <summary>
        /// Сформировать ЭП
        /// </summary>
        /// <param name="certificate"></param>
        /// <param name="data"></param>
        /// <param name="detached"></param>
        /// <returns></returns>
        public static byte[] Sign(X509Certificate2 certificate, byte[] data, bool detached)
        {
            // то что подписываем
            var contentInfo = new ContentInfo(data);
            var signedCms = new SignedCms(contentInfo, detached);
            // сертификато для подписания

            var cmsSigner = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificate);
            signedCms.ComputeSignature(cmsSigner, true);
            // подпись
            return signedCms.Encode();
        }
    }
}
