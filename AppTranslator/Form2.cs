using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace AppTranslator
{
    public partial class Form2 : Form
    {
        public string plWord;
        string enWord;
        int flagPl = 0;
        int flagEn = 0;
         public  Dictionary<string, string> PL = new Dictionary<string, string>();
         public  Dictionary<string, string> EN = new Dictionary<string, string>();
        public event EventHandler DataUpdated;

        private Form1 parentForm;
        private Form1 form1;
        public Form2(Form1 parent)

        {
            InitializeComponent();
            parentForm = parent;
        }
        public Form2()
        {
            InitializeComponent();
           
        }
    
        public void GetDatePl()
        {

            Regex regexPl = new Regex(@"[\W\d\s]");
            bool ismatch = regexPl.IsMatch(plWord);
            if (ismatch == true)
            {
                MessageBox.Show("Wprowadzony tekst: " + plWord + " - Słowo nie powinno zawierać cyfr,biłaych znaków lub znaków specjalnych jak np. (+,@,#)");
                flagPl = 1;
                return;
            }
            else
            {
                plWord = plWord.ToUpper();
            }
        }
        public void GetDateEn()
        {

            Regex regexEN = new Regex(@"[\W\d\s]");
            bool ismatch = regexEN.IsMatch(enWord);
            if (ismatch == true)
            {
                MessageBox.Show("Wprowadzony tekst: " + enWord + " - Słowo nie powinno zawierać cyfr,biłaych znaków lub znaków specjalnych jak np. (+,@,#)");
                flagEn = 1;
                return;
            }
            else
            {
                enWord = enWord.ToUpper();
            }

        }
        public void Dict()
        {

            if (!PL.ContainsKey(plWord))
                PL.Add(plWord, enWord);
            if (!EN.ContainsKey(enWord))
                EN.Add(enWord, plWord);

        }
        private void UpdateDictionary()
        {
            // Kod aktualizacji słownika

            // Wywołanie zdarzenia informującego o aktualizacji danych
            DataUpdated?.Invoke(this, EventArgs.Empty);
        }
        private void LoadData()
        {
            if (File.Exists("dictionary.json"))
            {
                string json = File.ReadAllText("dictionary.json");
                var data = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(json);
                PL = data[0];
                EN = data[1];
            }
        }
        private void SaveData()
        {
            var data = new Dictionary<string, string>[] { PL, EN };
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText("dictionary.json", json);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
            string enteredText = parentForm.textBox1.Text; // Pobierz wpisane słowo z Form1
            if (PL.ContainsKey(enteredText))
            {
                string translation = PL[enteredText]; // Pobierz tłumaczenie
                parentForm.label2.Text = translation; // Przypisz tłumaczenie do label2 w Form1
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            plWord = textBox1.Text;
            enWord = textBox2.Text;

            GetDatePl();
            GetDateEn();

            if (flagPl == 0 && flagEn == 0)
            {
                Dict();
                SaveData();
                DataUpdated?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Słowa zostały dodane do słownika.");
            }

            string enteredText = textBox1.Text;
            parentForm.label2.Text = enteredText;

            plWord = textBox2.Text;
        }


    }
}