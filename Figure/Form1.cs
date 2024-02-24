using Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figure {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;
        }

        // Draw
        private void button2_Click(object sender, EventArgs e) {
            if (radioButton1.Checked) {
                Star obj = new Star();
                drawObject(obj);
            }
            if (radioButton2.Checked) {
                Figures.Ellipse obj = new Figures.Ellipse();
                drawObject(obj);
            }
            if (radioButton3.Checked) {
                Sector obj = new Sector();
                drawObject(obj);
            }
            if (radioButton4.Checked) {
                Rect obj = new Rect();
                drawObject(obj);
            }

            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked) {
                int value = int.Parse(textBox1.Text) + 1;
                textBox1.Text = value.ToString();
            }

        }

        Bitmap image;
		void drawObject(Figures.Figure obj) {
            Random random = new Random();

            if (textBox2.Text.Count() > 0 && textBox3.Text.Count() > 0) {
                obj.width = int.Parse(textBox2.Text);
                obj.height = int.Parse(textBox3.Text);
            } else {
                obj.width = 20;
                obj.height = 20;
            }

            obj.x = random.Next(0, pictureBox1.Width - obj.width);
            obj.y = random.Next(0, pictureBox1.Height - obj.height);

            obj.color = colorDialog1.Color;

            Bitmap existingImage = (Bitmap)pictureBox1.Image;
            if (existingImage == null) {
                existingImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            Bitmap newImage = new Bitmap(existingImage);
            pictureBox1.Image = newImage;

            Graphics g = Graphics.FromImage(newImage);
            obj.Draw(g);
        }
    }
}
