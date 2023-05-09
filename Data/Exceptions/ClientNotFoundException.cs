using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Exceptions
{
    [Serializable]
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(int id)
            :base($"Client not found! Id: {id}.")
        {

        }

        protected ClientNotFoundException(
            SerializationInfo serializationInfo,
            StreamingContext streamingContext) :base(serializationInfo, streamingContext)
        {
        }
    }
}
