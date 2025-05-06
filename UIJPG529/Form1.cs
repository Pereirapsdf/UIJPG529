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
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Por favor, ingrese un texto.");
                }
                else
                {
                    User.NombreUsuario = textBox1.Text;
                    User.Contraseña = textBox2.Text;
                    User.Dni = Convert.ToInt16(textBox3.Text);
                    Mozo.Ingre(User.NombreUsuario, User.Contraseña, User.Dni);
                    vaciar();
                    if(Mozo.a == 1)
                    {
                        OnLoginSuccessful(username: User.NombreUsuario);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void OnLoginSuccessful(string username)
        {
            this.Hide();
            Form2 formulario2 = new Form2();
            formulario2.TextoRecibido = username;
            formulario2.Show();

        }

        public void vaciar()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {

           

            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {           
                    MessageBox.Show("Por favor, ingrese un texto.");
                }
                else 
                {
                    User.Intento=0;
                    User.NombreUsuario = textBox1.Text;
                    User.Contraseña = textBox2.Text;
                    User.Dni = Convert.ToInt16( textBox3.Text);
                    Mozo.Add(User.Contraseña, User.NombreUsuario, User.Dni);
                    vaciar();
                }
             
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
