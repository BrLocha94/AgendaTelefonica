using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AgendaTelefonica.Contracts;
using System.IO;

namespace AgendaTelefonica.Utils
{
    public static class JsonHandler
    {
        public static void WriteSerializedInfo<T>(string filePath, ISerializeble<T> serializeble)
        {
            T serializedObject = serializeble.GetSerializedObject();

            File.WriteAllText(filePath, JsonConvert.SerializeObject(serializedObject));
        }

        public static T ReadSerializedInfo<T>(string filepath)
        {
            //TODO: ADD TRY/CATCH 
            T serializedObject = JsonConvert.DeserializeObject<T>(File.ReadAllText(filepath));

            return serializedObject;
        }

        public static void UpdateSerializedObject<T>(string filepath, ISerializeble<T> serializeble)
        {
            T serializedObject = ReadSerializedInfo<T>(filepath);

            serializeble.DeserializeObject(serializedObject);
        }
    }
}
