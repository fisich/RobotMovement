using Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RobotMovement
{
    public partial class Form1 : Form
    {
        private const int SquareSize = 30;
        Map map;
        Direction robotDirection = Direction.None;
        public Form1()
        {
            InitializeComponent();
            // Для случаев, когда карта не умещается в форме
            gridPanel.AutoScroll = true;
            gridPanel.HorizontalScroll.Enabled = true;
            gridPanel.HorizontalScroll.Visible = true;
            gridPanel.VerticalScroll.Enabled = true;
            gridPanel.VerticalScroll.Enabled = true;
        }

        public void RedrawGrid(int sizeX, int sizeY)
        {
            gameGrid.Rows.Clear();
            gameGrid.Columns.Clear();
            gameGrid.Size = new Size(sizeX * SquareSize + 3, sizeY * SquareSize + 3);
            for (int i = 0; i < sizeX; i++)
            {
                gameGrid.Columns.Add(i.ToString(), "");
            }
            foreach (DataGridViewColumn col in gameGrid.Columns)
            {
                col.Width = SquareSize;
            }
            gameGrid.RowTemplate.Height = SquareSize;
            for (int i = 0; i < sizeY; i++)
            {
                gameGrid.Rows.Add();
            }
        }

        private void generateMapBTN_Click(object sender, EventArgs e)
        {
            int x = Decimal.ToInt32(mapSizeXUpDown.Value);
            int y = Decimal.ToInt32(mapSizeYUpDown.Value);
            MapGenerator2D generator2D;
            if (perlinNoiseRBTN.Checked)
                generator2D = new PerlinMapGenerator2D();
            else
                generator2D = new RandomMapGenerator2D();
            if (map == null)
            {
                map = new Map(x, y, generator2D);
            }
            else
            {
                map.SetMap(x, y, generator2D);
            }
            RedrawGrid(x, y);
            ColorGrid(map.GetMap());
        }

        private void spawnRobotBTN_Click(object sender, EventArgs e)
        {
            if (map == null)
                return;
            if (robotDirection == Direction.None)
            {
                MessageBox.Show("Не выбрано начальное направление робота");
                return;
            }
            List<DataGridViewCell> cells = gameGrid.SelectedCells.Cast<DataGridViewCell>().ToList();
            WorldPoint2D start = new WorldPoint2D(cells.Min(c => c.ColumnIndex), cells.Min(c => c.RowIndex));
            WorldPoint2D end = new WorldPoint2D(cells.Max(c => c.ColumnIndex), cells.Max(c => c.RowIndex));
            map.SpawnRobot(start, end, robotDirection);
            ColorGrid(map.GetMap());
        }

        private void ColorGrid(int [,] matrix)
        {
            if (matrix == null)
                return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        gameGrid.Rows[j].Cells[i].Style.BackColor = Color.Black;
                    }
                    else if(matrix[i,j] == 0)
                    {
                        gameGrid.Rows[j].Cells[i].Style.BackColor = Color.White;
                    }
                    else
                    {
                        gameGrid.Rows[j].Cells[i].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        private void gameGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys) == Keys.Control)
            {
                gameGrid.ClearSelection();
            }
            else
            {
                base.OnMouseDown(e);
            }
        }

        private void rotateRobotRightBTN_Click(object sender, EventArgs e)
        {
            if (map == null)
                return;
            map.RotateRobot(true);
            ColorGrid(map.GetMap());
        }

        private void UpDirectionBTN_Click(object sender, EventArgs e)
        {
            robotDirection = Direction.UP;
            directionTB.Text = ((Button)sender).Text;
        }

        private void RightDirectionBTN_Click(object sender, EventArgs e)
        {
            robotDirection = Direction.RIGHT;
            directionTB.Text = ((Button)sender).Text;
        }

        private void DownDirectionBTN_Click(object sender, EventArgs e)
        {
            robotDirection = Direction.DOWN;
            directionTB.Text = ((Button)sender).Text;
        }

        private void LeftDirectionBTN_Click(object sender, EventArgs e)
        {
            robotDirection = Direction.LEFT;
            directionTB.Text = ((Button)sender).Text;
        }

        private void moveRobotForwardBTN_Click(object sender, EventArgs e)
        {
            if (map == null)
                return;
            map.MoveRobot();
            ColorGrid(map.GetMap());
        }
    }
}
