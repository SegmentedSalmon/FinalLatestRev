using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Engine
{
    public class Sprite : Actor
    {
        public Texture2D texture;
        public Color tint = Color.White;
        public Vector2 _position = Vector2.Zero;
        public float _rotation = 0.0f;
        public Rectangle spriteRectangle;
        public Nullable<Rectangle> nullRect = null;
        public Vector2 origin = Vector2.Zero;
        public float scale = 1.0f;
        public SpriteEffects _effects = SpriteEffects.None;
        public float layer = 1.0f;
        public Random rand = new Random();


        public Sprite(){} // default

        public Sprite(string Assetname, Vector2 Position, ContentManager Content)
        {
            _assetName = Assetname;
            spriteLoad(Content);
            _position = Position;
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;
           
            spriteRectangle = new Rectangle((int)_position.X, (int)_position.Y, texture.Width, texture.Height);
        }//end constructor

        public virtual void spriteLoad(ContentManager Content)
        {
            texture = Content.Load<Texture2D>(_assetName);

        }//end spriteLoad

        public virtual void updateSprite(GameTime gameTime)
        {
            spriteRectangle.X = (int)_position.X;
            spriteRectangle.Y = (int)_position.Y;
           
        
        }//end updateSprite

       
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            updateSprite(gameTime);

            spriteBatch.Draw(texture, _position, nullRect, tint, _rotation, origin, scale, _effects, layer);
           

        }//end Draw

    }//end spriteClass

}//end namespace
