using System;

namespace Midway.ServiceClient
{
    public class ClientAutorizedEventArgs : EventArgs
    {
        private string token;
        public ClientAutorizedEventArgs(string token)
        {
            this.token = token;
        }

        public string Token { get { return token; } }
    }
}
