using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Models.SerializedModels
{
    [Serializable]
    public class SerializedAgenda
    {
        public SerializedContact[] contacts;
    }
}
