using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SilmeGame
{
    class GameField : PictureBox
    {
        public enum State
        {
            Wall,
            Exit,
            NotWall,
            Spawn
        }
        public bool HasKey;
        public static int Width = 32;
        public static int Height = 32;
        public PictureBox FieldBox = new PictureBox();

        public State FieldState;

        public static Bitmap GetFieldBackdround(string[] currentMap, int rows, int columns)
        {
            return currentMap[rows][columns].Equals('E') ? SlimeGame.Properties.Resources.Door :
                   currentMap[rows][columns].Equals('S') ? SlimeGame.Properties.Resources.Door :
                   currentMap[rows][columns].Equals('W') ? SlimeGame.Properties.Resources.Wall :
                   currentMap[rows][columns].Equals(' ') ? SlimeGame.Properties.Resources.Ground :
                   currentMap[rows][columns].Equals('K') ? SlimeGame.Properties.Resources.Ground :
                   SlimeGame.Properties.Resources.Ground;
        }
        public static Bitmap GetKey(string[] currentMap, int rows, int columns)
        {
            return currentMap[rows][columns].Equals('K') ? SlimeGame.Properties.Resources.Key : null;
        }

        public static State GetFieldState(string[] currentMap, int rows, int columns)
        {
            return currentMap[rows][columns].Equals('E') ? State.Exit :
                   currentMap[rows][columns].Equals('S') ? State.Spawn :
                   currentMap[rows][columns].Equals('W') ? State.Wall :
                   currentMap[rows][columns].Equals('N') ? State.NotWall
                   : State.NotWall;

        }

        public static GameField[,] CreateMap(string[] currentMap) // из карты символов делаем норм карту
        {
            var fields = new GameField[currentMap.Length, currentMap[0].Length];
            for (int rows = 0; rows < currentMap.Length; rows++)
                for (int columns = 0; columns < currentMap[0].Length; columns++)
                {
                    fields[rows, columns] = new GameField
                    {
                        Location = new Point { X = columns * Width, Y = rows * Height },
                        Size = new Size { Width = Width, Height = Height },
                        BackgroundImage = GetFieldBackdround(currentMap, rows, columns),
                        FieldState = GetFieldState(currentMap, rows, columns),
                        Image = GetKey(currentMap, rows, columns)
                    };
                }
            return fields;
        }
    }
}
