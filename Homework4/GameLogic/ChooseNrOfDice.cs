using Homework4.GameGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class ChooseNrOfDice
    {
        private ConsoleKeyInfo _numberOfDiceKey;
        private bool _quit = false;
        private int _numberOfDice = 3;
        private int _numberOfPlayers;

        public ChooseNrOfDice ( int NumberOfPlayers)
        {
            _numberOfPlayers = NumberOfPlayers;
            RenderSquare();
            RenderHeader();
            do
            {
                while (Console.KeyAvailable)

                {
                    _numberOfDiceKey = Console.ReadKey(true);
                    AdjNumberofDice(_numberOfDiceKey.KeyChar);
                    Enter(_numberOfDiceKey.Key);
                    Quit(_numberOfDiceKey.Key);
                }

            } while (_quit == false);

            

        }

        public void AdjNumberofDice (char key)
        {
            if (key == '+' && _numberOfDice < 10)
            {
                Console.Clear();
                RenderSquare();
                RenderHeader();
                GUIText Header = new GUIText(0, 0, 60, 20, $"Player will have {_numberOfDice += 1} dice");
                
            }
            else if (key == '-' && _numberOfDice > 1)
            {
                Console.Clear();
                RenderSquare();
                RenderHeader();
                GUIText Header = new GUIText(0, 0, 60, 20, $"Player will have {_numberOfDice -= 1} dice");
            }
            
        }

        public void Quit (ConsoleKey key)
        {
            if (key == ConsoleKey.Q)
            {
                _quit = true;
                ChooseNrPlayers NewChooseNrPlayers = new ChooseNrPlayers();
            }
            
        }
        public void Enter(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                _quit = true;
                Console.Clear();
                Console.WriteLine("Start Game");
                Game newgame = new Game(_numberOfPlayers, NumberOfDice());  
            }

        }

        public int NumberOfDice()
        {
            return _numberOfDice;

        }

        public void RenderHeader()
        {
            GUIText Header = new GUIText(0, 0, 60, 5, "Choose number of Dices");
            GUIText DicesText = new GUIText(0, 0, 60, 20, "Player will have 3 dice");
        }

        public void RenderSquare()
        {
            GUIWindow newGUIWindow = new GUIWindow(0, 0, 60, 20, '*', '*');
            newGUIWindow.active();
        }

    }
}
