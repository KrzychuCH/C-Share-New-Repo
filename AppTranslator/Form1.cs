using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace AppTranslator
{

    public partial class Form1 : Form
    {
        public Dictionary<string, string> PL { get; set; }
        public Dictionary<string, string> EN { get; set; }
        private Form2 form2;
    
        public Form1()
        {
        
            InitializeComponent();
            textBox1.KeyPress += TextBox1_KeyPress;
            
            form2 = new Form2(this); // Przekazujemy referencję do Form1 do konstruktora Form2
            form2.DataUpdated += Form2_DataUpdated;

        }
        private void LoadData()
        {
            
            PL = new Dictionary<string, string>(); 
            EN = new Dictionary<string, string>();

            if (File.Exists("dictionary.json"))
            {
                string json = File.ReadAllText("dictionary.json");
                var data = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(json);
                PL = data[0];
                EN = data[1];
            }
        }
        private void Form2_DataUpdated(object sender, EventArgs e)
        {
            // Tutaj odświeżamy dane w Form1, np. ponownie wczytujemy słownik
            LoadData();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
       {
             if (e.KeyChar == (char)Keys.Enter)
             {
                /* string enteredText = textBox1.Text;
                 string translation = GetTranslation(enteredText); // Pobierz tłumaczenie
                 label2.Text = translation; // */
                HandleEnterKeyPress();

            }
           
        }
        private void HandleEnterKeyPress()
        {
            string enteredText = textBox1.Text;
            string translation = GetTranslation(enteredText); // Pobierz tłumaczenie
            label2.Text = translation;
        }


        private void label1_Click(object sender, EventArgs e)
        {
            // Obsługa kliknięcia na etykietę (jeśli jest potrzebna)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*string enteredText = textBox1.Text;
            if (enteredText != "") // Upewnij się, że wpisano coś do textBox1
            {
                string translation = GetTranslation(enteredText); // Pobierz tłumaczenie
                label2.Text = translation; // Wyświetl tłumaczenie w label2
            }
            string enteredText = textBox1.Text;
            if (!string.IsNullOrEmpty(enteredText))
            {
                string translation = GetTranslation(enteredText);
                label2.Text = translation;
            }
            else
            {
                label2.Text = string.Empty; // Wyczyść label2, jeśli pole tekstowe jest puste
            }*/
        }
        private string GetTranslation(string enteredText)
        {
            if (form2.PL.ContainsKey(enteredText))
            {
                return form2.PL[enteredText]; // Zwróć tłumaczenie ze słownika
            }
            else
            {
                return "Brak tłumaczenia"; // Zwróć wiadomość o braku tłumaczenia
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        } 

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this); // Przekazanie instancji Form1 do konstruktora Form2
            form2.ShowDialog(); // Wyświetlenie Form2

            string enteredText = form2.plWord; // Pobranie tłumaczenia z Form2
            label2.Text = enteredText;
            
        }

    }
 }
