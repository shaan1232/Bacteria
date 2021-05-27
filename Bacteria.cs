using System;
using System.Drawing;
using System.Windows.Forms;
//using System.Drawing.Color;

namespace Bacteria
{
    public static class Globals
    {
        public const int numPlayers = 3; // leave it at 3 for now, its hard coded for 3. Change it later
        public const int windowWidth = 1300;
        public const int windowHeight = 900;
        public const int boardColumns = 30;
        public const int boardRows = 30;

    }


    class Game
    {

        public static int[,] board = new int[Globals.boardColumns, Globals.boardRows];


        public static void runGame(int numPlayers)
        {
            initPlayers(numPlayers);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Size(windowWidth, windowHeight);
            Application.Run(new MyForm());
            //  Form1.Size = new Size(windowWidth, windowHeight);
        }

        public static void initPlayers()
        {
            int a = 0, b = a, c = a, d = c, e = c;

            Random rand = new Random();

            for (int i = 0; i < Globals.boardColumns; i++)
            {
                for (int j = 0; j < Globals.boardRows; j++)
                {
                    board[i, j] = rand.Next(Globals.numPlayers);
                }
            }
        }

        public static void turn()
        {
            // look at all the neighbours. Depending on the amount of neighbours you have the stronger your defense
            // etc i own left and right and top, enemy owns bottom, 3/4 chance I take this square.

            // only have to account for 4 possibilities

            int left = -1;
            int top = -1;
            int bottom = -1;
            int right = -1;

            for (int i = 0; i < dotsX; i++)
            {
                for (int j = 0; j < dotsY; j++)
                {
                    // top left, only have to account for bottom and right
                    if (i == 0 && j == 0)
                    {
                        bottom = board[i][j + 1];
                        right = board[i + 1][j];
                    }
                    // top right
                    else if (i == boardColumns - 1 && j == 0)
                    {
                        bottom = board[i][j + 1];
                        left = board[i - 1][j];
                    }
                    // bottom left
                    else if (i == 0 && j == boardRows - 1)
                    {
                        top = board[i][j - 1];
                        right = board[i + 1][j];
                    }
                    // bottom right
                    else if (i == boardColumns - 1 && j == boardRows - 1)
                    {
                        top = board[i][j - 1];
                        left = board[i - 1][j];
                    }




                }
            }

        }

        public int[,] getBoard()
        {
            return board;
        }



        public static void Main(string[] args)
        {
            //Simulation should go
            // 100 random bacteria split up randomly in a 100 x 100 grid
            // the bacteria to the left, right, up, down (4 psosible) have a fight, 50% chance of winning it. Whichever bacteria wins fight
            // conquers square


            /*
            Console.WriteLine("Enter num players");

            int numPlayers = -1;
            while (numPlayers <= 1)
            {
                Console.WriteLine("Must be minimum 2 players.");
                string input = Console.ReadLine();
                Int32.TryParse(input, out numPlayers);
            }
            */

            runGame();

        }
    }

    public class MyForm : Form
    {
        static Color red = Color.FromArgb(255, 0, 0);
        static Color green = Color.FromArgb(0, 255, 0);
        static Color blue = Color.FromArgb(0, 0, 255);

        static Color[] myColors = {
        red,
        green,
        blue
};
        public int[,] board; // = new board[Globals.boardColumns, Globals.boardRows];
        public MyForm()
        {

            Game game = new Game();
            board = game.getBoard();

            //  for (int i =)

            //InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            int dotsX = Globals.boardRows; // size of pixel width
            int dotsY = Globals.boardColumns; // size of pixel heightsizes of pixels dotLength

            base.OnPaint(e);

            Graphics gfx = e.Graphics;
            Pen p = new Pen(myColors[1]);
            p.Color = myColors[1];

            gfx.DrawRectangle(Pens.Black, 10f, 50f, 20f, 20f);
            gfx.FillRectangle(Brushes.Red, 10f, 50f, 20f, 20f);
            gfx.DrawRectangle(Pens.Black, 30f, 50f, 20f, 20f);
            gfx.FillRectangle(Brushes.Blue, 30f, 50f, 20f, 20f);

            for (int i = 0; i < dotsX; i++)
            {
                for (int j = 0; j < dotsY; j++)
                {
                    switch (board[i, j])
                    {
                        case 0:
                            gfx.FillRectangle(Brushes.Red, 10 + j * dotsX, i * dotsY, dotsX, dotsY);
                            break;

                        case 1:
                            gfx.FillRectangle(Brushes.Green, 10 + j * dotsX, i * dotsY, dotsX, dotsY);
                            break;

                        case 2:
                            gfx.FillRectangle(Brushes.Yellow, 10 + j * dotsX, i * dotsY, dotsX, dotsY);
                            break;
                    }
                    gfx.DrawRectangle(Pens.Black, 10 + j * dotsX, i * dotsY, dotsX, dotsY);
                }
            }

        }
    }
}