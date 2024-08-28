using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class Person
    {
        // Identificador único para el proveedor o persona
        public int SupplierID { get; set; }

        // Nombre de la empresa a la que pertenece la persona
        public string CompanyName { get; set; }

        // Nombre de contacto de la persona en la empresa
        public string ContactName { get; set; }

        // Título o cargo de contacto de la persona en la empresa
        public string ContactTitle { get; set; }

        // Dirección física de la empresa o de la persona
        public string Address { get; set; }

        // Ciudad donde se encuentra la empresa o la persona
        public string City { get; set; }

        // Región o estado donde se encuentra la empresa o la persona
        public string Region { get; set; }

        // Código postal de la dirección de la empresa o de la persona
        public string PostalCode { get; set; }

        // País donde se encuentra la empresa o la persona
        public string Country { get; set; }

        // Número de teléfono de la empresa o de la persona
        public string Phone { get; set; }

        // Número de fax de la empresa o de la persona
        public string Fax { get; set; }

        // Página web de la empresa o de la persona
        public string HomePage { get; set; }
    }

}
