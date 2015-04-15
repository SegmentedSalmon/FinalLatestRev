using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Engine
{
    public class Enemy
    {
        public int _healthPoints = 500;
        
        
        
        public int _attackDamage = 10;
        public int _healAmount = 0;
        public int _speed = 4;
        
        
        public Vector2 spritePosition;
        public Globals.Direction enemyDirection;
        public int amountMoved;
        public Sprite enemySpriteIdle;
        public SpriteSheet enemySpriteWalking;
        public Vector2 tileOn = Vector2.Zero;

        public Boolean bcanFly = false;
        public Boolean bcanAttack = true;
        public Boolean bcanMove = true;
        public Boolean isFlipped = false;
        public Boolean isMoving = false;

    }
}
