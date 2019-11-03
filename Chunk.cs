using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace VonNeumannGame
{
    class Chunk
    {
        private Vector2 startCoord;
        private Vector2 screenPosition;

        private Texture2D texture;
        private Color myColor;

        public Texture2D Texture { get => texture; set => texture = value; }
        public Color MyColor { get => myColor; set => myColor = value; }

        public Vector2 StartCoord { get => startCoord; }
        public Vector2 ScreenPosition { get => screenPosition; set => screenPosition = value; }

        private float ForwardSpeed = 50;
        public Chunk(Vector2 startCoord)
        {
            this.startCoord = startCoord;
            this.screenPosition = startCoord;
        }
        public void ShipMovement(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
                screenPosition.Y += ForwardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                screenPosition.Y -= ForwardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                screenPosition.X += ForwardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                screenPosition.X -= ForwardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;


        }
    }
}
