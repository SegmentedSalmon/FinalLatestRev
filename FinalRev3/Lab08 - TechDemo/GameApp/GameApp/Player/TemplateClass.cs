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
    public class TemplateClass : Player
    {

        private string walkingAsset = "playerSprites/blue/HuntressWalking";
        private string idleAsset = "playerSprites/blue/Huntress";
        
        public TemplateClass() { }//default

        public TemplateClass(GamePadState cCont, GamePadState pCont, string index, ContentManager _Content) 
        {

            _cCont = cCont;
            _pCont = pCont;

            classSpriteWalking = new SpriteSheet(walkingAsset,1,2,new Vector2(96,96),140, _Content);
            classSpriteIdle = new Sprite(idleAsset, new Vector2(96, 160), _Content);
            spritePosition = classSpriteIdle._position;

            //Getting the Index of player, to match the controller appropriately
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

    }
}
