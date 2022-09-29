using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidationV3.Entities;
using FluentValidationV3.Validaciones;


namespace FluentValidationV3.Validaciones
{
    public class Validation_AltaTarjeta_DatosPago : AbstractValidator<AltaTarjeta>
    {

        public Validation_AltaTarjeta_DatosPago()
        {
            RuleFor(r => r.tipoTarjeta).NotEmpty().Must(ValidarTipoTarjeta);
            RuleFor(r => r.Tarjeta).NotEmpty().When(ValidaIngresoTarjeta).CreditCard();
            RuleFor(r => r.FechaVencimiento).GreaterThan(DateTime.Now.AddMonths(3)); //fecha vencimiento mayor a tres meses
            RuleFor(r => r.FechaVencimiento).Must(ValidaEdad);


        }

        //funcion para el must -> ingrese funcion (string , bool) ingreso string devuelvo bool.
        private bool ValidarTipoTarjeta(string tipo) 
        {
            if (tipo == "VIS" || tipo == "MAS") return true;
            
            return false;
            
        }

        private bool ValidaIngresoTarjeta(AltaTarjeta alta) 
        {
            if (alta.tipoTarjeta != null & alta.tipoTarjeta != "") return true;
            return false;

        }
        private bool ValidaEdad(DateTime nacimiento) 
        {
            int edad = DateTime.Now.Year - nacimiento.Year;
            if(DateTime.Now.Month > nacimiento.Month)--edad;

            if (edad >= 18 && edad <= 70) return true;
            return false;
        }
    }
}
