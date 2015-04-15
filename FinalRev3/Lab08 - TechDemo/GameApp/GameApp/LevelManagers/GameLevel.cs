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
    public class GameLevel
    {

        public Random rand;

        public int[,] mapArray = new int[20, 30] {{9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9},
                                                  {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}};
        public int map_array_length = 30;
        public int map_array_height = 20;
        public int tile_size = 64;

        public Sprite wallSpriteLEFT;
        public Sprite wallSpriteRIGHT;
        public Sprite regSprite;
        public List<Sprite> spriteList;


        public GameLevel(ContentManager Content)
        {
            rand = new Random();

            for (int i = 0; i < map_array_height; i++)
            {
                for (int j = 0; j < map_array_length; j++)
                {
                    mapArray[i, j] = getRandom(0, 10);                    
                   
                }//end j
            }//end i

            wallSpriteLEFT = new Sprite("room/wall/Base_BlueBrickWall_LEFT", new Vector2(464, 640), Content);
            wallSpriteRIGHT = new Sprite("room/wall/Base_BlueBrickWall_RIGHT", new Vector2(1520, 640), Content);

            assignTiles(Content);

        }//end constructor


        public int getRandom(int min, int max)
        {
            
            int number = 0;

            number = (rand.Next(min,max));

            return number;
        }//end getRandom

        public void assignTiles(ContentManager Content)
        {
            spriteList = new List<Sprite>();

            for (int i = 0; i < map_array_height; i++)
            {
                for (int j = 0; j < map_array_length; j++)
                {
                    if (mapArray[i, j] == 0)
                    {
                        regSprite = new Sprite("room/floor/FloorTile", new Vector2(((j * 64) + 32), ((i * 64)) + 32), Content);
                        spriteList.Add(regSprite);
                    }
                    else if (mapArray[i, j] == 1)
                    {
                        regSprite = new Sprite("room/floor/FloorTile2", new Vector2(((j * 64) + 32), ((i * 64)) + 32), Content);
                        spriteList.Add(regSprite);

                    }
                    else if (mapArray[i, j] == 2)
                    {
                        regSprite = new Sprite("room/floor/FloorTile3", new Vector2(((j * 64) + 32), ((i * 64)) + 32), Content);
                        spriteList.Add(regSprite);

                    }
                    else if (mapArray[i, j] == 3)
                    {
                        regSprite = new Sprite("room/floor/FloorTile4", new Vector2(((j * 64) + 32), ((i * 64)) + 32), Content);
                        spriteList.Add(regSprite);

                    }
                    else if (mapArray[i, j] == 4)
                    {
                        regSprite = new Sprite("room/floor/FloorTile5", new Vector2(((j * 64) + 32), ((i * 64)) + 32), Content);
                        spriteList.Add(regSprite);

                    }
                    else if (mapArray[i, j] == 5)
                    {
                        regSprite = new Sprite("room/floor/FloorTile6", new Vector2(((j * 64) + 32), ((i * 64)) + 32), Content);
                        spriteList.Add(regSprite);

                    }
                    else if (mapArray[i, j] == 6)
                    {
                        regSprite = new Sprite("room/floor/FloorTile7", new Vector2(((j * 64) + 32), ((i * 64)) + 32), Content);
                        spriteList.Add(regSprite);

                    }
                    else if (mapArray[i, j] == 7)
                    {
                        regSprite = new Sprite("room/floor/FloorTile8", new Vector2(((j * 64) + 32), ((i * 64)) + 32), Content);
                        spriteList.Add(regSprite);

                    }
                    else if (mapArray[i, j] == 8)
                    {
                        regSprite = new Sprite("room/floor/FloorTile9", new Vector2(((j * 64) + 32), ((i * 64)) + 32), Content);
                        spriteList.Add(regSprite);

                    }
                    else if (mapArray[i, j] == 9)
                    {
                        regSprite = new Sprite("room/floor/FloorTile10", new Vector2(((j * 64) + 32), ((i * 64)) + 32), Content);
                        spriteList.Add(regSprite);

                    }
                }//end j
            }//end i

        }//end assignTiles

        public void levelDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
          
            for (int i = 0; i < spriteList.Count; i++)
            {
                spriteList[i].Draw(gameTime, spriteBatch);
            }//end for loop

            wallSpriteLEFT.Draw(gameTime, spriteBatch);
            wallSpriteRIGHT.Draw(gameTime, spriteBatch);


        }//end levelDraw

    }//end GameLevel Class
}//end Namespace Engine
