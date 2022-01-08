using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaTelefonica.Models.SerializedModels;
using AgendaTelefonica.Utils;
using AgendaTelefonica.Contracts;

namespace AgendaTelefonica.Models
{
    public class Contact : ISerializeble<SerializedContact>
    {
        private string _name;
        private string _phone;
        private string _adress;
        private string _relation;

        public Contact()
        {

        }

        public Contact(string name, string phone, string adress, string relation)
        {
            _name = name;
            _phone = phone;
            _adress = adress;
            _relation = relation;
        }

        public void UpdateData(string phone, string adress, string relation)
        {
            _phone = phone;
            _adress = adress;
            _relation = relation;
        }

        public bool CheckName(string name)
        {
            return _name.ToUpper().Equals(name.ToUpper());
        }

        public bool CheckNameLike(string name)
        {
            return _name.ContainsCaseInsensitive(name);
        }

        public int CheckNameSize() => _name.Length;

        public new string ToString()
        {
            string contactInfo = string.Empty;

            contactInfo += "Nome: " + _name  + "\n";
            contactInfo += "Telefone: " + _phone + "\n";
            contactInfo += "Endereço: " + _adress + "\n";
            contactInfo += "Relação: " + _relation;

            return contactInfo;
        }

        public SerializedContact GetSerializedObject()
        {
            SerializedContact serializedContact = new SerializedContact
            {
                name = _name,
                phone = _phone,
                adress = _adress,
                relation = _relation
            };

            return serializedContact;
        }

        public void DeserializeObject(SerializedContact contato)
        {
            _name = contato.name;
            _phone = contato.phone;
            _adress = contato.adress;
            _relation = contato.relation;
        }
    }
}
