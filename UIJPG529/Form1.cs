using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DallJPG529;
using DominioJPG529;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace UIJPG529
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DominioJPG529.Users User = new DominioJPG529.Users();
        DallJPG529.Mozo529 Mozo = new DallJPG529.Mozo529();
        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            textBox3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            textBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            label3.Visible = true;
            textBox3.Visible = true;

            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {           
                    MessageBox.Show("Por favor, ingrese un texto.");
                }
                else 
                {
                    User.NombreUsuario = textBox1.Text;
                    User.Contraseña = textBox2.Text;
                    User.Dni = textBox3.Text;
                    Mozo.Add(User.Contraseña, User.NombreUsuario, User.Dni);
                }
             
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
