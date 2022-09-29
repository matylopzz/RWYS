using System;
using System.Collections.Generic;
using System.Text;

namespace FluentValidationV3.Entities
{
    public class AltaTarjeta
    {
        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public String Email { get; set; }

        public String tipoTarjeta { get; set; }

        public String Tarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public DateTime FechaNacimiento { get; set; }


    }
}
