﻿using System;
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
    public class Huntress : Player
    {

        public int _attackRadius = 100;

        public Huntress() { }//default

        public Huntress(GamePadState cCont, GamePadState pCont, string index, ContentManager _Content)
        {

            _cCont = cCont;
            _pCont = pCont;

            _PlayerIndex = index;

            _healthPoints = 600;
            _manaPoints = 600;
            _manaRegen = .1f;
            _defense = .8f;
            _attackDamage = 50;
            _speed = 4;
            _specialManaCost = 100;
            _critChance = .05f;
            classSpriteWalking = new SpriteSheet("playerSprites/yellow/HuntressWalking", 1, 2, new Vector2(96, 96), 140, _Content);
            classSpriteIdle = new Sprite("playerSprites/yellow/Huntress", new Vector2(96, 96), _Content);
            spritePosition = classSpriteIdle._position;

            if (index == "One")
            {
                _index = PlayerIndex.One;

            }
            else if (index == "Two")
            {
                _index = PlayerIndex.Two;

            }
            else if (index == "Three")
            {
                _index = PlayerIndex.Three;

            }
            else if (index == "Four")
            {
                _index = PlayerIndex.Four;

            }

        }//end constructor

        public override void regularAttack()
        {


        }//end regularAttack

      

    }//end Huntress class

}//end namespace

