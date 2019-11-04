using Microsoft.Xna.Framework;
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

        public float chunkWidth = 200;

        ShipClass ship;
        Map map = new Map();
        Chunk[] loadedChunks = new Chunk[9];
        Vector2 Focus;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.Window.AllowUserResizing = true;
            this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Color shipColor = new Color(150, 150, 150);
            Vector2 screenPos = new Vector2(400,400);

            ship = new ShipClass(0.1f, 0.3f, shipColor);
            ship.ScreenPosition = screenPos;
            ship.Coord = new Vector2();
            ship.ForwardSpeed = 400f;

            // will need to pass world coords too
            loadedChunks = map.GetInitChunks(screenPos);
            Focus = map.FocusChunk(screenPos);
            base.Initialize();
        }
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
            foreach (Chunk c in loadedChunks)
            {
                // this is just for visial aid, remove when chunk gen is done
                c.Texture = Content.Load<Texture2D>("White_square");
                count++;
                if (count % 2 == 0)
                {
                    c.MyColor = Color.Blue;
                }
                else
                {
                    c.MyColor = Color.White;
                }
            }
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            ShipMovement(gameTime);

            Vector2 checkFocus = map.FocusChunk(ship.ScreenPosition);

            if (checkFocus != Focus)
            {
                map.GetInitChunks(ship.ScreenPosition);
            }

            base.Update(gameTime);
        }
        public void ShipMovement(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();
            
            Keys k = Keys.R;
            if (kstate.IsKeyDown(Keys.Up))
            {
                k = Keys.Up;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                k = Keys.Down;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                k = Keys.Left;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                k = Keys.Right;
            }
            foreach (Chunk c in loadedChunks)
            {
                c.ShipMovement(gameTime, k);
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
            // loads the current chunks in a 3x3 grid around play
            DrawChunks();
            // loads the players first ship
            DrawShip();
            spriteBatch.End();

            base.Draw(gameTime);
        }
        void DrawChunks()
        {
            // remove this when done
            foreach (Chunk c in loadedChunks)
            {
                spriteBatch.Draw(c.Texture, c.ScreenPosition, null, c.MyColor,
                    0f, Vector2.Zero,
                    Vector2.One, SpriteEffects.None, 0f);
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
