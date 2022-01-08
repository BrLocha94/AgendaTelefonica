using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Contracts
{
    public interface ISerializeble<T>
    {
        T GetSerializedObject();
        void DeserializeObject(T serializedObject);
    }
}
