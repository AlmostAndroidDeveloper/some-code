using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeGame
{
    public class Phrases
    {
        public static string Starting = @"
Ваш герой - кучка разумной слизи, которая угодила в подземный лабиринт.
Ваша задача - выбраться из него, пройдя все уровни. 
Используйте спосбность слизи прилипать от стены к стене, чтобы добраться до выхода.";
        public static string MovingToNextLevel = "Переход на уровень ";
        public static string RestartingLevel = "Перезапуск уровня ";
        public static string PullingTheLever = "Нажимная плита активирована. Выход открыт.";
        public static string ExitClosed = "Выход закрыт! Встаньте на нажимную плиту, чтобы открыть выход.";

    }
}