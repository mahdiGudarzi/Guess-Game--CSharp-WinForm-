using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Guess_Game
{
    public partial class Form1 : Form
    {
        
        private string fileName;
        private byte score = 75;
        public Form1()
        {
            InitializeComponent();
            this.init();
        }
        private void UpdateScoreLabel()
        {
            label11.Text =Convert.ToString(this.score);

            if (score == 0)
            {
                label11.Text = "باختی بازی رو دوباره شروع کن ";
                button1.Enabled = false;


            }
        }
        private void init()
        {

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.Combine(baseDirectory, "..", "..");
            string imgFolderPath = Path.Combine(projectDirectory, "img");
            string[] imageFiles = Directory.GetFiles(imgFolderPath, "*.jpg");
            Random random = new Random();
            string randomImagePath = imageFiles[random.Next(imageFiles.Length)];
            Image img = Image.FromFile(randomImagePath);
            this.fileName = Path.GetFileNameWithoutExtension(randomImagePath);
            int pictureBoxWidth = pictureBox1.Width;
            int pictureBoxHeight = pictureBox1.Height;
            Bitmap[,] bmps = new Bitmap[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bmps[i, j] = new Bitmap(pictureBoxWidth, pictureBoxHeight);
                    Graphics g = Graphics.FromImage(bmps[i, j]);
                    g.DrawImage(img, new Rectangle(0, 0, pictureBoxWidth, pictureBoxHeight),
                        new Rectangle(j * (img.Width / 3), i * (img.Height / 3), img.Width / 3, img.Height / 3), GraphicsUnit.Pixel);
                    g.Dispose();
                }
            }
            PictureBox[] pictureBoxes = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9 };

            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.SendToBack();
            }
            pictureBox1.Image = bmps[0, 0];
            pictureBox2.Image = bmps[0, 1];
            pictureBox3.Image = bmps[0, 2];
            pictureBox4.Image = bmps[1, 0];
            pictureBox5.Image = bmps[1, 1];
            pictureBox6.Image = bmps[1, 2];
            pictureBox7.Image = bmps[2, 0];
            pictureBox8.Image = bmps[2, 1];
            pictureBox9.Image = bmps[2, 2];
        }
        private void play()
        {
            Label[] labels = new Label[]
            {
                label1,label2,label3,label4,label5,label6,label7,label8,label9
            };
           

            foreach (var label in labels)
            {
                label.Visible = true;
            }

            this.init();
            this.score = 75;
            this.UpdateScoreLabel();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == this.fileName)
            {
                label11.Text = "بردی ";

            }
            else
            {

                label11.Text = "حدس اشتباه است ";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.score -= 15;
            this.label2.Visible = false;
            this.UpdateScoreLabel(); 
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.score -= 15;
            this.label5.Visible = false;
            this.UpdateScoreLabel();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.score -= 15;
            this.label8.Visible = false;
            this.UpdateScoreLabel();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.score -= 5;
            this.label1.Visible = false;
            this.UpdateScoreLabel();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.score -= 5;
            this.label4.Visible = false;
            this.UpdateScoreLabel();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.score -= 5;
            this.label7.Visible = false;
            this.UpdateScoreLabel();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.score -= 5;
            this.label3.Visible = false;
            this.UpdateScoreLabel();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.score -= 5;
            this.label6.Visible = false;
            this.UpdateScoreLabel();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.score -= 5;
            this.label9.Visible = false;
            this.UpdateScoreLabel();
        }

 

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == false) button1.Enabled = true;
            this.play();

        }
    }
}
