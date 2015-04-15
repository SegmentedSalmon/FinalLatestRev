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
    public class Actor
    {

       public Boolean _isActive = true;
      
       public string _assetName = "";
       

        public Actor() { }//default

        public Actor(string assetName)
        {
            _assetName = assetName;
            
        }//end constructor

        public Actor getActor()
        {

            return this;
        }//end getActor

        public virtual void actorLoad(ContentManager Content)
        {
           

        }//end actorload

        public virtual void actorUpdate()
        {

        }//end actorUpdate

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            

        }//end draw

    }//end actor class
}//end namespace
