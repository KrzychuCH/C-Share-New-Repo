using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppTranslator
{
    public partial class Form3 : Form

    {
        private Form1 parentForm;
        private Random random = new Random();
        private string currentWord;
        //  private Form1 form1;
        public Form3(Form1 parent)

        {
            InitializeComponent();
            parentForm = parent;
            SetRandomWord();
            textBox1.KeyDown += TextBox1_KeyDown;
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();

            SetRandomWord();
        }
        private void SetRandomWord()
        {
            // Losowe wybranie słowa z PL lub EN
            Dictionary<string, string> selectedDictionary;
            if (random.Next(2) == 0)
                selectedDictionary = parentForm.PL;
            else
                selectedDictionary = parentForm.EN;

            // Sprawdzenie, czy selectedDictionary nie jest null
            if (selectedDictionary != null && selectedDictionary.Count > 0)
            {
                // Losowy wybór słowa
                currentWord = selectedDictionary.Keys.ElementAt(random.Next(selectedDictionary.Count));

                // Wyświetlenie słowa w labelu
                label1.Text = currentWord;
            }
            else
            {
                // Obsługa przypadku, gdy selectedDictionary jest null lub pusty
                label1.Text = "Brak dostępnych słów w wybranym słowniku.";
            }

            // Wyczyszczenie textBox1
            textBox1.Clear();

            // Wyczyszczenie label3
            label3.Text = "";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Obsługa wciśnięcia klawisza Enter w textBox1
         if (e.KeyCode == Keys.Enter)
            {
                // Usunięcie znaku nowej linii
                textBox1.Text = textBox1.Text.Replace("\r\n", "");

                // Pobranie tłumaczenia wpisanego przez użytkownika
                string translation = textBox1.Text.Trim().ToUpper();

                // Sprawdzenie poprawności tłumaczenia
                string expectedTranslation = currentWord == null ? "" : parentForm.PL.ContainsKey(currentWord) ? parentForm.PL[currentWord] : parentForm.EN[currentWord];
                bool isTranslationCorrect = translation == expectedTranslation;

                // Wyświetlenie odpowiedniego komunikatu w label3
                label3.Text = isTranslationCorrect ? "Poprawnie przetłumaczono!" : "Niepoprawne tłumaczenie.";

                // Ustawienie koloru tła w zależności od wyniku
                label3.BackColor = isTranslationCorrect ? Color.Green : Color.Red;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            // Sprawdzenie, czy wciśnięto Enter
            if (textBox1.Text.Contains("\n"))
            {
                // Usunięcie znaku nowej linii
                textBox1.Text = textBox1.Text.Replace("\n", "");

                // Symulacja kliknięcia button1
                button1.PerformClick();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
