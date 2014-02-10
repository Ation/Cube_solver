using System.Drawing;
using System.Windows.Forms;

namespace Cube
{
    public partial class Form1 : Form
    {
        private Color[] CubeColors = new Color[] { Color.Orange, Color.Blue, Color.Purple, Color.White, Color.Gray, Color.Green, Color.Yellow, Color.Black, Color.Red};
        public Form1()
        {
            InitializeComponent();

                // orange >POM<
                byte[, ,] m1 = { 
                    { {0, 1, 1, 1}, {0, 0, 1, 1}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 1}, {0, 0, 1, 1}, {0, 0, 0, 1}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
                };
                //blue >PA 66 <
                byte[, ,] m2 = {
                    { {1, 1, 0, 0}, {1, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {1, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
                };
                //purple >ABS<
                byte[, ,] m3 = {
                    { {1, 1, 1, 1}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {1, 0, 0, 1}, {1, 0, 0, 0}, {1, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
                };

                //white >PP<
                byte[, ,] m4 = {
                    { {0, 1, 0, 0}, {1, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {1, 1, 0, 0}, {1, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
                };

                // glass >PC<
                byte[, ,] m5 = {
                    { {1, 1, 1, 0}, {1, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 1, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
                };

                //green >hdpe<  
                byte[, ,] m6 = {
                    { {1, 0, 0, 1}, {1, 1, 1, 1}, {0, 1, 0, 0}, {0, 1, 0, 0}},
                    { {1, 0, 0, 1}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 1, 0, 0}},
                    { {1, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 1, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
                };

                // yellow PC/ABS
                byte[, ,] m7 = {
                    { {1, 1, 0, 0}, {0, 1, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 1, 0, 0}, {0, 1, 1, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
                };
                //black >PA66 33GF<
                byte[, ,] m8 = {
                    { {1, 1, 1, 1}, {0, 1, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 1, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
                };
                // red >PBT<
                byte[, ,] m9 = {
                    { {1, 1, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {1, 1, 1, 0}, {1, 0, 0, 0}, {1, 1, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}},
                    { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}}
                };
			
                Cube.Cube _c = new Cube.Cube(4);

                _c.AddDetail("orange >POM<", 1, m1);
                _c.AddDetail("blue >PA 66 <", 2, m2);
                _c.AddDetail("purple >ABS<", 3, m3);
                _c.AddDetail("white >PP<", 4, m4);
                _c.AddDetail("glass >PC<", 5, m5);
                _c.AddDetail("green >hdpe<  ", 6, m6);
                _c.AddDetail("yellow PC/ABS", 7, m7);
                _c.AddDetail("black >PA66 33GF<", 8, m8);
                _c.AddDetail("red >PBT<", 9, m9);

                var results = _c.Solve();

                var layerArray = new PictureBox[4];

                layerArray[0] = m_layer1;
                layerArray[1] = m_layer2;
                layerArray[2] = m_layer3;
                layerArray[3] = m_layer4;
                
                for (int layerIndex = 0; layerIndex < 4; layerIndex++)
                {
                    var image = new Bitmap(80, 80);

                    for (int x = 0; x < 4; x++)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            SetImageColor(x, y, image, results[0].GetCube()[layerIndex, x, y]);
                        }
                    }

                    layerArray[layerIndex].Image = image;
                }
        }

        private void SetImageColor(int x, int y, Bitmap image, int color)
        {
            var c = CubeColors[color - 1];

            int xOffset = x * 20;
            int yOffset = y * 20;
            for (int pixelX = xOffset; pixelX < xOffset + 20; pixelX++)
            {
                for (int pixelY = yOffset; pixelY < 20 + yOffset; pixelY++)
                {
                    image.SetPixel(pixelX, pixelY, c);
                }
            }
        }
    }
}