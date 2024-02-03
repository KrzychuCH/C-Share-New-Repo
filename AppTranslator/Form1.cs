using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppTranslator
{
    public partial class Form1 : Form
    {
        string plWord;
        string enWord;
        int flagPl = 0;
        int flagEn = 0;
        Dictionary<string, string> PL = new Dictionary<string, string>();
        Dictionary<string, string> EN = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += TextBox1_KeyPress;
        }


        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string enteredText = textBox1.Text;
                label2.Text = enteredText;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Obsługa kliknięcia na etykietę (jeśli jest potrzebna)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Ta metoda zostanie wywołana za każdym razem, gdy tekst w polu tekstowym zostanie zmieniony
        }

        private void label2_Click(object sender, EventArgs e)
        {

        } 

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Tworzymy nową instancję nowego formularza
            form2.ShowDialog(); // Wyświetlamy nowe okno jako okno dialogowe
        }

    }
 }
