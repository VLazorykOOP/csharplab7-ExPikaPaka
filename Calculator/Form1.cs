using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpressionParser;
using Microsoft.Win32;

namespace Calculator {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
        }

        public static string previousText;

        public void selectInput() {
            textBoxIn.Focus();
            textBoxIn.Select(textBoxIn.Text.Count(), 0);
        }

        public void evaluate() {
            if (textBoxIn.Text != previousText && textBoxIn.Text.Count() > 0) {
                string expression = textBoxIn.Text;
                try {
                    string result = ExParser.Evaluate(expression).ToString();
                    textBoxOut.Text = textBoxIn.Text + " =";
                    textBoxIn.Text = result;
                } catch (Exception ex) {
                    textBoxIn.Text = "Nan";
                }
            }

            previousText = textBoxIn.Text;
            selectInput();
        }

        private void FitTextToTextBox(TextBox textBox, float MaxFontSize = 27.75f, float MinFontSize = 1f) {

            // Calculate the width of the text
            float textWidth = TextRenderer.MeasureText(textBox.Text, textBox.Font).Width;

            if (textWidth > textBox.Width) {
                // Decrease the font size
                Font currentFont = textBox.Font;
                float newSize = currentFont.Size - 1; // You can adjust this value according to your needs
                Font newFont = new Font(currentFont.FontFamily, newSize);

                textWidth = TextRenderer.MeasureText(textBox.Text, newFont).Width;

                // While text is still too wide and font size is above minimum
                while (textWidth > textBox.Width && newSize > MinFontSize) {
                    newSize--;
                    newFont = new Font(currentFont.FontFamily, newSize);
                    textWidth = TextRenderer.MeasureText(textBox.Text, newFont).Width;
                }

                // Apply the new font size, but check if text fits at maximum font size
                if (textWidth > textBox.Width && newSize < MaxFontSize) {
                    // Reset font size
                    newSize = MaxFontSize;
                    newFont = new Font(currentFont.FontFamily, newSize);
                }

                // Apply the new font size
                textBox.Font = newFont;
            } else if (textBox.Font.Size < MaxFontSize) // If text fits, check if it can be increased
              {
                Font currentFont = textBox.Font;
                float newSize = currentFont.Size + 1; // Increase font size
                if (newSize > MaxFontSize) newSize = MaxFontSize; // Cap at maximum size
                Font newFont = new Font(currentFont.FontFamily, newSize);

                // Measure again to ensure the new size fits
                textWidth = TextRenderer.MeasureText(textBox.Text, newFont).Width;
                if (textWidth <= textBox.Width) {
                    textBox.Font = newFont; // Apply the new font size
                }
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e) {
            evaluate();
        }

        private void textBoxIn_TextChanged(object sender, EventArgs e) {
            FitTextToTextBox(textBoxIn);
        }

        private void textBoxOut_TextChanged(object sender, EventArgs e) {
            FitTextToTextBox(textBoxOut, 20.25f);
        }

        private void buttonErase_Click(object sender, EventArgs e) {
            if (textBoxIn.Text.Length > 0) {
                textBoxIn.Text = textBoxIn.Text.Remove(textBoxIn.Text.Length - 1);
            }
            selectInput();
        }

        private void button0_Click(object sender, EventArgs e) {
            textBoxIn.Text += "0";
            selectInput();
        }

        private void button1_Click(object sender, EventArgs e) {
            textBoxIn.Text += "1";
            selectInput();
        }

        private void button2_Click(object sender, EventArgs e) {
            textBoxIn.Text += "2";
            selectInput();
        }

        private void button3_Click(object sender, EventArgs e) {
            textBoxIn.Text += "3";
            selectInput();
        }

        private void button4_Click(object sender, EventArgs e) {
            textBoxIn.Text += "4";
            selectInput();
        }

        private void button5_Click(object sender, EventArgs e) {
            textBoxIn.Text += "5";
            selectInput();
        }

        private void button6_Click(object sender, EventArgs e) {
            textBoxIn.Text += "6";
            selectInput();
        }

        private void button7_Click(object sender, EventArgs e) {
            textBoxIn.Text += "7";
            selectInput();
        }

        private void button8_Click(object sender, EventArgs e) {
            textBoxIn.Text += "8";
            selectInput();
        }

        private void button9_Click(object sender, EventArgs e) {
            textBoxIn.Text += "9";
            selectInput();
        }

        private void buttonSqrt_Click(object sender, EventArgs e) {
            textBoxIn.Text += "√";
            selectInput();
        }

        private void buttonPower_Click(object sender, EventArgs e) {
            textBoxIn.Text += "^";
            selectInput();
        }

        private void buttonDivide_Click(object sender, EventArgs e) {
            textBoxIn.Text += "/";
            selectInput();
        }

        private void buttonMultiplicate_Click(object sender, EventArgs e) {
            textBoxIn.Text += "*";
            selectInput();
        }

        private void buttonMinus_Click(object sender, EventArgs e) {
            textBoxIn.Text += "-";
            selectInput();
        }

        private void buttonPlus_Click(object sender, EventArgs e) {
            textBoxIn.Text += "+";
            selectInput();
        }

        private void buttonComma_Click(object sender, EventArgs e) {
            textBoxIn.Text += ",";
            selectInput();
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            textBoxIn.Clear();
            selectInput();
        }

        private void textBoxIn_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) { // Evaluate expression
                evaluate();
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape) { // Clear all field
                textBoxIn.Text = "";
                e.SuppressKeyPress = true;
            }
        }
    }
}
