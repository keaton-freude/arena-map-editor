using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArenaMapEditor
{
    public partial class Form1 : Form
    {
        public int selected_id = -1;
        Graphics mapGraphics;

        Map map = new Map();

        public Form1()
        {
            InitializeComponent();

            tile_mappings.Add(1, 1);
            tile_mappings.Add(3, 2);
            tile_mappings.Add(4, 3);
            tile_mappings.Add(5, 4);
            tile_mappings.Add(7, 5);

            tile_mappings.Add(8, 6);
            tile_mappings.Add(9, 7);
            tile_mappings.Add(10, 8);
            tile_mappings.Add(11, 9);
            tile_mappings.Add(12, 10);
            tile_mappings.Add(13, 11);
            tile_mappings.Add(14, 12);

            tile_mappings.Add(15, 13);
            tile_mappings.Add(16, 14);
            tile_mappings.Add(17, 15);
            tile_mappings.Add(18, 16);
            tile_mappings.Add(19, 17);
            tile_mappings.Add(20, 18);
            tile_mappings.Add(21, 19);

            tile_mappings.Add(23, 20);
            tile_mappings.Add(24, 21);
            tile_mappings.Add(25, 22);
            tile_mappings.Add(26, 23);
            tile_mappings.Add(27, 24);

            tile_mappings.Add(30, 25);
            tile_mappings.Add(31, 26);
            tile_mappings.Add(32, 27);
            tile_mappings.Add(33, 28);
            tile_mappings.Add(34, 29);

            tile_mappings.Add(37, 30);
            tile_mappings.Add(41, 31);

            tile_mappings.Add(44, 32);
            tile_mappings.Add(45, 33);
            tile_mappings.Add(47, 34);
            tile_mappings.Add(48, 35);

            tile_mappings.Add(50, 36);
            tile_mappings.Add(51, 37);
            tile_mappings.Add(52, 38);
            tile_mappings.Add(53, 39);
            tile_mappings.Add(54, 40);
            tile_mappings.Add(55, 41);
            tile_mappings.Add(56, 42);

            tile_mappings.Add(57, 43);
            tile_mappings.Add(58, 44);
            tile_mappings.Add(62, 45);
            tile_mappings.Add(63, 46);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = pctTiles.CreateGraphics();

            int y = 0;

            //for (int i = 0; i < imgListTiles.Images.Count; i++)
            //{
            //    if (i == 1 || i == 5 || i == 21)
            //        continue;



            //    if (i % 7 == 0 && i != 0 && i != 5)
            //        y += 32;
            //    imgListTiles.Draw(graphics, new Point((i * 32) % 224, y), i);

            //}

            imgListTiles.Draw(graphics, new Point(0, 0), 0);
            imgListTiles.Draw(graphics, new Point(64, 0), 1);
            imgListTiles.Draw(graphics, new Point(96, 0), 2);
            imgListTiles.Draw(graphics, new Point(128, 0), 3);
            imgListTiles.Draw(graphics, new Point(192, 0), 4);

            for (int i = 0; i < 7; ++i)
            {
                imgListTiles.Draw(graphics, new Point(i * 32, 32), i + 5);
            }

            for (int i = 0; i < 7; ++i)
            {
                imgListTiles.Draw(graphics, new Point(i * 32, 64), i + 12);
            }

            for (int i = 1; i < 6; ++i)
            {
                imgListTiles.Draw(graphics, new Point(i * 32, 96), i + 18);
            }

            for (int i = 1; i < 6; ++i)
            {
                imgListTiles.Draw(graphics, new Point(i * 32, 128), i + 23);
            }

            imgListTiles.Draw(graphics, new Point(32, 160), 29);
            imgListTiles.Draw(graphics, new Point(160, 160), 30);

            imgListTiles.Draw(graphics, new Point(32, 192), 31);
            imgListTiles.Draw(graphics, new Point(64, 192), 32);

            imgListTiles.Draw(graphics, new Point(128, 192), 33);
            imgListTiles.Draw(graphics, new Point(160, 192), 34);

            for (int i = 0; i < 7; ++i)
            {
                imgListTiles.Draw(graphics, new Point(i * 32, 224), 35 + i);
            }

            imgListTiles.Draw(graphics, new Point(0, 256), 42);
            imgListTiles.Draw(graphics, new Point(32, 256), 43);

            imgListTiles.Draw(graphics, new Point(160, 256), 44);
            imgListTiles.Draw(graphics, new Point(192, 256), 45);

        }

        private void pctTiles_Click(object sender, EventArgs e)
        {

        }

        Dictionary<int, int> tile_mappings = new Dictionary<int, int>();

        private void pctTiles_MouseClick(object sender, MouseEventArgs e)
        {
            /* Transform local coordinates into grid-coordinates */

            int x = e.X / 32;
            int y = e.Y / 32;

            int test_index = (y * 7 + x) + 1;

            

            //this.Text = selected_id.ToString();

            //map.map[x, y] = new Cell(selected_id, x * 32, y * 32);

            if (tile_mappings.ContainsKey(test_index))
                selected_id = tile_mappings[test_index];
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            mapGraphics = pctMap.CreateGraphics();

            map.Draw(mapGraphics, imgListTiles);
        }

        private void pctMap_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 32;
            int y = e.Y / 32;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                map.map[x, y] = new Cell(selected_id, x * 32, y * 32);

                map.map[x, y].Draw(mapGraphics, imgListTiles);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                map.map[x, y] = new Cell(27, x * 32, y * 32);

                map.map[x, y].Draw(mapGraphics, imgListTiles);
            }

        }

        private void pctMap_Click(object sender, EventArgs e)
        {

        }

        private void pctMap_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X / 32;
            int y = e.Y / 32;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (selected_id >= 0)
                {
                    map.map[x, y] = new Cell(selected_id, x * 32, y * 32);

                    map.map[x, y].Draw(mapGraphics, imgListTiles);
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                map.map[x, y] = new Cell(27, x * 32, y * 32);

                map.map[x, y].Draw(mapGraphics, imgListTiles);

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Save current map out to file, ask for name */

            SaveFileDialog dlg = new SaveFileDialog();

            dlg.ShowDialog();

            map.WriteToFile(dlg.FileName);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            mapGraphics = pctMap.CreateGraphics();
            dlg.ShowDialog();

            map.OpenFromFile(dlg.FileName);

            map.Draw(mapGraphics, imgListTiles);
        }
    }

    public class Cell
    {
        public int cell_id;
        public int x, y;

        public Cell(int cell_id, int x, int y)
        {
            this.cell_id = cell_id;
            this.x = x;
            this.y = y;
        }

        public void Draw(Graphics g, ImageList imgList)
        {
            imgList.Draw(g, new Point(x, y), cell_id - 1);
        }
        
    }

    public class Map
    {
        public Cell[,] map;

        public const int MAP_WIDTH = 40;
        public const int MAP_HEIGHT = 22;

        public Map()
        {
            map = new Cell[MAP_WIDTH, MAP_HEIGHT];

            for (int i = 0; i < 40; ++i)
            {
                for (int j = 0; j < 22; ++j)
                {
                    map[i,j] = new Cell(27, i * 32, j * 32);
                }
            }
        }

        public void Draw(Graphics g, ImageList imgList)
        {
            for (int i = 0; i < 40; ++i)
            {
                for (int j = 0; j < 22; ++j)
                {
                    map[i,j].Draw(g, imgList);
                }
            }
        }

        public void WriteToFile(string filename)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(filename);

            for (int i = 0; i < 40; ++i)
            {
                for (int j = 0; j < 22; ++j)
                {
                    if (i == 39 && j == 21)
                        writer.Write(map[i, j].cell_id);
                    else
                        writer.Write(map[i, j].cell_id + ",");
                }
            }

            writer.Close();
        }

        public void OpenFromFile(string filename)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(filename);

            string[] broken = reader.ReadToEnd().Split(',');

            int count = 0;

            for (int i = 0; i < MAP_WIDTH; ++i)
            {
                for (int j = 0; j < MAP_HEIGHT; ++j)
                {
                    map[i, j].cell_id = Convert.ToInt32(broken[count]);
                    count++;
                }
            }

            reader.Close();
           
        }
    }
}
