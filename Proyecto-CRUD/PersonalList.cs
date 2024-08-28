using DatosLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_CRUD
{
    public partial class PersonalList : Form
    {
        // Repositorio para gestionar operaciones con personas.
        PersonaRepository personarepo = new PersonaRepository();

        // Constructor de PersonalList.
        // Inicializa los componentes y carga los datos iniciales.
        public PersonalList()
        {
            InitializeComponent();
            CargarDatos(); // Carga los datos cuando se inicializa el formulario.
        }

        // Carga todos los datos de personas en el DataGridView.
        private void CargarDatos()
        {
            // Obtiene todos los registros de personas desde el repositorio.
            var ObtenerTodo = personarepo.ObtenerDatos();
            // Asigna los datos al DataGridView para que se muestren en la interfaz.
            TablaPersonal.DataSource = ObtenerTodo;
        }

        // Evento para el botón de recargar.
        // Vuelve a cargar los datos cuando se hace clic en el botón.
        private void tbRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos(); // Recarga los datos en el DataGridView.
        }

        // Evento para el cambio de texto en el filtro de búsqueda.
        // Filtra los datos mostrados en el DataGridView según el texto ingresado.
        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            // Obtiene todos los registros de personas.
            var ObtenerTodo = personarepo.ObtenerDatos();
            // Filtra los registros que empiezan con el texto ingresado en el filtro.
            var filtro = ObtenerTodo.FindAll(f => f.CompanyName.StartsWith(tbFiltro.Text));
            // Asigna los datos filtrados al DataGridView.
            TablaPersonal.DataSource = filtro;
        }

        // Evento para el clic en una celda del DataGridView.
        // Permite realizar acciones como editar o eliminar registros.
        private void TablaPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic sea en una celda válida.
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtiene el ID del registro seleccionado.
                int id = int.Parse(TablaPersonal.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString());

                // Verifica si la columna clickeada es la de "Update".
                if (TablaPersonal.Columns[e.ColumnIndex].Name.Equals("Update"))
                {
                    // Muestra el formulario de mantenimiento para modificar el registro seleccionado.
                    Mantenimiento mante = new Mantenimiento(id);
                    mante.ShowDialog();
                    // Recarga los datos tras cerrar el formulario de mantenimiento.
                    CargarDatos();
                }
                // Verifica si la columna clickeada es la de "Delete".
                else if (TablaPersonal.Columns[e.ColumnIndex].Name.Equals("Delete"))
                {
                    // Muestra un cuadro de diálogo para confirmar la eliminación.
                    var resultado = MessageBox.Show("¿Deseas Eliminar el personal?", "Eliminar Personal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {

                        int eliminadas = personarepo.EleminarPersonal(id);

                        if (eliminadas > 0)
                        {
                            // Muestra un mensaje de éxito y recarga los datos.
                            MessageBox.Show("Personal Eliminado con Éxito", "Eliminar Personal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();
                        }
                        else
                        {
                            // Muestra un mensaje de error si no se pudo eliminar el registro.
                            MessageBox.Show("El personal no fue eliminado", "Eliminar Personal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }

}
