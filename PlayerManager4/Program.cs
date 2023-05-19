using System;
using System.Collections.Generic;

namespace PlayerManager4
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        private List<Player> playerList;

        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
        {
            // Create a new instance of the player listing program
            Program prog = new Program();
            // Start the program instance
            prog.Start();
        }

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        private Program()
        {
            // Initialize the player list with two players using collection
            // initialization syntax
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
            playerList.Sort();
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        private void Start()
        {

            // We keep the user's option here
            string option;
            // Main program loop
            do
            {
                // Show menu and get user option
                ShowMenu();
                option = Console.ReadLine();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        ChangeSorting();
                        break;
                    case "5":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Wait for user to press a key...
                Console.Write("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine("\n");

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "5");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            string sorting = Player.GetSort() switch
            {
                0 => "Score",
                1 => "Name, ascending",
                -1 => "Name, descending",
                _ => "Error",
            };
            Console.WriteLine("Select your option:");
            Console.WriteLine(" |1| - Insert new player;");
            Console.WriteLine(" |2| - See player list;");
            Console.WriteLine(" |3| - See players above a certain score;");
            Console.WriteLine($" |4| - Change player sorting method (current:{sorting});");
            Console.WriteLine(" |5| - Quit.");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            Console.WriteLine("Insert player name:");
            string newName = Console.ReadLine();
            Console.WriteLine("Insert player score:");
            int newScore = int.Parse(Console.ReadLine());

            playerList.Add(new Player(newName, newScore));

            SortBy();
        }

        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            foreach (Player p in playersToList)
            {
                Console.WriteLine($"{p.Name} - Score: {p.Score}");
            }
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            IEnumerable<Player> goodPlayers;

            Console.WriteLine("Insert baseline score:");
            int baseScore = int.Parse(Console.ReadLine());

            goodPlayers = GetPlayersWithScoreGreaterThan(baseScore);
            ListPlayers(goodPlayers);
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player p in playerList)
            {
                if (p.Score > minScore)
                {
                    yield return p;
                }
            }
        }
        private void ChangeSorting()
        {
            string selection;
            Console.WriteLine("Select sorting method:");
            Console.WriteLine(" |1| - By score (descending);");
            Console.WriteLine(" |2| - By player name (ascending);");
            Console.WriteLine(" |3| - By player name (descending).");

            selection = Console.ReadLine();

            // Determine the option specified by the user and act on it
            switch (selection)
            {
                case "1":
                    Player.SetSort(0);
                    break;
                case "2":
                    Player.SetSort(1);
                    break;
                case "3":
                    Player.SetSort(-1);
                    break;
                default:
                    Console.WriteLine(" Unknown option - " +
                    "Defaulting to sorting by score.");
                    Player.SetSort(0);
                    break;
            }
            SortBy();
        }
        private void SortBy()
        {

            if (Player.GetSort() == 0)
            {
                playerList.Sort();
            }
            else if (Player.GetSort() == 1)
            {
                IComparer<Player> ascending = new CompareByName(true);
                playerList.Sort(ascending);
            }
            else
            {
                IComparer<Player> descending = new CompareByName(false);
                playerList.Sort(descending);
            }

        }
    }
}