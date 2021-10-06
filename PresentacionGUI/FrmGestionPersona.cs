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
            MapearPersona();
            Persona persona = MapearPersona();
            PersonaService personaService = new();
            string mensaje = personaService.Guarda(persona);
            MessageBox.Show(mensaje);
        }

        private Persona MapearPersona()
        {
            Persona persona = new();
            persona.Identificacion = TxtIdentificacion.Text;
            persona.Nombre = TxtNombre.Text;
            persona.Edad = int.Parse(TxtEdad.Text);
            persona.Sexo = CmbSexo.Text;
            persona.CalcularPulsacion();
            TxtPulsacion.Text = persona.Pulsacion.ToString();
            
            return persona;
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            MapearPersona();
            BtnGuardar.Enabled = true;
        }

        private void TxtPulsacion_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEspacios();

        }

        private void LimpiarEspacios()
        {
            TxtIdentificacion.Text = "";
            TxtNombre.Text = "";
            TxtEdad.Text = "";
            TxtPulsacion.Text = "";
            CmbSexo.Text = "";
            BtnGuardar.Enabled = false;
        }
    }
}
