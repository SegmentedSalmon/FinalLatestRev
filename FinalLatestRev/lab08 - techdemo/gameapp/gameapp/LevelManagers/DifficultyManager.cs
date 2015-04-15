using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class DifficultyManager
    {
        Player p1, p2, p3, p4;


        public DifficultyManager() { }

        public DifficultyManager(Player playerOne, Player playerTwo, Player playerThree, Player playerFour)
        {
            p1 = playerOne;
            p2 = playerTwo;
            p3 = playerThree;
            p4 = playerFour;
            
        }
    }
}
