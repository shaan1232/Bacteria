using System;
using System.Drawing;
using System.Windows.Forms;
//using System.Drawing.Color;

namespace Bacteria
{


    class Game
    {

        public const int windowWidth = 1300;
        public const int windowHeight = 900;
        public const int boardColumns = 15;
        public const int boardRows = 15;
        public static int[,] board = new int[boardColumns, boardRows];


        public static void runGame(int numPlayers)
        {
            initPlayers(numPlayers);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Size(windowWidth, windowHeight);
            Application.Run(new MyForm());
            Form1.Size = new Size(windowWidth, windowHeight);
        }

        public static void initPlayers(int numPlayers)
        {
            int a = 0, b = a, c = a, d = c, e = c;

            Random rand = new Random();

            for (int i = 0; i < boardColumns; i++)
            {
                for (int j = 0; j < boardRows; j++)
                {
                    board[i, j] = rand.Next(numPlayers);
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
            int numPlayers = 3;

            runGame(numPlayers);

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

        public MyForm()
        {

            Game game = new Game();
            int[,] board = game.getBoard();

            //  for (int i =)

            //InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            int dotWidth = game.boardRows; // size of pixel width
            int dotLength; // sizes of pixels dotLength

            base.OnPaint(e);

            Graphics gfx = e.Graphics;
            Pen p = new Pen(myColors[1]);
            p.Color = myColors[1];
            //  gfx.DrawRectangle(Pens.Black, 10f, 10f, 10f, 10f);
            gfx.DrawRectangle(Pens.Black, 10f, 50f, 20f, 20f);
            gfx.FillRectangle(Brushes.Red, 10f, 50f, 20f, 20f);
            gfx.DrawRectangle(Pens.Black, 30f, 50f, 20f, 20f);
            gfx.FillRectangle(Brushes.Blue, 30f, 50f, 20f, 20f);

        }
    }
}