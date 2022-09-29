 using System;
using FluentValidationV3.Entities;
using FluentValidationV3.Validaciones;


namespace FluentValidationV3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //declaro clase para ser validada
            AltaTarjeta A = new AltaTarjeta();

            A.Nombre = "Berlito";
            A.Apellido = "Lopez";
            A.Email = " matiasfull2230@gmail.com";
            A.tipoTarjeta = "VIS";
            A.Tarjeta = "0000-0000-0000-0000";
            A.FechaNacimiento = new DateTime(2020, 01, 01);
            A.FechaNacimiento = new DateTime(2010, 03, 01); 





            //  VALIDADOR DE DATOS PERSONALES
            //Contenedor de las Validacions de datos personales
            var validator_datos_personales = new Validation_AltaTarjeta_DatosPersonales();
            //aca lo ejecuta para ver si don validos los datos
            var resultados_datos_personales = validator_datos_personales.Validate(A);

            //Ciclo para ver si el mostrar los errores con un mensaje dentro

            foreach (var error in resultados_datos_personales.Errors) 
            {
                Console.WriteLine(error.PropertyName + ":" + error.ErrorMessage);
            }

            //VALIDADOR DE DATOS DE PAGOS
            var Validador_datos_pagos = new  Validation_AltaTarjeta_DatosPago();
            var resultados_datos_pagos = Validador_datos_pagos.Validate(A);

            foreach (var erroresPago in resultados_datos_pagos.Errors) 
            {
                Console.WriteLine(erroresPago.PropertyName + ":" + erroresPago.ErrorMessage); 
            }

        }
    }
}
