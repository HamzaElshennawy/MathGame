using System;
using System.Collections.Generic;
using System.Text;

namespace Math_Game
{
    public class NumberGenerator
    {
        public int first { get; set; }
        public int second { get; set; }
        public int sum { set; get; }
        public int SuccededTimesInARow { get; set; }
        public int score { set; get; }

        public NumberGenerator()
        {
            Random rand = new Random();
            first = rand.Next(2, 9);
            second = rand.Next(2, 9);
            sum = first * second;
            SuccededTimesInARow = 0;
            score = 0;
        }
    }
}
