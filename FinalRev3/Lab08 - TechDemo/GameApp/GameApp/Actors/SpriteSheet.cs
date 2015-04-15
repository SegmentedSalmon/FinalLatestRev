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
    public class SpriteSheet:Sprite
    {
       
        Rectangle newRectangle;
        public int rows = 0;
        public int columns = 0;
        public  int _width = 0;
        public int _height = 0;
        public int  cRow = 0;
        public int  cColumn = 0;
        float timeSinceLastUp = 0;
        float timePerFrame = 0;


        public SpriteSheet() { }//default

        public SpriteSheet(string assetName, int _rows, int _columns, Vector2 position,float animationSpeed, ContentManager Content) 
        {
            timePerFrame = animationSpeed;
            _assetName = assetName;
            _position = position;
            spriteLoad(Content);
            rows = _rows;
            columns = _columns;
            _width = texture.Width / columns;
            _height = texture.Height / rows;
          
            newRectangle = new Rectangle(0, 0, _width, _height);
            origin.X = newRectangle.Width / 2;
            origin.Y = newRectangle.Height / 2;

        }//end constructor

        public override void updateSprite(GameTime gameTime)
        {

            timeSinceLastUp += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastUp > timePerFrame)
            {
                cColumn++;

                if (cColumn >= columns)
                {
                    cColumn = 0;
                    cRow++;
                }
                if (cRow >= rows)
                {
                    cColumn = 0;
                    cRow = 0;
                }

                newRectangle = new Rectangle((_width * cColumn), (_height * cRow), _width, _height);
                timeSinceLastUp = 0;
            }

        }//end updateSprite

        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //updateSprite(gameTime);
            spriteBatch.Draw(texture, _position, newRectangle, tint, _rotation, origin, scale, _effects, layer);
        }//end Draw



    }//end spritesheet class
}//end namespace
