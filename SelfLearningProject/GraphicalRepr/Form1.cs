using SelfLearningProject;
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
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(panel1.Width, panel1.Height);
            squareWidth = panel1.Width / 64;
            squareHeight = panel1.Height / 64;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            World.GetInstance().GenerateFood();
            VisualizedOnBitmap();
            this.panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, new Point(0, 0));
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
                            Draw(graphics, i, j,Color.Red);
                        }
                        else if (x == (int)World.Thing.Empty)
                        {
                            Draw(graphics, i, j, Color.Black);
                        }
                        else if (x == (int)World.Thing.Head)
                        {
                            Draw(graphics, i, j, Color.Green);
                        }
                        else {
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
        /// Generate game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            World.GetInstance().GenerateGame();
            VisualizedOnBitmap();
            this.panel1.Refresh();
        }
    }
}
