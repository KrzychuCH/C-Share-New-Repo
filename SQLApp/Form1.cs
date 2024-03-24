using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SQLApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-T0QFA56;Database=AdventureWorks;Trusted_Connection=True";
            string procedureName = "Test_Test1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // Jeśli są dane, odczytaj pierwszy rekord
                    reader.Read();

                    // Pobierz wartość z kolumny "LastName" pierwszego rekordu
                    string lastName = reader["LastName"].ToString();

                    // Wyświetl wartość w kontrolce Label
                    label.Text = lastName;
                }

                reader.Close();
            }
        }
    }
}
