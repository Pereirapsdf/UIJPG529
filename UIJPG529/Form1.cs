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

        DominioJPG529.Users529 User = new DominioJPG529.Users529();
        DallJPG529.Mozo529 Mozo = new DallJPG529.Mozo529();
        DominioJPG529.Admin529 Admin = new DominioJPG529.Admin529();
        DallJPG529.Admi_user529 Admi = new DallJPG529.Admi_user529();

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            label4.Visible = false;
            textBox4.Visible = false;
            //ddsfsdfdsfsdf
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
                    if (checkBox1.Checked == true)
                    {
                        Admin.NombreUsuario = textBox1.Text;
                        Admin.Contraseña = textBox2.Text;
                        Admin.Dni = Convert.ToInt16(textBox3.Text);
                        Admi.Ingre(Admin.NombreUsuario, Admin.Contraseña, Admin.Dni);

                        if(Admi.a == 1)
                        {
                            OnLoginSuccessful(username: Admin.NombreUsuario);
                        }
                    }
                    else
                    {


                        User.NombreUsuario = textBox1.Text;
                        User.Contraseña = textBox2.Text;
                        User.Dni = Convert.ToInt16(textBox3.Text);
                        Mozo.Ingre(User.NombreUsuario, User.Contraseña, User.Dni);
                        vaciar();
                        if (Mozo.a == 1)
                        {
                            OnLoginSuccessful(username: User.NombreUsuario);

                        }
                        if (Mozo.b == 2)
                        {
                            MessageBox.Show("Puede cambiar la contraseña si no la recuerda.");
                            button3.Visible = true;
                            label4.Visible = true;
                            textBox4.Visible = true;
                        }
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
            if (checkBox1.Checked==true)
            {
                formulario2.Adm = true;
            }
            else
            {
                formulario2.Adm = false;
            }
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


        private void button3_Click(object sender, EventArgs e)
        {
            


            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Por favor, ingrese un texto.");
                }
                else
                {
                    User.NombreUsuario = textBox1.Text;
                    User.Contraseña = textBox2.Text;
                    User.Dni = Convert.ToInt16(textBox3.Text);
                    Mozo.Update(User.NombreUsuario, User.Dni, User.Contraseña,textBox4.Text);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
            if(checkBox1.Checked)
            {
                button1.Visible = false;
            }
            else
            {
                button1.Visible = true;
            }
        }
    }
}
