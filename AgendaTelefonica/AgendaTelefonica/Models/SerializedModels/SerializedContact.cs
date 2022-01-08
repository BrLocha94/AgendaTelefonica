using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Models.SerializedModels
{
    [Serializable]
    public class SerializedContact
    {
        public string name;
        public string phone;
        public string adress;
        public string relation;
    }
}
