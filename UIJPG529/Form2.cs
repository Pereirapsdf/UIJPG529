using DallJPG529;
using DominioJPG529;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIJPG529
{
    public partial class Form2 : Form
    {
        DominioJPG529.Users529 User = new DominioJPG529.Users529();
        DallJPG529.Mozo529 Mozo = new DallJPG529.Mozo529();
        DallJPG529.Admi_user529 Admi_user529 = new DallJPG529.Admi_user529();
        public Form2()
        {
            InitializeComponent();
        }

        public string TextoRecibido { get; set; }
        public bool Adm { get; set; }
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = TextoRecibido;
            try
            {


                if (Adm == true)
                {
                   
                }
                else
                {
                    dataGridView1.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    button4.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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
                    Mozo.Update(User.NombreUsuario, User.Dni, User.Contraseña, textBox4.Text);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Admi_user529.ObtenerClientes(textBox5.Text, Convert.ToInt16(textBox6.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admi_user529.Cambio(textBox5.Text, Convert.ToInt16(textBox6.Text));
            dataGridView1.DataSource = Admi_user529.ObtenerClientes(textBox5.Text, Convert.ToInt16(textBox6.Text));
        }
    }
 }

