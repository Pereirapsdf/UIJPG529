using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;
using DallJPG529.Contratos529;
using DallJPG529.Servicios529;
using System.Windows.Forms;
using System.Net;
namespace DallJPG529
{
    public class Mozo529
    {
        private readonly string conectionString;
       

        public Mozo529() 
        {
            conectionString = ConfigurationManager.ConnectionStrings["ServN"].ConnectionString;
     
        }
        
        

        public void Add(string password, string username, int Dni)
        {
            string hash = HashhJPG.HashPassword(password);

            using (SqlConnection conn = new SqlConnection(conectionString))
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Dni = @Dni";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Dni", Dni);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("El usuario con el Dni:" + Dni + "ya existe");
                        return;
                    }
                }
                string insertQuery = "INSERT INTO Users (Usuario, Contraseña, Dni, Intento) VALUES (@Usuario, @Contraseña,@Dni,@Intento)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@Usuario", username);
                    insertCmd.Parameters.AddWithValue("@Contraseña", hash);
                    insertCmd.Parameters.AddWithValue("@Dni", Dni);
                    insertCmd.Parameters.AddWithValue("@Intento", 0); 
                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario creado exitosamente.");
                }
            }
        }
        public int a=0;
        public int b;
        public void Ingre(string username, string password, int dni)
        {
            string hashedPassword = HashhJPG.HashPassword(password);

            using (SqlConnection conn = new SqlConnection(conectionString))
            {
                conn.Open();

                string checkQuery = "SELECT Contraseña, Intento FROM Users WHERE Usuario = @Usuario AND DNI = @DNI";
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

                    string storedHashedPassword = reader.GetString(0);
                    int intentosFallidos = reader.GetInt32(1);
                    if (intentosFallidos == 2)
                    {
                        b = intentosFallidos;
                    }

                    reader.Close(); 

                    if (intentosFallidos >= 4)
                    {
                        MessageBox.Show("Tu cuenta está bloqueada por múltiples intentos fallidos. Intenta nuevamente más tarde.");
                        return;
                    }

                    if (storedHashedPassword != hashedPassword)
                    {
                        string updateFailedAttemptsQuery = "UPDATE Users SET Intento = Intento + 1 WHERE Usuario = @Usuario AND DNI = @DNI";
                        using (SqlCommand updateCmd = new SqlCommand(updateFailedAttemptsQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@Usuario", username);
                            updateCmd.Parameters.AddWithValue("@DNI", dni);
                            updateCmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Usuario ,contraseña o Dni incorrectos..");
                        return;
                    }

                  
                    string resetFailedAttemptsQuery = "UPDATE Users SET Intento= 0 WHERE Usuario = @Usuario AND DNI = @DNI";
                    using (SqlCommand resetCmd = new SqlCommand(resetFailedAttemptsQuery, conn))
                    {
                        resetCmd.Parameters.AddWithValue("@Usuario", username);
                        resetCmd.Parameters.AddWithValue("@DNI", dni);
                        resetCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Bienvenido " + username);
                    a = 1;
                }
            }
        }



        //public void Delete(string username, string password)
        //{
        //    string hashedPassword = HashhJPG.HashPassword(password);

        //    using (SqlConnection conn = new SqlConnection(conectionString))
        //    {
        //        conn.Open();

        //        string checkQuery = "SELECT COUNT(*) FROM Users WHERE Usuario = @Usuario AND Contraseña = @Password";
        //        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
        //        {
        //            checkCmd.Parameters.AddWithValue("@Usuario", username);
        //            checkCmd.Parameters.AddWithValue("@Password", hashedPassword);
        //            int count = (int)checkCmd.ExecuteScalar();

        //            if (count == 0)
        //            {
        //                MessageBox.Show("Usuario o contraseña incorrectos.");
        //                return;
        //            }
        //        }

        //        string deleteQuery = "DELETE FROM Users WHERE Usuario = @Usuario AND Contraseña = @Password";
        //        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
        //        {
        //            deleteCmd.Parameters.AddWithValue("@Usuario", username);
        //            deleteCmd.Parameters.AddWithValue("@Password", hashedPassword);
        //            int rowsAffected = deleteCmd.ExecuteNonQuery();

        //            if (rowsAffected > 0)
        //            {
        //                MessageBox.Show("Usuario eliminado exitosamente.");
        //            }
        //            else
        //            {
        //                MessageBox.Show ("No se pudo eliminar el usuario.");
        //            }
        //        }
        //    }
        //}
        public void Update(string username,int Dni, string currentPassword, string newPassword)
        {
            string hashedCurrentPassword = HashhJPG.HashPassword(currentPassword);
            string hashedNewPassword = HashhJPG.HashPassword(newPassword);

            using (SqlConnection conn = new SqlConnection(conectionString))
            {
                conn.Open();

               
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Usuario = @Usuario AND Contraseña = @CurrentPassword AND Dni =@DNI";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Usuario", username);
                    checkCmd.Parameters.AddWithValue("@CurrentPassword", hashedCurrentPassword);
                    checkCmd.Parameters.AddWithValue("@Dni", Dni);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        //MessageBox.Show("Usuario o contraseña incorrectos.");
                       
                    }
                }

     
                string selectQuery = "SELECT Contraseña, Intento FROM Users WHERE Usuario = @Usuario AND Dni = @DNI";
                using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@Usuario", username);
                    selectCmd.Parameters.AddWithValue("@Dni", Dni);

                    using (SqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Error al obtener los datos del usuario.");
                            return;
                        }

                        string storedHashedPassword = reader.GetString(0);
                        int intentosFallidos = reader.GetInt32(1);

                        if (intentosFallidos >= 4)
                        {
                            MessageBox.Show("Tu cuenta está bloqueada por múltiples intentos fallidos. Intenta nuevamente más tarde.");
                            return;
                        }

                        if (storedHashedPassword != hashedCurrentPassword)
                        {
                            reader.Close(); 

                            string updateFailedAttemptsQuery = "UPDATE Users SET Intento = Intento + 1 WHERE Usuario = @Usuario AND DNI = @DNI";
                            using (SqlCommand updateCmd = new SqlCommand(updateFailedAttemptsQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@Usuario", username);
                                updateCmd.Parameters.AddWithValue("@DNI", Dni);
                                updateCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Usuario , contraseña o Dni incorrectos.");
                            return;
                        }

                    }
                }

                string updateQuery = "UPDATE Users SET Contraseña = @NewPassword WHERE Usuario = @Usuario AND Dni=@Dni";
               
                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@Usuario", username);
                    updateCmd.Parameters.AddWithValue("@NewPassword", hashedNewPassword);
                    updateCmd.Parameters.AddWithValue("@Dni", Dni);
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        string resetFailedAttemptsQuery = "UPDATE Users SET Intento= 0 WHERE Usuario = @Usuario AND DNI = @DNI";
                        using (SqlCommand resetCmd = new SqlCommand(resetFailedAttemptsQuery, conn))
                        {
                            resetCmd.Parameters.AddWithValue("@Usuario", username);
                            resetCmd.Parameters.AddWithValue("@DNI", Dni);
                            resetCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Contraseña actualizada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la contraseña.");
                    }
                }
            }

           
        }
    }

}


