using DatosLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_CRUD
{
    public partial class Mantenimiento : Form
    {
        // Repositorio para gestionar operaciones con personas.
        PersonaRepository persona = new PersonaRepository();
        int id_ = 0; // Almacena el ID de la persona a modificar (si se proporciona).

        // Constructor de la clase Mantenimiento.
        // Configura el formulario dependiendo si es para crear o modificar un registro.
        public Mantenimiento(int id = 0)
        {
            InitializeComponent();
            id_ = id; // Asigna el ID proporcionado al campo de la clase.

            if (id_ > 0)
            {
                // Configuración para modo de edición (modificar un registro existente).
                this.Text = "Modificar Personal"; // Cambia el título del formulario.
                addPerson.Text = "Edición de Personal"; // Cambia el texto del botón de añadir.
                btnEnviarDatos.Hide(); // Oculta el botón para enviar nuevos datos.
                CargarDatos(); // Carga los datos del registro a modificar en los controles del formulario.
            }
            else
            {
                // Configuración para modo de creación (añadir un nuevo registro).
                btnModificar.Hide(); // Oculta el botón para modificar datos, ya que no es necesario en este caso.
            }
        }

        // Recoge los datos del formulario y crea un nuevo objeto Person.
        private Person ObtenerNuevoCliente()
        {
            return new Person
            {
                CompanyName = text1.Text, // Nombre de la compañía.
                ContactName = text2.Text, // Nombre del contacto.
                ContactTitle = text3.Text, // Título del contacto.
                City = text4.Text, // Ciudad.
                PostalCode = text5.Text, // Código postal.
                Country = text6.Text, // País.
                Phone = textBox7.Text // Teléfono.
            };
        }

        // Verifica si alguno de los campos del objeto es nulo o está vacío.
        public Boolean validarCampoNull(Object objeto)
        {
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null);
                if (value == "")
                {
                    return true; // Retorna verdadero si algún campo está vacío.
                }
            }
            return false; // Retorna falso si todos los campos están completos.
        }

        // Evento para el botón de modificar.
        // Actualiza el registro existente con los datos del formulario.
        private void btnModificar_Click(object sender, EventArgs e)
        {
            var update = ObtenerNuevoCliente(); // Obtiene los datos del formulario como un nuevo objeto Person.
            int resultado = persona.ActualizarPersonal(update, id_); // Intenta actualizar el registro en la base de datos.

            if (validarCampoNull(update) == false)
            {
                if (resultado > 0){
                // Muestra un mensaje de éxito y cierra el formulario si la actualización fue exitosa.
                MessageBox.Show("Se ha actualizado de forma EXITOSA", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                }
            }

            else
            {
                // Muestra un mensaje de error si la actualización falla.
                MessageBox.Show("ERROR - Campos Vacios", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para el botón de enviar datos.
        // Añade un nuevo registro con los datos del formulario.
        private void btnEnviarDatos_Click(object sender, EventArgs e)
        {
            var resultado = 0;

            var nuevoCliente = ObtenerNuevoCliente(); // Obtiene los datos del formulario como un nuevo objeto Person.

            if (validarCampoNull(nuevoCliente) == false)
            {
                // Si todos los campos están completos, intenta añadir el nuevo registro.
                resultado = persona.añadirPersonal(nuevoCliente);

                if (resultado == 1)
                {
                    // Muestra un mensaje de éxito y limpia el formulario si la adición fue exitosa.
                    MessageBox.Show("Personal Agregado con EXITO", "Añadir Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    text1.Text = "";
                    text2.Text = "";
                    text3.Text = "";
                    text4.Text = "";
                    text5.Text = "";
                    text6.Text = "";
                    textBox7.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Completa los campos vacios", "Añadir Personal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Carga los datos del registro a modificar en los campos del formulario.
        public void CargarDatos()
        {
            var perso = persona.ObtenerPorId(id_); // Obtiene los datos del registro con el ID proporcionado.

            text1.Text = perso.CompanyName; // Asigna los datos a los controles del formulario.
            text2.Text = perso.ContactName;
            text3.Text = perso.ContactTitle;
            text4.Text = perso.City;
            text5.Text = perso.PostalCode;
            text6.Text = perso.Country;
            textBox7.Text = perso.Phone;
        }
    }

}
