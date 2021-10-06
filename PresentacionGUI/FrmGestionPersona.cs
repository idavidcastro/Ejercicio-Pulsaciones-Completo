using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Logica;

namespace PresentacionGUI
{
    public partial class FrmGestionPersona : Form
    {
        public FrmGestionPersona()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Persona persona = new();
            persona.Identificacion = TxtIdentificacion.Text;
            persona.Nombre = TxtNombre.Text;
            persona.Edad = int.Parse(TxtEdad.Text);
            persona.Sexo = CmbSexo.Text;
            persona.CalcularPulsacion();
            PersonaService personaService = new();
            string mensaje = personaService.Guarda(persona);
            MessageBox.Show(mensaje);
        }
    }
}
