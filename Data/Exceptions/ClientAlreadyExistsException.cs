using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    [Serializable]
    public class ClientAlreadyExistsException : Exception
    {
        public ClientAlreadyExistsException() :
           base("Client already exists.")
        {

        }
        protected ClientAlreadyExistsException(
            SerializationInfo serializationInfo,
            StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

    }
}
