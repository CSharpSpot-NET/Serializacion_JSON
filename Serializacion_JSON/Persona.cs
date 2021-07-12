using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializacion_JSON
{
    public class Persona
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string genero { get; set; }
        public int edad { get; set; }
        public DateTime nacimiento { get; set; }
    }
}
