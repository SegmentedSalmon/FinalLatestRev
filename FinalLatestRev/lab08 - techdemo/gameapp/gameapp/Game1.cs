using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Engine
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameLevel Map;
        Sprite Border;
        Viewport defaultView;
        
        List<Player> playerList;
        List<Viewport> viewportList;
        List<Camera> cameraList;
        List<GamePadState> gamePadStateList;

        GamePadState cPlayer1, pPlayer1, cPlayer2, pPlayer2, cPlayer3, pPlayer3, cPlayer4, pPlayer4;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1680;
            graphics.PreferredBackBufferHeight = 1050;
            //graphics.IsFullScreen = true;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;

            //Controller Setup
            cPlayer1 = pPlayer1 = GamePad.GetState(PlayerIndex.One);
            cPlayer2 = pPlayer2 = GamePad.GetState(PlayerIndex.Two);
            cPlayer3 = pPlayer3 = GamePad.GetState(PlayerIndex.Three);
            cPlayer4 = pPlayer4 = GamePad.GetState(PlayerIndex.Four);
            

            //Player Setup
            playerList = new List<Player>();

            playerList.Add(new Huntress(cPlayer1, pPlayer1, "One", Content));
            playerList.Add(new Cleric(cPlayer2, pPlayer2, "Two", Content));
            playerList.Add(new Dragon(cPlayer3, pPlayer3, "Three", Content));
            playerList.Add(new RunicKnight(cPlayer4, pPlayer4, "Four", Content));

            //defaultView = GraphicsDevice.Viewport;

            Map = new GameLevel(Content);



            //ViewPort Setup
            viewportList = new List<Viewport>();

            viewportList.Add(new Viewport(0, 0, 840, 525));
            viewportList.Add(new Viewport(840, 0, 840, 525));
            viewportList.Add(new Viewport(0, 525, 840, 525));
            viewportList.Add(new Viewport(840, 525, 840, 525));

            //Camera Setup
            cameraList = new List<Camera>();

            for (int i = 0; i < 4; i++)
            {
                cameraList.Add(new Camera());
            }

            //Border setup

            defaultView = GraphicsDevice.Viewport;

            Border = new Sprite("Border", new Vector2(820, 525), Content);
        }
        
        protected override void LoadContent()
        {
            //Border = Content.Load<Sprite>("Border");
            //Border = new Sprite("Border", new Vector2(0,0), Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            cPlayer1 = pPlayer1 = GamePad.GetState(PlayerIndex.One);
            cPlayer2 = pPlayer2 = GamePad.GetState(PlayerIndex.Two);
            cPlayer3 = pPlayer3 = GamePad.GetState(PlayerIndex.Three);
            cPlayer4 = pPlayer4 = GamePad.GetState(PlayerIndex.Four);

            playerList[0].updatePadState(cPlayer1);
            playerList[1].updatePadState(cPlayer2);
            playerList[2].updatePadState(cPlayer3);
            playerList[3].updatePadState(cPlayer4);

            for (int i = 0; i < 4; i++)
            {
                playerList[i].playerUpdate(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            for (int i = 0; i < 4; i++)
            {
                GraphicsDevice.Viewport = viewportList[i];
                DrawSprites(gameTime, cameraList[i]);
            }

            GraphicsDevice.Viewport = defaultView;

            spriteBatch.Begin();
            Border.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        void DrawSprites(GameTime gameTime, Camera camera)
        {

            spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null, null, null, null,
                camera.transform);

            Map.levelDraw(gameTime, spriteBatch);


            for (int i = 0; i < 4; i++)
            {
                if (playerList[i]._cCont.IsConnected)
                {
                    playerList[i].playerDraw(gameTime, spriteBatch);
                    cameraList[i].Update(playerList[i].spritePosition);
                }
            }
            spriteBatch.End();
        }
    }
}
