using System;

namespace Sicom.Servicio.Exceptions
{
    public class ServiceException : System.Exception
    {
        public ServiceException(string message) : base(message)
        {

        }

        public ServiceException(string message, System.Exception e) : base(message, e)
        {

        }

    }
}
