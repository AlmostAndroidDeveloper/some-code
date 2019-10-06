using SlimeGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SilmeGame
{
    public partial class Form1 : Form
    {
        const int EM_LINESCROLL = 0x00B6;
        const int SB_HORZ = 0;
        const int SB_VERT = 1;
        public int mapCount = 0;
        // скролл текста при отсутствии фокуса на элементе
        [DllImport("user32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //
        public static List<string[]> mapsList = new List<string[]>()
        {
            Maps.First, Maps.Second,Maps.Third,Maps.Fourth,Maps.Fifth
        };

        private GameField[,] map;

        Player player;
        bool isPlatePressed;

        public Form1()
        {
            InitializeComponent();
            InitializePlayer();
            InitializeMap();
            MainText.Text += Phrases.Starting + Environment.NewLine;
            ScrollMainText();
            Update();
            MessageBox.Show(Phrases.Starting);
        }

        public void InitializeMap()
        {
            isPlatePressed = false;
            if (mapCount < 0) { mapCount = 0; return; }
            if (mapCount > mapsList.Count - 1) { mapCount = mapsList.Count - 1; return; }
            if (map != null)
                for (int i = 0; i < map.GetLength(0); i++)
                    for (int j = 0; j < map.GetLength(1); j++)
                        Controls.Remove(map[i, j]);
            map = GameField.CreateMap(mapsList[mapCount]);
            for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                    Controls.Add(map[i, j]);
        }

        public void InitializePlayer()
        {
            if (player != null) Controls.Remove(player.Field);
            player = new Player
            {
                Field = new PictureBox
                {
                    Location = new Point { X = 0, Y = 0 },
                    Size = new Size { Width = Player.Width, Height = Player.Height },
                    Image = SlimeGame.Properties.Resources.Slime

                },
                Coordinates = new Point { X = 0, Y = 0 }
            };
            Controls.Add(player.Field);
        }

        public void InitializeMapAndPlayer()
        {           
            
           
        }

        public void CheckIsExit()
        {
            if (mapsList[mapCount][player.Coordinates.X][player.Coordinates.Y] == 'E' && player.HasKey)
            {
                MainText.Text += Phrases.MovingToNextLevel + (mapCount + 2).ToString() + "..." + Environment.NewLine;
                ScrollMainText();
                if (mapCount == mapsList.Count - 1) mapCount = -1;
                mapCount++;
                InitializeMapAndPlayer();

            }
            if (mapsList[mapCount][player.Coordinates.X][player.Coordinates.Y] == 'E' && !player.HasKey)
            {
                MainText.Text += Phrases.ExitClosed + Environment.NewLine;
                ScrollMainText();
            }
            if (!isPlatePressed && player.HasKey)
            {
                MainText.Text += Phrases.PullingTheLever + Environment.NewLine;
                ScrollMainText();
                isPlatePressed = true;
            }

        }

        public void MakeKey()
        {
            for (int i = 0; i < mapsList[mapCount].Length; i++)
                for (int j = 0; j < mapsList[mapCount].Length; j++)
                {
                    if (mapsList[mapCount][i][j].Equals('K'))
                        map[i, j].FieldBox.Image = SlimeGame.Properties.Resources.Key;
                }
        }

        private void ScrollMainText()
        {
            SetScrollPos(MainText.Handle, SB_VERT, MainText.Lines.Length - 1, true);
            SendMessage(MainText.Handle, EM_LINESCROLL, 0, MainText.Lines.Length - 1);
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            Player.MoveUp(player, mapsList[mapCount], map);
            CheckIsExit();
        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            Player.MoveLeft(player, mapsList[mapCount], map);
            CheckIsExit();
        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {

            Player.MoveRight(player, mapsList[mapCount], map);
            CheckIsExit();
        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            Player.MoveDown(player, mapsList[mapCount], map);
            CheckIsExit();
        }

        private void RestartLevelButton_Click(object sender, EventArgs e)
        {
            MainText.Text += Phrases.RestartingLevel + (mapCount + 1).ToString() + Environment.NewLine;
            ScrollMainText();
            InitializeMapAndPlayer();
        }

        private void PassLevelButton_Click(object sender, EventArgs e)
        {
            MainText.Text += Phrases.MovingToNextLevel + (mapCount + 2).ToString() + "..." + Environment.NewLine;
            ScrollMainText();
            mapCount++;
            InitializeMapAndPlayer();
        }
    }
}
