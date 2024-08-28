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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            PersonalList link = new PersonalList();
            link.ShowDialog();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            Mantenimiento persona = new Mantenimiento();
            persona.ShowDialog();
        }
    }
}
