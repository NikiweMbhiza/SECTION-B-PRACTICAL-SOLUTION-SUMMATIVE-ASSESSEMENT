using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SECTION_B_PRACTICAL_SOLUTION_SUMMATIVE_ASSESSEMENT
{
    public partial class Form1 : Form

    {
        private ArrayList addedWords = new ArrayList();
        private ArrayList concatenatedWords = new ArrayList();

        private HashSet<string> words = new HashSet<string>();
        public Form1()
        {
            InitializeComponent();
            lblConcatenate.BackColor = System.Drawing.Color.White;
            lblConcatenate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblConcatenate.Dock = DockStyle.Bottom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newWord = txtNewWord.Text.Trim();

            if (string.IsNullOrWhiteSpace(newWord))
            {
                MessageBox.Show("Please enter a word.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (words.Contains(newWord))
            {
                MessageBox.Show("Word already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            words.Add(newWord);
            AddWordToComboBoxes(newWord);
            MessageBox.Show($"Word '{newWord}' has been added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNewWord.Clear();
        }
        private void AddWordToComboBoxes(string word)
        {
            comboBox1.Items.Add(word);
            comboBox2.Items.Add(word);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //string selectedWord1 = comboBox1.SelectedItem as string;
            //string selectedWord2 = comboBox2.SelectedItem as string;

            //if (string.IsNullOrWhiteSpace(selectedWord1) || string.IsNullOrWhiteSpace(selectedWord2))
            //{
            //    MessageBox.Show("Please select two different words.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //string concatenatedWord = selectedWord1 + selectedWord2;
            //lblConcatenate.Text = $"Concatenated Word: {concatenatedWord}";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnRemoveItem.Text = "Remove Item";
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                RemoveSelectedWord();
            }
            else
            {
                ConcatenateSelectedWords();
            }
        }

        private void RemoveSelectedWord()
        {
            string selectedWord;

            if (comboBox1.SelectedItem != null)
            {
                selectedWord = comboBox1.SelectedItem.ToString();
                comboBox1.Items.Remove(selectedWord);
                comboBox2.Items.Remove(selectedWord);

                MessageBox.Show($"Word '{selectedWord}' has been removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a word to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConcatenateSelectedWords()
        {
            string selectedWord1 = comboBox1.SelectedItem as string;
            string selectedWord2 = comboBox2.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(selectedWord1) || string.IsNullOrWhiteSpace(selectedWord2))
            {
                MessageBox.Show("Please select two different words.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedWord1.Equals(selectedWord2))
            {
                MessageBox.Show("Please select different words for concatenation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string concatenatedWord = selectedWord1 + selectedWord2;
            concatenatedWords.Add(concatenatedWord);

            MessageBox.Show($"Concatenated word '{concatenatedWord}' has been added to the collection.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblConcatenate.Text = $"Concatenated Word: {concatenatedWord}";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnRemoveItem.Text = "Concatenate Words";
        }
    }
    
}
