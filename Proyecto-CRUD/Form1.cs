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
    public partial class Form1 : Form
    {
        // Constructor de Form1: inicializa los componentes del formulario.
        public Form1()
        {
            InitializeComponent();
        }

        // Muestra el formulario PersonalList al hacer clic en "Ver".
        private void btnVer_Click(object sender, EventArgs e)
        {
            // Creamos una nueva instancia del formulario PersonalList.
            PersonalList link = new PersonalList();
            // Mostramos el formulario como un cuadro de diálogo modal.
            link.ShowDialog();
        }

        // Muestra el formulario Mantenimiento al hacer clic en "Añadir".
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            // Creamos una nueva instancia del formulario Mantenimiento.
            Mantenimiento persona = new Mantenimiento();
            // Mostramos este formulario también como un cuadro de diálogo modal.
            persona.ShowDialog();
        }

    }
}
