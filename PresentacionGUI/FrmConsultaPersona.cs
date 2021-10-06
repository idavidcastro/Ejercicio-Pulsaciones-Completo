using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionGUI
{
    public partial class FrmConsultaPersona : Form
    {
        public FrmConsultaPersona()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonaService personaService = new();
            var respuesta = personaService.Consultar();
            if (respuesta.Error)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {

            }
        }
    }
}
