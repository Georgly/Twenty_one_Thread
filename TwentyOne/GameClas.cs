using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class GameClas
    {
        const int playersCount = 3;
        int playerFinish = 0;
        Player winPlayer;
        string hands = "";
        Croupier croupier = new Croupier();
        Player[] players = new Player[playersCount];

        public GameClas()
        {
            Play();
        }

        void Play()
        {
            for (int i = 0; i < playersCount; i++)
            {
                players[i] = new Player(croupier, i + 1);
                players[i].StopEvent += PlayerStop;
                players[i].Lose += PlayerLose;
                players[i].FinishEvent += PlayerFinish;
            }

            Console.ReadKey();
        }

        void PlayerStop(Player player)
        {
            playerFinish++;
            if (winPlayer == null)
            {
                winPlayer = player;
            }
            else
            {
                winPlayer = (winPlayer.Score > player.Score) ? winPlayer : player;
            }
            Console.WriteLine("Игрок {0} составил руку", player.Name);
            hands += player.ShowHand() + "\n";
            FinishGame();
            player.StopThread();
        }

        void PlayerLose(Player player)
        {
            playerFinish++;
            Console.WriteLine("Игрок {0}: <<Перебор!>>", player.Name);
            player.PrintHand();
            FinishGame();
            player.StopThread();
        }

        void PlayerFinish(Player player)
        {
            player.PrintHand();
            Console.WriteLine("Игрок {0} набрал 21", player.Name);
            foreach (Player man in players)
            {
                man.StopThread();
            }
        }

        void FinishGame()
        {
            if (playerFinish == playersCount)
            {
                Console.WriteLine("Имя выигравшего игрока: " +
                    (winPlayer != null ? winPlayer.Name.ToString() : "все слились"));
                Console.WriteLine(hands);
            }
        }
    }
}
