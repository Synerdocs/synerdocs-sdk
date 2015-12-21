using System.ComponentModel;

namespace Midway.ObjectModel.Exceptions
{
    /// <summary>
    /// ���� ������ �������:
    /// �������� ������������ ������ ���������
    ///	������ ������� � �����
    ///	����������� ������ ����������� 
    ///	����������� ������ ����������
    ///	����������� ��������� ��������� (��� ������������ ����������, ������������ ������ �� ������ � ��.)
    /// ������������ ������ �� ���������
    ///	[��] ������������ ������ ���������� ���������
    ///	[��] ������������ ������ �����-�������
    ///	[��] ������������ ������ ������� (CMS)
    ///	[��] ������� �� �������� ���������� � ������������
    ///	[��] ����������� ������������ ����������������� �������� � �������
    ///	[��] ���������������� �������, ��� ������������� �������������� ����.
    ///	������ �������� ��������� ���������� ����. ��������� (� ���� ��������� ���� ������, �� ���� �������������)
    ///	���������� �� ����������� (�� ����������� ���������������)
    ///	���������� ������ �������
    /// 
    /// 
    /// ���� ����������� � �� ���������� � 50
    /// 
    /// </summary>
    public enum ServiceErrorCode
    {
        /// <summary>
        /// ���������� ������ �������
        /// </summary>
        [Description("���������� ������ �������")]
        UnexpectedError = 0,

        // �� ��������� ������������ ����
        [Description("�� ��������� ������������ ����")]
        NotFilledRequiredField = 1,

        /// TODO@�� ������������
        /// <summary>
        /// ��������� �� �������� ��������
        /// </summary>
        [Description("��������� �� �������� ��������")]
        MessageDoesNotContainReference = 2,

        /// <summary>
        /// ������������ ������ �������� ����
        /// </summary>
        [Description("������������ ������ �������� ����")]
        InvalidFormatField = 3,

        /// <summary>
        /// ����������� ������ ����������
        /// </summary>
        [Description("����������� ������ ����������")]
        InvalidDestinationAddress = 4,

        /// <summary>
        /// ������������ ����� ��������������
        /// </summary>
        [Description("������������ ����� ��������������")]
        Unauthorized = 5,

        /// <summary>
        /// �������� ������ �� ��������
        /// </summary>
        [Description("�������� ������ �� ��������")]
        InvalidDocumentReference = 6,

        /// <summary>
        /// ������������ ������� �������� ���������
        /// </summary>
        [Description("������������ ������� �������� ���������")]
        InvalidCardContent = 7,

        /// <summary>
        /// ������ �� �������
        /// </summary>
        [Description("������ �� �������")]
        NoDataFound = 8,

        /// <summary>
        /// ������ ������� � ������������  �����
        /// </summary>
        [Description("������ ������� � ������������ �����")]
        BoxAccessError = 10,

        #region �������� (11, 12, 41-50)

        /// TODO@�� ������������
        /// <summary>
        /// ���������� �� �����������
        /// </summary>
        [Description("���������� �� �����������")]
        ContragentIsNotAuthorized = 11,

        /// <summary>
        /// ������ ������ �� ������� �������� ������������
        /// </summary>
        [Description("������ ������ �� ������� �������� ������������")]
        ContactListError = 12,

        /// <summary>
        /// ���������� �� �����������
        /// </summary>
        [Description("���������� �� �����������")]
        ContactIsNotAuthorized = 41,

        /// <summary>
        /// ���������� ��� �����������
        /// </summary>
        [Description("���������� ��� �����������")]
        ContactIsAlreadyAuthorized = 42,

        /// <summary>
        /// ����������� � ������ � ������������ ��� ����
        /// </summary>
        [Description("����������� � ������ � ������������ ��� ����")]
        ContactAuthIsAlreadyRequested = 43,

        /// <summary>
        /// ���������� �������� �����
        /// </summary>
        [Description("���������� �������� �����")]
        ContactHasRejectedAuth = 44,

        /// <summary>
        /// ����������� � ������ � ������������ �� ����������
        /// </summary>
        [Description("����������� � ������ � ������������ �� ����������")]
        ContactAuthRequestNotFound = 45,

        /// <summary>
        /// �������� ����������� ����� ���� ���������� ������ �������� ������������
        /// </summary>
        [Description("�������� ����������� ����� ���� ���������� ������ �������� ������������")]
        OrganizationMustBeActive = 46,

        /// <summary>
        /// ����� � ������������ ������������
        /// </summary>
        [Description("����� � ������������ ������������")]
        ContactAuthIsRejected = 47,

        #endregion ��������

        /// <summary>
        /// ������ ��������
        /// </summary>
        [Description("������ ��������")]
        AccessDeniedError = 13,

        /// <summary>
        /// ����������� ���������
        /// </summary>
        [Description("����������� ���������")]
        FeatureDisabled = 14,

