using Homework4.GameGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.GameLogic
{
    class GameOverMenu
    {
        private bool _quit = false;
        private int _nrOfPlayers;
        private int _nrOfDices;
        private ConsoleKeyInfo _gameOverMenuChoice;

        public GameOverMenu (Player _winner, int NrOfPlayers, int NrOfDices)
        {
            _nrOfPlayers = NrOfPlayers;
            _nrOfDices = NrOfDices;
            Console.Clear();
            RenderSquare();
            RenderHeader();
            Winner(_winner);
            GameOverMenuChoices();

           do
            {
                while (Console.KeyAvailable)

                {
                    _gameOverMenuChoice = Console.ReadKey(true);
                    Quit(_gameOverMenuChoice.Key);
                    MainMenu(_gameOverMenuChoice.Key);
                    Reply(_gameOverMenuChoice.Key);
                    
                }

            } while (_quit == false);
        }

        public void Quit(ConsoleKey key)
        {
            if (key == ConsoleKey.Q)
            {
                _quit = true;
                
            }
        }

        public void MainMenu(ConsoleKey key)
        {
            if (key == ConsoleKey.M)
            {
                _quit = true;
                MainMenu newMainMenu = new MainMenu();
                newMainMenu.GameStart();
            }
        }

        public void Reply(ConsoleKey key)
        {
            if (key == ConsoleKey.R)
            {
                _quit = true;
                Console.Clear();
                Game newgame = new Game(_nrOfPlayers, _nrOfDices);
            }
        }


        public void RenderSquare()
        {
            GUIWindow newGUIWindow = new GUIWindow(0, 0, 60, 20, '*', '*');
            newGUIWindow.active();
        }

        public void RenderHeader()
        {
            GUIText Header = new GUIText(0, 0, 60, 8, "Game is Finished");
        }

        public void Winner(Player a)
        {
            GUIText Winner1 = new GUIText(0, 0, 60, 20, $"Winner is Player {a.PlayerID} with result {a.ResultOfGame}");
            GUIText Winner2 = new GUIText(0, 1, 60, 20, $"Dices dropped: {a.DiceDrops}");
        }

        public void GameOverMenuChoices()
        {
            GUIText Header = new GUIText(0, 0, 60, 30, "Press R - Replay same, M - Go to menu. Q - Quit.");
        }
    }


}
