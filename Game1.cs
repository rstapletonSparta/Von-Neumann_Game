﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

// basic game fly around mining resouncese and setting up stations 
// to build more probs.

// should write an excel doc of the interactions and cost per part
// should base this on the book

// builderables: 
//      mining fac(cheepest to build),
//      refinerary(secound cheepest part to build) 
//      light factory(builds small ships, eg mining drones/ def drones)

//      ships(take various parts to build), 
//      scafolding, sheet metal, brain, add ons

// for models could try to do the 3d model to 2d sprite render tech
// 

namespace VonNeumannGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        float chunkWidth = 200;

        ShipClass ship;
        Map map = new Map();
        Chunk[] loadedChunks = new Chunk[9];

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.Window.AllowUserResizing = true;
            this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Color shipColor = new Color(150, 150, 150);
            ship = new ShipClass(0.1f, 0.3f, shipColor);

            ship.ScreenPosition = new Vector2(graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2);
            ship.ForwardSpeed = 400f;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ship.Texture = Content.Load<Texture2D>("White_square");
            LoadChunkContent();
            
            // TODO: use this.Content to load your game content here

        }
        void LoadChunkContent()
        {
            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Vector2 pos = new Vector2(x * chunkWidth, y * chunkWidth);
                    Chunk newChunk = map.CreateChunk(pos);
                    loadedChunks[count] = newChunk;
                    newChunk.Texture = Content.Load<Texture2D>("White_square");
                    count++;
                    if (count % 2 == 0)
                    {
                        newChunk.MyColor = Color.Blue;
                    }
                    else
                    {
                        newChunk.MyColor = Color.White;
                    }
                    Console.WriteLine(newChunk.StartCoord + "   " + newChunk.MyColor);
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            ShipMovement(gameTime);

            base.Update(gameTime);
        }

        public void ShipMovement(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();
            foreach (Chunk c in loadedChunks)
            {
                c.ShipMovement(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Color backgroundColour = new Color(10, 10, 10);
            GraphicsDevice.Clear(backgroundColour);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            DrawChunks();
            DrawShip();
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
        void DrawChunks()
        {
            foreach (Chunk c in loadedChunks)
            {
                spriteBatch.Draw(c.Texture, c.ScreenPosition, null, c.MyColor,
                    0f, Vector2.One, // change this back to : new Vector2(c.Texture.Width / 2, c.Texture.Height / 2)
                    Vector2.One,
                    SpriteEffects.None, 0f);
            }
        }
        void DrawShip()
        {
            spriteBatch.Draw(ship.Texture, ship.ScreenPosition, null, ship.MyColor,
                0f, new Vector2(ship.Texture.Width / 2, ship.Texture.Height / 2),
                new Vector2(ship.Width, ship.Height), SpriteEffects.None, 0f);
        }
        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            graphics.ApplyChanges();
        }
    }
}
