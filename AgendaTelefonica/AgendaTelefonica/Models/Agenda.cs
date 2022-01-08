using AgendaTelefonica.Models.SerializedModels;
using System.Collections.Generic;
using System.Linq;
using AgendaTelefonica.Contracts;

namespace AgendaTelefonica.Models
{
    public class Agenda : ISerializeble<SerializedAgenda>
    {
        private List<Contact> _contacts;

        public Agenda()
        {
            _contacts = new List<Contact>();
        }

        public void AddContact(string name, string phone, string adress, string relation)
        {
            Contact contact = _contacts.FirstOrDefault(x => x.CheckName(name));

            if(contact == null)
            {
                Contact newContact = new Contact(name, phone, adress, relation);
                _contacts.Add(newContact);
            }
            else
            {
                contact.UpdateData(phone, adress, relation);
            }
        }

        public void RemoveContact(string name)
        {
            Contact contact = _contacts.FirstOrDefault(x => x.CheckName(name));

            if(contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public Contact SearchContact(string name)
        {
            Contact contact = _contacts.Find(x => x.CheckName(name));

            if (contact != null)
                return contact;

            List<Contact> contactsList = _contacts.Where(x => x.CheckNameLike(name)).ToList();

            if(contactsList != null)
            {
                contactsList.OrderBy(x => x.CheckNameSize());
                return contactsList[0];
            }

            return null;
        }

        public new string ToString()
        {
            string agendaInfo = "Agenda:\n\n";

            foreach(Contact contact in _contacts)
            {
                agendaInfo += contact.ToString() + "\n\n";
            }

            return agendaInfo;
        }

        public SerializedAgenda GetSerializedObject()
        {
            SerializedAgenda serializedAgenda = new SerializedAgenda
            {
                contacts = GetSerializedContacts()
            };

            return serializedAgenda;

            // Local method
            SerializedContact[] GetSerializedContacts()
            {
                SerializedContact[] contacts = new SerializedContact[_contacts.Count];

                for(int i = 0; i < contacts.Length; i++)
                {
                    contacts[i] = _contacts[i].GetSerializedObject();
                }

                return contacts;
            }
        }

        public void DeserializeObject(SerializedAgenda agenda)
        {
            _contacts = new List<Contact>();

            foreach (SerializedContact serializedContact in agenda.contacts)
            {
                Contact contact = new Contact();
                contact.DeserializeObject(serializedContact);

                _contacts.Add(contact);
            }
        }
    }
}