        #region ����������� � ������� (51-60)

        /// <summary>
        /// ������������ ������ ������� (CMS)
        /// </summary>
        [Description("������������ ������ ������� (CMS)")]
        InvalidCMS = 51,

        /// <summary>
        /// ������� �� �������� ���������� � �����������
        /// </summary>
        [Description("������� �� �������� ���������� � �����������")]
        SignDoesNotContainCertificate = 52,

        /// <summary>
        /// ������� ���������������, �������� �����������
        /// </summary>
        [Description("������� ���������������, �������� �����������")]
        SignIsNotValid = 53,

        /// <summary>
        /// ����� ��� ��� �� �������� ���� �������� �����������
        /// </summary>
        [Description("����� ��� ��� �� �������� ���� �������� �����������")]
        CertificatePeriodIsNotValid = 54,

        /// <summary>
        /// ���������� �� ������ � ���� �������
        /// </summary>
        [Description("���������� �� ������ � ���� �������")]
        CertificateIsNotTrusted = 55,

        /// <summary>
        /// ���������� �������
        /// </summary>
        [Description("���������� �������")]
        CertificateIsRevoked = 56,

        /// <summary>
        /// ������������ ������ ��������� � ���������� �����������
        /// </summary>
        [Description("������������ ������ ��������� � ���������� �����������")]
        CertificateHasNotValidAttributesAndExtensions = 58,

        /// <summary>
        /// ������������������� ������� �� �������
        /// </summary>
        [Description("������������������� ������� �� �������")]
        EnhancedSignNotFound = 59,

        #endregion ����������� � �������

        #region ������������ (61-70)

        /// <summary>
        /// ������� ��������������� ��������� ������
        /// </summary>
        [Description("������� ��������������� ��������� ������")]
        DepartmentDeleted = 61,

        /// <summary>
        /// ������������ ������� ��������������� ��������� ������
        /// </summary>
        [Description("������������ ������� ��������������� ��������� ������")]
        ParentDepartmentDeleted = 62,

        /// <summary>
        /// ������� ��������������� ��������� ����� �������� ��������
        /// </summary>
        [Description("������� ��������������� ��������� ����� �������� ��������")]
        DepartmentHasChild = 63,

        /// <summary>
        /// ������� ������� �������������� ��� ��������� ������������� � ���������
        /// </summary>
        [Description("������� ������� �������������� ��� ��������� ������������� � ���������")]
        DepartmentDoesNotExist = 64,

        /// <summary>
        /// ����������� ����������� ����� ���������� ���. ���������
        /// </summary>
        [Description("����������� ����������� ����� ���������� ������������")]
        DepartmentCyclicDependency = 65,

        /// <summary>
        /// ������������ ������������� ������� �������
        /// </summary>
        [Description("������������ ������������� ������� �������")]
        IncorrectParentDepartment = 66,

        /// TODO@�� ������������
        /// <summary>
        /// ������������� �������� ��������, ������� ������
        /// </summary>
        [Description("������������� �������� ��������, ������� ������")]
        DepartmentIsHead = 67,

        #endregion ������������

        #region ����� ������������� (71-79)

        ///// <summary>
        ///// ������� ���������� � ���� ��� ������������� ����������
        ///// </summary>
        //DublicatePermission = 70,

        /// <summary>
        /// ������ ��� �������
        /// </summary>
        [Description("������ ��� �������")]
        PermissionAlreadyDeleted = 71,

        /// <summary>
        /// �������������� ������
        /// </summary>
        [Description("�������������� ������")]
        PermissionDoesNotExist = 72,

        #endregion ����� �������������

        /// <summary>
        /// ������������ ��� ����������
        /// </summary>
        [Description("������������ ��� ����������")]
        DuplicateUser = 80,

        /// <summary>
        /// ������������ ������
        /// </summary>
        [Description("������������ ������")]
        UserDeleted = 81,

        /// <summary>
        /// ���������� ���������� ��� ���� � ���� ������
        /// </summary>
        [Description("���������� ���������� ��� ���� � ���� ������")]
        DuplicateCertificate = 83,

        /// <summary>
        /// �������� � ����������� ������������ ��� ����
        /// </summary>
        [Description("�������� � ����������� ������������ ��� ����")]
        DuplicateBindToOrganization = 84,

        /// TODO@�� ������������
        /// <summary>
        /// �� ������ ����������
        /// </summary>
        [Description("�� ������ ����������")]
        CertificateNotFound = 85,

        /// <summary>
        /// �� ������� ���������� ����������
        /// </summary>
        [Description("�� ������� ���������� ����������")]
        CertificateParsingFailed = 86,

        /// <summary>
        /// ����������� � ��������������� ��� ��� ���� � ���� ������
        /// </summary>
        [Description("����������� � ��������������� ��� ��� ���� � ���� ������")]
        DuplicateOrganization = 87,

