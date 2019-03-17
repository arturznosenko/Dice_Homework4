using Homework4.GameGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class MainMenu
    {
        private ConsoleKeyInfo _pressedChar;
        private bool _quit = false;

        public MainMenu()
        {
            
        }


        public void GameStart ()
        {

            RenderSquare();
            RenderText();

            do
            {
                while (Console.KeyAvailable)
                {
                    _pressedChar = Console.ReadKey(true);
                    Play(_pressedChar.Key);
                    Quit(_pressedChar.Key);
                }
            }
            while (_quit == false);

        }

        public void Play(ConsoleKey key)
        {
            if (key == ConsoleKey.P)
            {
                _quit = true;
                Console.Clear();
                ChooseNrPlayers NewChooseNrPlayers = new ChooseNrPlayers();
            }

        }

        public void Quit(ConsoleKey key)
        {
            if (key == ConsoleKey.Q)
            {
                _quit = true;
            }

        }


        public void RenderText()
        {
            GUIText newGUIText = new GUIText(0, 0, 60, 20, "Press P for play and Q for Quit");
        }

        public void RenderSquare()
        {
            GUIWindow newGUIWindow = new GUIWindow(0, 0, 60, 20, '*' , '*');
            newGUIWindow.inactive();
        }
    }
}
