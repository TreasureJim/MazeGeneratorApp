using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGeneratorApp
{
    public partial class Form1 : Form
    {
        //Statics
        MazeRoomGenerator generator;

        //Properties
        // Changes the size of each tile that is drawn
        int squareSize = 10;
        int pictureboxMinSize;

        // Calibrate values between the generator and the display settings
        private void UpdateValues()
        {
            squareSize = (int)BoxSizeNumeric.Value;


            // Map size must be an odd size
            generator.mapSize = (int)MazeSizeNumeric.Value;
            generator.minRoomSize = (int)roomMinSizeNumeric.Value;
            generator.maxRoomSize = (int)roomMaxSizeNumeric.Value;
            generator.roomBuildAttempts = (int)roomBuildAttemptsNumeric.Value;
            //Connection chance must be between 0 and 100%
            generator.connectionChance = (int)connectionChanceNumeric.Value;
            //Winding chance must be between 0 and 100%
            generator.windingChance = (int)windingChanceNumeric.Value;
            generator.removeDeadEnds = deadEndsCheck.Checked;
        }
        // Fix any display settings that has been rectified by the generator
        private void UpdateDisplayValues()
        {
            MazeSizeNumeric.Value = generator.mapSize;
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureboxMinSize = pictureBox1.Size.Height;

            generator = new MazeRoomGenerator();
            UpdateValues();
        }

        private void Picture_Paint(object sender, PaintEventArgs e)
        {
            // If the generator has not yet generated the level skip painting the level
            if(generator.levelTiles == null) { return; }

            Graphics g = e.Graphics;
            SolidBrush wallBrush = new SolidBrush(Color.Black);
            SolidBrush doorBrush = new SolidBrush(Color.Yellow);
            SolidBrush emptyBrush = new SolidBrush(Color.White);


            // Drawing each tile of the level
            /*
             * Yellow = Door
             * White = Floor
             * Black = Wall
             */
            for (int y = 0; y <= generator.mapSize - 1; y++)
            {
                for (int x = 0; x <= generator.mapSize - 1; x++)
                {
                    Rectangle rect = new Rectangle(x * squareSize, y * squareSize, squareSize, squareSize);
                    switch (generator.levelTiles[x, y])
                    {
                        case MazeRoomGenerator.TileType.Wall:
                            g.FillRectangle(wallBrush, rect);
                            break;
                        case MazeRoomGenerator.TileType.Door:
                            g.FillRectangle(doorBrush, rect);
                            break;
                        default:
                            g.FillRectangle(emptyBrush, rect);
                            break;
                    }
                }
            }

        }
        void Redraw()
        {
            if (squareSize * generator.mapSize > pictureboxMinSize)
            {
                pictureBox1.Height = squareSize * generator.mapSize;
                pictureBox1.Width = squareSize * generator.mapSize;
            }
            else
            {
                pictureBox1.Height = pictureboxMinSize;
                pictureBox1.Width = pictureboxMinSize;
            }

            this.pictureBox1.Refresh();
        }



        //Display settings function calls
        private void BoxSizeNumeric_ValueChanged(object sender, EventArgs e)
        {
            // Redraw when box size is changed
            UpdateValues();
            Redraw();
        }
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            UpdateValues();

            generator.GenerateLevel();
            UpdateDisplayValues();
            Redraw();
        }

    }
}
