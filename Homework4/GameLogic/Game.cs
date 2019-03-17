using Homework4.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Game
    {
        private int _NrofPlayrs;
        private int _NrOfDices;
        private Player _Winner;
        private List<Player> _listOfPlayers; 
        private List<Player> gameresults;
        private List<Player> listwithmaxresult;

        public Game (int NrofPlayrs, int NrOfDices)
        {
            _NrofPlayrs = NrofPlayrs;
            _NrOfDices = NrOfDices;
            
            _listOfPlayers = ListOfPlayers(NrofPlayrs);

            _Winner = Winner(_listOfPlayers);
         

          Console.WriteLine("WINNER is Player ID " + _Winner.PlayerID + " Result of Game " + _Winner.ResultOfGame + " Dice Drops " + _Winner.DiceDrops);
          Console.WriteLine("Press any key... ");
          Console.ReadKey();
          GameOverMenu newGameOverMenu = new GameOverMenu(_Winner, NrofPlayrs, NrOfDices);


        }

        public List<Player> ListOfPlayers (int numplayers)
        {
            List<Player> ResultList = new List<Player>();
            for (int i = 1; i <= numplayers; i++)
            {
                ResultList.Add(new Player() { PlayerID = i});
            }
            return ResultList;
        }

    
        public List<Player> Play (List<Player> ListOfPlayers, int NrOfDices)
        {
            Random number = new Random();
            List<Player> PlayResultList = new List<Player>();


            foreach (Player i in ListOfPlayers)
            {
                int sum = 0;
                string drop = " ";
                Console.WriteLine("Player ID " + i.PlayerID);
                for (int j = 1; j <= NrOfDices; j++)
                {
                    int a = number.Next(1, 6);
                    Console.WriteLine("Number of Dices " + a);
                    sum = sum + a;
                    drop = drop + " " + a;
                }
                Console.WriteLine(sum);
                PlayResultList.Add(new Player() { PlayerID = i.PlayerID, ResultOfGame = sum, DiceDrops = drop });
                
            }
            return PlayResultList;
        }



        public int MaxResult (List<Player> gameresults)
        {
            int maxresult = (from x in gameresults
                             group x by x.ResultOfGame).Max(x => x.Key);

            return maxresult;
        }
       
        public List<Player> ListOfPlayersWithMaxResult (List<Player> gameresults)

        {
            var listwithmaxresult = (from x in gameresults
                                     where x.ResultOfGame == MaxResult(gameresults)
                                     select x).ToList();
            return listwithmaxresult;
        }

        public Player Winner(List<Player> list)
        {
            int round = 0;

          
                List<Player> replyresult;
                do
                {
                    Console.WriteLine("Round " + (round +=1));
                    replyresult = Play(list, _NrOfDices);
                    list = ListOfPlayersWithMaxResult(replyresult);
                            if (list.Count > 1)
                            {
                                Console.WriteLine("Winner(s) for round " + round + ":");
                                list.ForEach(x => Console.WriteLine($" Player {x.PlayerID} with {x.ResultOfGame} and Dice dropped {x.DiceDrops}"));
                            }
                }
                while (list.Count > 1);

                _Winner = ListOfPlayersWithMaxResult(replyresult).Single();

            return _Winner;
        }

    }
}
