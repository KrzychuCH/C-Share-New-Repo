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
            this.Shown += Form1_Shown;
            textBox2.KeyPress += textBox2_KeyPress;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox1.Focus(); // Ustawienie fokusu na textBox1 po załadowaniu formularza
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
            textBox2.PasswordChar = '*';
            pass = textBox2.Text;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
            
                logged_Click(sender, e);
            }
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

                    try
                    {
                        connection.Open();


                        command.ExecuteNonQuery();
                   
                        string message = command.Parameters["@msg"].Value.ToString();
                        int result = (int)command.Parameters["@res"].Value;

                        if (!string.IsNullOrEmpty(message))
                        {
                            MessageBox.Show(message);
                            textBox2.Text = "";

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
