using DallJPG529.Contratos529;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;

namespace DallJPG529
{
    public class Admi_user529
    {
        private readonly string conectionString;
        public Admi_user529() 
        {
            conectionString = ConfigurationManager.ConnectionStrings["ServN"].ConnectionString;
        }
        public DataTable ObtenerClientes(string nombre, int Dni)
        {
            string query = "SELECT Usuario, Intento FROM Users WHERE Usuario = @Usuario AND Dni = @Dni";
            using (SqlConnection conn = new SqlConnection(conectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Usuario", nombre);
                cmd.Parameters.AddWithValue("@DNI", Dni);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                return tabla;
            }
        }

        public void Cambio(string nombre, int Dni) 
        {

            using (SqlConnection conn = new SqlConnection(conectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET Intento = 0 WHERE Usuario = @Usuario AND Dni = @Dni";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", nombre);
                    cmd.Parameters.AddWithValue("@DNI", Dni);
                    cmd.ExecuteNonQuery();
                }

            }

        }


        public int a = 0;
        public void Ingre(string username, string password, int dni)
        {
            string hashedPassword = HashhJPG.HashPassword(password);

            using (SqlConnection conn = new SqlConnection(conectionString))
            {
                conn.Open();

                string checkQuery = "SELECT Contraseña FROM Amin WHERE Usuario = @Usuario AND DNI = @DNI";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Usuario", username);
                    checkCmd.Parameters.AddWithValue("@Dni", dni);

                    SqlDataReader reader = checkCmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        MessageBox.Show("Usuario,contraseña o Dni incorrectos.");
                        return;
                    }

                    //string storedHashedPassword = reader.GetString(0);
                    //int intentosFallidos = reader.GetInt32(1);
                    //if (intentosFallidos == 2)
                    //{
                    //    b = intentosFallidos;
                    //}

                    //reader.Close();

                    //if (intentosFallidos >= 4)
                    //{
                    //    MessageBox.Show("Tu cuenta está bloqueada por múltiples intentos fallidos. Intenta nuevamente más tarde.");
                    //    return;
                    //}

                    //if (storedHashedPassword != hashedPassword)
                    //{
                    //    string updateFailedAttemptsQuery = "UPDATE Admin SET Intento = Intento + 1 WHERE Usuario = @Usuario AND DNI = @DNI";
                    //    using (SqlCommand updateCmd = new SqlCommand(updateFailedAttemptsQuery, conn))
                    //    {
                    //        updateCmd.Parameters.AddWithValue("@Usuario", username);
                    //        updateCmd.Parameters.AddWithValue("@DNI", dni);
                    //        updateCmd.ExecuteNonQuery();
                    //    }
                    //    MessageBox.Show("Usuario ,contraseña o Dni incorrectos..");
                    //    return;
                    //}


                    //string resetFailedAttemptsQuery = "UPDATE Users SET Intento= 0 WHERE Usuario = @Usuario AND DNI = @DNI";
                    //using (SqlCommand resetCmd = new SqlCommand(resetFailedAttemptsQuery, conn))
                    //{
                    //    resetCmd.Parameters.AddWithValue("@Usuario", username);
                    //    resetCmd.Parameters.AddWithValue("@DNI", dni);
                    //    resetCmd.ExecuteNonQuery();
                    //}

                    MessageBox.Show("Bienvenido " + username);
                    a = 1;
                }
            }
        }
    }
}
