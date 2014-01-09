using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Cube.Cube;

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

                List<CubeSolveResult> results = _c.Solve();

                PictureBox[] layer_array = new PictureBox[4];

                layer_array[0] = m_layer1;
                layer_array[1] = m_layer2;
                layer_array[2] = m_layer3;
                layer_array[3] = m_layer4;
                
                for (int layer_index = 0; layer_index < 4; layer_index++)
                {
                    Bitmap image = new Bitmap(80, 80);

                    for (int x = 0; x < 4; x++)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            SetImageColor(x, y, image, results[0].GetCube()[layer_index, x, y]);
                        }
                    }

                    layer_array[layer_index].Image = image;
                }

                return;
        }

        private void SetImageColor(int x, int y, Bitmap image, int color)
        {
            Color c = CubeColors[color - 1];

            int x_offset = x * 20;
            int y_offset = y * 20;
            for (int pixel_x = x_offset; pixel_x < x_offset + 20; pixel_x++)
            {
                for (int pixel_y = y_offset; pixel_y < 20 + y_offset; pixel_y++)
                {
                    image.SetPixel(pixel_x, pixel_y, c);
                }
            }
        }
    }
}