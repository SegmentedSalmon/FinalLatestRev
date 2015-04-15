using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public static class Globals
    {
        public const int TILE_SIZE = 64;

        public enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT

        };
        public enum PlayerState
        {
            WALKING,
            IDLE,
            ATTACKING,
            DEAD
        };
        public enum playerColor
        {
            BLUE,
            GREEN,
            RED,
            YELLOW
        };

    }//end globals class
}//end namespace
