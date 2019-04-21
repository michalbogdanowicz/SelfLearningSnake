using SelfLearningProject;
using SelfLearningProject.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalRepr
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;

        int squareWidth = 0;
        int squareHeight = 0;
        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            squareWidth = pictureBox1.Width / 64;
            squareHeight = pictureBox1.Height / 64;

            btnAutomatic.Enabled = false;
            btnNextStep.Enabled = false;

            timer.Tick += Timer_Tick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            World.GetInstance().GenerateFood();
            VisualizedOnBitmap();
            this.pictureBox1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VisualizedOnBitmap()
        {
            using (var graphics = Graphics.FromImage(bitmap))
            {
                var array = World.GetInstance().space;
                for (int i = 0; i < 64; i++)
                {
                    for (int j = 0; j < 64; j++)
                    {
                        int x = array[i, j];

                        if (x == (int)World.Thing.Food)
                        {
                            Draw(graphics, i, j, Color.Red);
                        }
                        else if (x == (int)World.Thing.Empty)
                        {
                            Draw(graphics, i, j, Color.Black);
                        }
                        else if (x == (int)World.Thing.Head)
                        {
                            Draw(graphics, i, j, Color.Green);
                        }
                        else
                        {
                            throw new ArgumentException();
                        }

                    }
                }
            }
        }

        private void DrawRed(Graphics g, int x, int y)
        {
            Draw(g, x, y, Color.Red);
        }

        private void Draw(Graphics g, int x, int y, Color color)
        {
            Brush brush = new SolidBrush(color);
            Point[] points = new Point[4];
            points[0] = new Point(x * squareWidth, y * squareHeight);
            points[1] = new Point(x * squareWidth, y * squareHeight + squareHeight);
            points[2] = new Point(x * squareWidth + squareWidth, y * squareHeight + squareHeight);
            points[3] = new Point(x * squareWidth + squareWidth, y * squareHeight);
            g.FillPolygon(brush, points);
        }

        /// <summary>
        /// Generate World
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            World.GetInstance().GenerateRandomWorld();
            VisualizedOnBitmap();
            this.pictureBox1.Invalidate();

            EnableButtons();
        }

        private void EnableButtons()
        {
            btnAutomatic.Enabled = true;
            btnNextStep.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ManageStep();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Interval = 100;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ManageStep();
        }

        private void ManageStep()
        {

            try
            {
                World.GetInstance().NextStep();
                VisualizedOnBitmap();
                this.pictureBox1.Invalidate();
            }
            catch (SnakeIsOutOfBoundsException)
            {
                btnAutomatic.Enabled = false;
                btnNextStep.Enabled = false;
                timer.Stop();
                MessageBox.Show("The snake died");
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, new Point(0, 0));
        }
        /// <summary>
        /// geneare the specific world
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_2(object sender, EventArgs e)
        {
            World.GetInstance().GenerateSpecificWorld(new Location(10, 50), new Location(2, 22));
            VisualizedOnBitmap();
            this.pictureBox1.Invalidate();
            EnableButtons();
        }
    }
}
