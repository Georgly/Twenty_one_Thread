using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class GameClas
    {
        int playerFinish = 0;
        Player winPlayer;
        string hands = "";

        void Play()
        {
            Croupier croupier = new Croupier();
            Player[] players = new Player[3];
            for (int i = 0; i < 3; i++)
            {
                players[i] = new Player(croupier, i + 1);
                players[i].StopEvent += PlayStop;
            }

            Console.ReadKey();
        }

        void PlayerStop(Player player)
        {
            playerFinish++;
            player.StopThread();
            if (winPlayer == null)
            {
                winPlayer = player;
            }
            else
            {
                winPlayer = (winPlayer.Score > player.Score) ? winPlayer : player;
            }
            hands += player.ShowHand() + "\n";
            if (playerFinish == 3)
            {
                Console.WriteLine("Имя выигравшего игрока: " +
                    (winPlayer != null ? winPlayer.Name.ToString() : "все слились"));
            }
        }

        public void PlayerLose(Player player)
        {
            playerFinish++;
            player.StopThread();
            Console.WriteLine("Игрок {0}: <<Перебор!>>", player.Name);
            player.PrintHand();
        }
    }
}
