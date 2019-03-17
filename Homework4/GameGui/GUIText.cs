using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.GameGui
{
    class GUIText
    {
        public GUIText (int X, int Y, int lenght, int height, string text)
        {
            int newx = X + (lenght / 2) - (text.Length / 2);
            int newy = Y + height / 2;
            Console.SetCursorPosition(newx, newy);
            Console.WriteLine(text);
        }
    }
}
