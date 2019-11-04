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

        ShipClass ship;
        Map map = new Map();
        private Vector2 focusChunk = new Vector2(8, 24);


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.Window.AllowUserResizing = true;
            this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
        }
        protected override void Initialize()
        {
            Color shipColor = new Color(150, 150, 150);
            Vector2 coord = new Vector2(400,200);
            ship = new ShipClass(0.1f, 0.3f, shipColor);
            ship.Coord = coord;

            map.LoadedChunks = map.GetInitChunks(focusChunk);
            
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ship.Texture = Content.Load<Texture2D>("White_square");
            LoadChunkContent();
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

            map.ShipMovement(gameTime, ship);
            
            base.Update(gameTime);
        }
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
            spriteBatch.Draw(map.LoadedChunks.Texture, map.LoadedChunks.ScreenPosition, null, map.LoadedChunks.MyColor,
                    0f, new Vector2(map.LoadedChunks.Texture.Width / 2, map.LoadedChunks.Texture.Height / 2),
                    Vector2.One, SpriteEffects.None, 0f);
            // remove this when done
            //foreach (Chunk c in loadedChunks)
            //{
            //    spriteBatch.Draw(c.Texture, c.ScreenPosition, null, c.MyColor,
            //        0f, Vector2.Zero,
            //        Vector2.One, SpriteEffects.None, 0f);
            //}
        }
        void DrawShip()
        {
            spriteBatch.Draw(ship.Texture, ship.Coord, null, ship.MyColor,
                0f, new Vector2(ship.Texture.Width / 2, ship.Texture.Height / 2),
                new Vector2(ship.Width, ship.Height), SpriteEffects.None, 0f);
        }
        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            graphics.ApplyChanges();
        }
        void LoadChunkContent()
        {
            map.LoadedChunks.Texture = Content.Load<Texture2D>("White_square");
            map.LoadedChunks.MyColor = Color.Violet;
            //int count = 0;
            //foreach (Chunk c in loadedChunks)
            //{
            //    // this is just for visial aid, remove when chunk gen is done
            //    c.Texture = Content.Load<Texture2D>("White_square");
            //    count++;
            //    if (count % 2 == 0)
            //    {
            //        c.MyColor = Color.Blue;
            //    }
            //    else
            //    {
            //        c.MyColor = Color.White;
            //    }
            //}
        }
    }
}
