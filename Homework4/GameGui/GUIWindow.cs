using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.GameGui
{
    class GUIWindow
    {
        private int _x;
        private int _y;
        private int _lenght;
        private int _height;
        private char _charinactive;
        private char _charactive;

        public GUIWindow(int X, int Y, int lenght, int height, char charinactive, char charactive)
        {
            _x = X;
            _y = Y;
            _lenght = lenght;
            _height = height;
            _charinactive = charinactive;
            _charactive = charactive;
        }

        public void Render(char _renderchar)

        {
            for (int j = 0; j < _height; j++)
            {
                Console.SetCursorPosition(_x, _y + j);
                Console.Write(_renderchar);
                for (int i = 0; i < _lenght; i++)
                {
                    if (j == 0 || j == (_height - 1))
                    {
                        Console.Write(_renderchar);
                    }

                    else if (i == (_lenght - 1))
                    {
                        Console.Write(_renderchar);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        public void inactive()
        {
                Render(_charinactive);
        }

        public void active()
        {
                Render(_charactive);
        }
    }
}