        #region ��������� (101-110)
        /// <summary>
        /// ������ ������ � ����������� ���������
        /// </summary>
        [Description("������ ������ � ����������� ���������")]
        DraftMessageError = 101,

        #endregion ���������
        
        /// <summary>
        /// ������������ ������ ���������
        /// </summary>
        [Description("������������ ������ ���������")]
        InvalidDocumentFormat = 1001,

        /// <summary>
        /// ������������ ���������� ���������
        /// </summary>
        [Description("������������ ���������� ���������")]
        InvalidDocumentContent = 1002,

        /// <summary>
        /// ������������ ��� �����
        /// </summary>
        [Description("������������ ��� �����")]
        InvalidFileName = 1003,

        /// <summary>
        /// �� ������� ��������� ����� � �������� ����������������
        /// </summary>
        [Description("�� ������� ��������� ����� � �������� ����������������")]
        DownloadDocumentFlowArchiveFailed = 1004,

        /// <summary>
        /// ������ � �������� ��������� ��������
        /// </summary>
        [Description("������ � �������� ��������� ��������")]
        DocumentContentAccessDenied = 1005,

        /// <summary>
        /// ������������ ��� ���������
        /// </summary>
        [Description("������������ ��� ���������")]
        InvalidDocumentType = 1006,

        /// <summary>
        /// ����� ����������� ��������
        /// </summary>
        [Description("����� ����������� ��������")]
        DocumentExchangeIsDenied = 1007,
        
        /// <summary>
        /// ��������� ���������� ����������������
        /// </summary>
        [Description("��������� ���������� ����������������")]
        WorkflowViolation = 2001,

        /// <summary>
        /// ���������� ������� ���������
        /// </summary>
        [Description("���������� ������� ���������")]
        RelationNotAllowed = 3001,

        /// TODO@�� ������������
        /// <summary>
        /// ��������� ��� ������� ��������� ��� ����������� �������� (����� � ��� �� �������������)
        /// </summary>
        [Description("������� ��������� ��� ����������� �������� (����� � ��� �� �������������)")]
        SignAlreadyExists = 4001,

        /// TODO@�� ������������
        /// TODO ��������� �������� ��������
        /// <summary>
        /// ����������� ������ ����������
        /// </summary>
        [Description("����������� ������ ����������")]
        InvalidSourceAddress,

        /// TODO ��������� �������� ��������
        /// <summary>
        /// ����������� ������ � ������ ����������
        /// </summary>
        [Description("����������� ������ � ������ ����������")]
        CyclicParentReferences,

        /// TODO ��������� �������� ��������
        /// <summary>
        /// �� ������ ��������, ��������������� ��������� ������
        /// </summary>
        [Description("�� ������ ��������, ��������������� ��������� ������")]
        DocumentNotFound,

        /// <summary>
        /// ������ ����������� ������������
        /// </summary>
        [Description("������ ����������� ������������")]
        AuthorizeContragentError = 5001,

        #region ��������������� (6000-6009)

        /// <summary>
        /// ����������� ������ ����������������
        /// </summary>
        [Description("����������� ������ ����������������")]
        UnknowDocumentFlowError = 6000,

        /// <summary>
        /// �������� �� ��������
        /// </summary>
        [Description("�������� �� ��������")]
        OperationIsNotAvailable = 6001,

        /// <summary>
        /// �������� ������ ���� ���������
        /// </summary>
        [Description("�������� ������ ���� ���������")]
        SendToSelfIsNotAllowed = 6002,

        /// <summary>
        /// �������� �� ������� ����������� ���������
        /// </summary>
        [Description("�������� �� ������� ����������� ���������")]
        SendFromOtherIsNotAllowed = 6003,

        /// <summary>
        /// ��������� ��������� �� ��������
        /// </summary>
        [Description("��������� ��������� �� ��������")]
        ForwardIsNotAvailable = 6004,

        /// <summary>
        /// �������� �� ������� ����������
        /// </summary>
        [Description("�������� �� ������� ����������")]
        DocumentDoesNotRequireSigning = 6005,

        /// <summary>
        /// �������� ��� ��� ��������
        /// </summary>
        [Description("�������� ��� ��� ��������")]
        DocumentWasAlreadySigned = 6006,

        /// <summary>
        /// ��� ���� �������� � ���������� ���������
        /// </summary>
        [Description("��� ���� �������� � ���������� ���������")]
        SignWasAlreadyRejected = 6007,

        /// <summary>
        /// �������� � ������� ���������
        /// </summary>
        [Description("�������� � ������� ���������")]
        SendToRoamingIsNotAllowed = 6008,

        /// <summary>
        /// ������������ ������������ ����������
        /// </summary>
        [Description("������������ ������������ ����������")]
        InvalidRecipientUser = 6009,

        #endregion
    }
}
