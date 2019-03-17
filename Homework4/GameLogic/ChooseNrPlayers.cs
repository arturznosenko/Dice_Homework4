using Homework4.GameGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class ChooseNrPlayers
    {
        private ConsoleKeyInfo _numberOfPlayers;
        private int _choice = 0;
        private bool _quit = false;
            

        public ChooseNrPlayers()
        {

            RenderOptionsActive();

            do
            {
                while (Console.KeyAvailable)

                {
                  _numberOfPlayers = Console.ReadKey(true);
                  RenderOptionsActive(Choice(_numberOfPlayers.Key));
                  Enter(_numberOfPlayers.Key);
                  Quit(_numberOfPlayers.Key);
                }
            } while (_quit == false);



        }

        public int Choice (ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow && _choice > 0)
            {
                _choice -= 1;
            }
             if (key == ConsoleKey.RightArrow && _choice < 5)
            {
                _choice += 1;
            }
             if (key == ConsoleKey.DownArrow && _choice <= 2)
            {
                _choice += 3;
            }
             if (key == ConsoleKey.UpArrow && _choice >= 3)
            {
                _choice -= 3;
            }
                return _choice;
        }

        public void Enter (ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                _quit = true;
                Console.Clear();
                ChooseNrOfDice NewChooseNrOfDice = new ChooseNrOfDice(NrOfPlayers()); 
            }
        }

        public bool Quit (ConsoleKey key)
        {
            if (key == ConsoleKey.Q)
            {
                _quit = true;
                MainMenu newMainMenu = new MainMenu();
                newMainMenu.GameStart();

            }
            return _quit;
        }

        public int NrOfPlayers ()
        {
            return _choice+2;
        }

        public void RenderSquare()
        {
            GUIWindow newGUIWindow = new GUIWindow(0, 0, 60, 20, '*', '*');
            newGUIWindow.active();
        }


        public void RenderOptionsActive(int a = 0)
        {
            
            RenderSquare();
            RenderHeader();

            if (a == 0)
            {
                 GUIWindow newGUIWindow0 = new GUIWindow(18, 5, 6, 5, '.', 'o');
                 newGUIWindow0.active();
            }
            else if (a == 1)
            {
                GUIWindow newGUIWindow1 = new GUIWindow(26, 5, 6, 5, '.', 'o');
                newGUIWindow1.active();
            }
            else if (a == 2)
            {
                GUIWindow newGUIWindow2 = new GUIWindow(34, 5, 6, 5, '.', 'o');
                newGUIWindow2.active();
            }
            else if (a == 3)
            {
                GUIWindow newGUIWindow3 = new GUIWindow(18, 10, 6, 5, '.', 'o');
                newGUIWindow3.active();
            }
            else if (a == 4)
            {
                GUIWindow newGUIWindow4 = new GUIWindow(26, 10, 6, 5, '.', 'o');
                newGUIWindow4.active();
            }
            else if (a == 5)
            {
                GUIWindow newGUIWindow5 = new GUIWindow(34, 10, 6, 5, '.', 'o');
                newGUIWindow5.active();
            }
            RenderText();
        }

        public void RenderText()
        {
            GUIText newGUIText1 = new GUIText(18, 5, 6, 5, "P2");
            GUIText newGUIText3 = new GUIText(26, 5, 6, 5, "P3");
            GUIText newGUIText5 = new GUIText(34, 5, 6, 5, "P4");
            GUIText newGUIText2 = new GUIText(18, 10, 6, 5, "P5");
            GUIText newGUIText4 = new GUIText(26, 10, 6, 5, "P6");
            GUIText newGUIText6 = new GUIText(34, 10, 6, 5, "P7");
        }

        public void RenderHeader()
        {
            GUIText Header = new GUIText(0, 0, 60, 5,  "Choose number of Players");
        }

    }
}


