using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager4
{
    
    public class Player : IComparable<Player>
    {
        private static int sort;

        public static int GetSort() => sort;
        public static void SetSort(int set)
        {
            sort = set;
        }


        public string Name { get; }

        public int Score { get; set; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        static Player()
        {
            sort = 0;
        }

        public int CompareTo(Player other)
        {
            if (other==null) return 1;

            return other.Score - this.Score;
        }
    }
}