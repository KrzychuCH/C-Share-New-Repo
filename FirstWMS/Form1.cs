using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstWMS
{
    public partial class Form1 : Form
    {

        string logg;
        string pass;
        int res;
        string message;
        public Form1()
        {
            InitializeComponent();
     
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            logg = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pass = textBox2.Text;
        }

        private void logged_Click(object sender, EventArgs e)
        {
            {
                string connectionString = "Server=DESKTOP-T0QFA56;Database=AdventureWorks;Trusted_Connection=True";
                string procedureName = "LoginUsers";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tworzenie obiektu SqlCommand dla procedury
                    SqlCommand command = new SqlCommand(procedureName, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Dodanie parametrów procedury
                    command.Parameters.AddWithValue("@Login",logg);
                    command.Parameters.AddWithValue("@Pass",pass);

                    command.Parameters.Add("@msg", SqlDbType.NVarChar, 254).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@res", SqlDbType.Int).Direction = ParameterDirection.Output;

                    /*
                                        // Dodanie parametru wyjściowego do przechwycenia komunikatu z procedury
                                        SqlParameter outputParameter = new SqlParameter("@msg",SqlDbType.NVarChar,254);
                                        outputParameter.Direction = ParameterDirection.Output;
                                        command.Parameters.Add(outputParameter);

                                        // Dodanie parametru wyjściowego do przechwycenia wyniku autoryzacji z procedury
                                        SqlParameter outputParameter2 = new SqlParameter("@res",SqlDbType.Int);
                                        outputParameter2.Direction = ParameterDirection.Output;
                                        command.Parameters.Add(outputParameter2);*/

                    try
                    {
                        connection.Open();


                        command.ExecuteNonQuery();
                        /*
                        // Pobranie komunikatu z procedury
                        message = command.Parameters["@msg"].Value.ToString();
                        // Pobranie wyniku autoryzacji z procedury
                        res = (int)command.Parameters["@res"].Value;

                        // Wyświetlenie komunikatu
                        MessageBox.Show(message);*/
                        string message = command.Parameters["@msg"].Value.ToString();
                        int result = (int)command.Parameters["@res"].Value;

                        if (!string.IsNullOrEmpty(message))
                        {
                            MessageBox.Show(message);
                        }
                        // Ustawienie wartości zmiennej res
                        res = result;
                        if (res == 1)
                        {
                            // Pokaż Form2, jeśli wynik autoryzacji jest równy 1
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Hide();
                        }

                    }
                    catch (Exception ex)
                    {
                        // Obsługa wyjątków
                        MessageBox.Show("Wystąpił błąd: " + ex.Message);
                    }
                }
            }

        }
    }
}
