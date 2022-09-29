using System;
using System.Collections.Generic;
using System.Text;
using FluentValidationV3.Entities;
using FluentValidation;


namespace FluentValidationV3.Validaciones
{
    public class Validation_AltaTarjeta_DatosPersonales : AbstractValidator<AltaTarjeta>
    {
        public Validation_AltaTarjeta_DatosPersonales() 
        {
            RuleFor(r => r.Nombre).NotEmpty(); //WithMessage -> para personalizar mensaje
            RuleFor(r => r.Apellido).NotEmpty().NotEqual(r =>r.Nombre); // inicio: .Cascade(CascadeMode.Stop)-> Sino cumple pri no sigue
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            
            RuleFor(r => r.FechaNacimiento);

        }

    }
}
