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
    public class Player
    {
        public string _typePicked = "";
        public string _PlayerIndex = "";
        public int _healthPoints = 500;
        public int _manaPoints = 50;
        public float _manaRegen = 0.02f;
        public float _defense = 0.9f;
        public int _attackDamage = 10;
        public int _healAmount = 0;
        public int _speed = 4;
        public int _specialManaCost = 100;
        public float _critChance = 0.03f;
        public Vector2 spritePosition;
        public Globals.Direction playerDirection;
        public Globals.PlayerState playerState;
        public int amountMoved;
        public PlayerIndex _index;
        public KeyboardState _cKey, _pKey;
        public GamePadState _cCont, _pCont;
        public Sprite classSpriteIdle;
        public Sprite classSpriteAttack;
        public SpriteSheet classSpriteWalking;
        public Vector2 tileOn = Vector2.Zero;
        
        public Boolean bcanFly = false;
        public Boolean bcanAttack = true;
        public Boolean bcanMove = true;
        public Boolean bisDead = false;
        public Boolean bcanUseSpecial = true;
        public Boolean bcanPierce = false;
        public Boolean bcanBeBuffed = true;
        public Boolean isFlipped = false;
        public Boolean isMoving = false;
        


        public Player() { }

        public Player(string type, string index)
        {
            _typePicked = type;
            _PlayerIndex = index;

        }//end constructor

        public virtual void regularAttack()
        {


        }//end regularAttack

        public virtual void specialAbility()
        {


        }//end specialAbility

     
        public virtual void updateHP()
        {


        }//end updateHP

        public virtual void updateMP()
        {


        }//end updateMP

        public void getTileOn()
        {
            int xPos,yPos;
            xPos = (int)spritePosition.X / 64;
            yPos = (int)spritePosition.Y / 64;
            tileOn.X = xPos;
            tileOn.Y = yPos;
        }

        public virtual void updatePadState(GamePadState cCont)
        {
            _cCont = cCont;
        }

        public void updateControls()
        {
            
            if (_pCont == null)
            {
                _pCont = _cCont;
            }
            if (!isMoving)
            {

                if ((_cCont.Buttons.A == ButtonState.Pressed) &&
                  (_pCont.Buttons.A == ButtonState.Released))
                {
                    regularAttack();
                }
                /////
                if ((_cCont.DPad.Right == ButtonState.Pressed)||(_cCont.ThumbSticks.Left.X > .15))
                {
                    
                    playerDirection = Globals.Direction.RIGHT;
                    isMoving = true;
                }
                ////
                if ((_cCont.DPad.Left == ButtonState.Pressed)||(_cCont.ThumbSticks.Left.X < -.15))
                {
                    playerDirection = Globals.Direction.LEFT;
                    isMoving = true;
                   
                }
                ////
                if ((_cCont.DPad.Down == ButtonState.Pressed)||(_cCont.ThumbSticks.Left.Y < -.15))
                {
                    playerDirection = Globals.Direction.DOWN;
                    isMoving = true;
                }
                ////
                if ((_cCont.DPad.Up == ButtonState.Pressed)||(_cCont.ThumbSticks.Left.Y > .15))
                {
                    playerDirection = Globals.Direction.UP;
                    isMoving = true;

                }

            }//end if isnotMoving
            _pCont = _cCont;

        }//end updateControls


        public virtual void playerUpdate(GameTime gameTime)
        {
            _cCont = GamePad.GetState(_index);
            _cKey = Keyboard.GetState();
           
            updateControls();
            
            if (!isMoving)
            {
                playerState = Globals.PlayerState.IDLE;
                if (_cKey.IsKeyDown(Keys.Left))
                {

                    playerDirection = Globals.Direction.LEFT;
                    isMoving = true;
                }//end if keysLeft
                if (_cKey.IsKeyDown(Keys.Right))
                {

                    playerDirection = Globals.Direction.RIGHT;
                    isMoving = true;
                }//end if keysRight
                if (_cKey.IsKeyDown(Keys.Up))
                {
                    playerDirection = Globals.Direction.UP;
                    isMoving = true;
                }//end if keysUp
                if (_cKey.IsKeyDown(Keys.Down))
                {
                    playerDirection = Globals.Direction.DOWN;
                    isMoving = true;
                }//end if keysDown
            }//end if not isMoving

            if (isMoving)
            {
                amountMoved += _speed;
                playerState = Globals.PlayerState.WALKING;
                switch (playerDirection)
                {
                    case Globals.Direction.RIGHT:
                        {
                            if ((spritePosition.X + 32) + _speed > 1920)
                            {

                            }
                            else
                            {

                                spritePosition.X += _speed;

                                if (isFlipped)
                                {
                                    classSpriteWalking._effects = SpriteEffects.None;
                                    classSpriteIdle._effects = SpriteEffects.None;
                                    isFlipped = !isFlipped;
                                }//end isFlipped
                            }
                            break;
                        }//end case RIGHT
                    case Globals.Direction.LEFT:
                        {
                            if ((spritePosition.X - 32) - _speed < 0)
                            {

                            }
                            else
                            {
                                spritePosition.X -= _speed;

                                if (!isFlipped)
                                {
                                    classSpriteWalking._effects = SpriteEffects.FlipHorizontally;
                                    classSpriteIdle._effects = SpriteEffects.FlipHorizontally;
                                    isFlipped = !isFlipped;
                                }//end isnot flipped
                            }
                            break;
                        }//end case LEFT
                    case Globals.Direction.UP:
                        if ((spritePosition.Y - 32) - _speed < 0)
                        {

                        }
                        else
                        {
                            spritePosition.Y -= _speed;
                        }
                        break;
                    case Globals.Direction.DOWN:
                        if ((spritePosition.Y + 32) + _speed > 1280)
                        {

                        }
                        else
                        {
                            spritePosition.Y += _speed;
                        }
                        break;
                }//end switch playerDirection

                if (amountMoved >= Globals.TILE_SIZE)
                {
                    amountMoved = 0;
                    isMoving = false;
                }//end if
            }//end if isMoving

            classSpriteIdle._position = spritePosition;
            classSpriteWalking._position = spritePosition;
            getTileOn();
            //Console.WriteLine(tileOn);


            _pKey = _cKey;

            classSpriteWalking.updateSprite(gameTime);

        }//end playerUpdate

        public virtual void playerDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            switch (playerState)
            {

                case Globals.PlayerState.IDLE:
                    {
                        classSpriteIdle.Draw(gameTime, spriteBatch);
                        break;
                    }
                case Globals.PlayerState.WALKING:
                    {
                        classSpriteWalking.Draw(gameTime, spriteBatch);
                        break;
                    }
                case Globals.PlayerState.ATTACKING:
                    {
                        classSpriteAttack.Draw(gameTime, spriteBatch);
                        break;
                    }


            }
      

        }//end playerdraw
            
    }//end player class
}//end namespace