using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;//libreria para reproducir los sonidos

namespace SalarioConBono
{
    public partial class E4 : Form
    {
        //Creación del método para reproducir sonidos
        void Reproducir(string ruta)
        {
            Audio miAudio = new Audio();
            miAudio.Play(ruta);
        }
        public E4()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //Acciones del botón calcular, dependiendo las horas ingresadas.
            if (tbxHoras.Text != "" && tbxSalario.Text != "")
            {
                //Horas excedentes en una semana
                if (Convert.ToDouble(tbxHoras.Text) > 168) 
                {
                    lblMensaje.Text = "Demasiadas horas para una semana, ¿no?";
                    Reproducir(Application.StartupPath + @"\sonidos\resorte.wav");
                    lblMensaje.Show();
                    tbxHoras.Clear();
                    tbxSalario.Clear();
                    tbxHoras.Focus();
                }
                //Horas de tiempo completo y horas extras
                else if (Convert.ToDouble(tbxHoras.Text) >= 48 && Convert.ToDouble(tbxHoras.Text) <= 168)
                {
                    lblMensaje.Text = "¡Qué trabajador!";
                    lblMensaje.Show();
                    Reproducir(Application.StartupPath + @"\sonidos\aplausos.wav");
                    tbxResultado.Text = (Convert.ToDouble(tbxHoras.Text) * Convert.ToDouble(tbxSalario.Text) + 500).ToString();
                    tbxResultado.Focus();
                }
                //Horas normalmente
                else if (Convert.ToDouble(tbxHoras.Text) > 0 && Convert.ToDouble(tbxHoras.Text) < 48)
                {
                    lblMensaje.Text = "¡Felicidades!";
                    lblMensaje.Show();
                    tbxResultado.Text = (Convert.ToDouble(tbxHoras.Text) * Convert.ToDouble(tbxSalario.Text) + 500).ToString();
                    tbxResultado.Focus();
                }
                //Cuando el usuario ingresa horas negativas o 0.
                else if (Convert.ToDouble(tbxHoras.Text) <= 0)
                {
                    lblMensaje.Text = "¿Qué pasó crack, debes horas extras?";
                    lblMensaje.Show();
                    Reproducir(Application.StartupPath + @"\sonidos\resorte.wav");
                    tbxResultado.Text = (Convert.ToDouble(tbxHoras.Text) * Convert.ToDouble(tbxSalario.Text) + 500).ToString();
                    tbxResultado.Focus();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Limpiar datos
        private void btnLimp_Click(object sender, EventArgs e)
        {
            lblMensaje.Hide();
            tbxHoras.Clear();
            tbxSalario.Clear();
            tbxResultado.Clear();
            tbxHoras.Focus();
        }
        //Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
