using System;
using System.Net;

namespace Client
{
    class ServiceInfo
    {
        //The ifIndex for use
        public uint InterfaceIndex;

        //The service instance name
        public String InstanceName;

        //The service type
        public String Type;

        //The service domain (for ex. local.)
        public String Domain;

        //The service IPAddress
        public IPAddress Address;

        //The service port number
        public int Port;

        public override String
        ToString()
        {
            return InstanceName;
        }

        public override bool
        Equals(object other)
        {
            bool result = false;

            if (other != null)
            {
                if ((object)this == other)
                {
                    result = true;
                }
                else if (other is ServiceInfo)
                {
                    ServiceInfo otherPeerData = (ServiceInfo)other;

                    result = (this.InstanceName == otherPeerData.InstanceName);
                }
            }

            return result;
        }


        public override int
        GetHashCode()
        {
            return InstanceName.GetHashCode();
        }
    }
}
