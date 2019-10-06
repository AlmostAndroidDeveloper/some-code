using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SilmeGame
{
    class Player
    {
        public PictureBox Field;
        public Point Coordinates = new Point { X = 0, Y = 0 };
        public bool HasKey = false;
        public static int MoveTick = 60;
        public static int Width = 32;
        public static int Height = 32;

        public static void MoveLeft(Player player, string[] currentMap, GameField[,] map)
        {
            if (player.Coordinates.X > 0)
                while (currentMap[player.Coordinates.Y][player.Coordinates.X - 1] != 'W')
                {
                    if (currentMap[player.Coordinates.Y][player.Coordinates.X] == 'K')
                    {
                        player.HasKey = true;
                        map[player.Coordinates.Y, player.Coordinates.X].FieldBox.Image = SlimeGame.Properties.Resources.Ground;
                    }
                    player.Field.Location = new Point { X = player.Field.Location.X - Width, Y = player.Field.Location.Y };
                    player.Coordinates = new Point { X = --player.Coordinates.X, Y = player.Coordinates.Y };
                    Thread.Sleep(MoveTick);
                    if (player.Coordinates.X == 0) break;
                }
        }

        public static void MoveDown(Player player, string[] currentMap, GameField[,] map)
        {
            if (player.Coordinates.Y < currentMap.Length - 1)
                while (currentMap[player.Coordinates.Y + 1][player.Coordinates.X] != 'W')
                {
                    if (currentMap[player.Coordinates.Y][player.Coordinates.X] == 'K')
                    {
                        player.HasKey = true;
                    }
                    player.Field.Location = new Point { X = player.Field.Location.X, Y = player.Field.Location.Y + Height };
                    player.Coordinates = new Point { X = player.Coordinates.X, Y = ++player.Coordinates.Y };
                    Thread.Sleep(MoveTick);
                    if (player.Coordinates.Y == currentMap.Length - 1) break;
                }
        }

        public static void MoveUp(Player player, string[] currentMap, GameField[,] map)
        {
            if (player.Coordinates.Y > 0)
                while (currentMap[player.Coordinates.Y - 1][player.Coordinates.X] != 'W')
                {
                    if (currentMap[player.Coordinates.Y][player.Coordinates.X] == 'K')
                    {
                        player.HasKey = true;
                        map[player.Coordinates.Y, player.Coordinates.X].FieldBox.Image = SlimeGame.Properties.Resources.Ground;
                    }
                    player.Field.Location = new Point { X = player.Field.Location.X, Y = player.Field.Location.Y - Height };
                    player.Coordinates = new Point { X = player.Coordinates.X, Y = --player.Coordinates.Y };
                    Thread.Sleep(MoveTick);
                    if (player.Coordinates.Y == 0) break;
                }
        }

        public static void MoveRight(Player player, string[] currentMap, GameField[,] map)
        {
            if (player.Coordinates.X < currentMap[0].Length - 1)
                while (currentMap[player.Coordinates.Y][player.Coordinates.X + 1] != 'W')
                {
                    if (currentMap[player.Coordinates.Y][player.Coordinates.X] == 'K')
                    {
                        player.HasKey = true;
                        map[player.Coordinates.Y, player.Coordinates.X].FieldBox.Image = SlimeGame.Properties.Resources.Ground;
                    }
                    player.Field.Location = new Point { X = player.Field.Location.X + Width, Y = player.Field.Location.Y };
                    player.Coordinates = new Point { X = ++player.Coordinates.X, Y = player.Coordinates.Y };
                    Thread.Sleep(MoveTick);

                    if (player.Coordinates.X == currentMap[0].Length - 1) break;
                }
        }
    }
}
