using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace VonNeumannGame
{
    class Chunk
    {
        private Vector2 gridCoord;
        private Vector2 screenPosition;

        private Texture2D texture;
        private Color myColor;

        public Texture2D Texture { get => texture; set => texture = value; }
        public Color MyColor { get => myColor; set => myColor = value; }

        public Vector2 GridCoord { get => gridCoord; }
        public Vector2 ScreenPosition { get => screenPosition; set => screenPosition = value; }

        private float ForwardSpeed = 50;
        public Chunk(Vector2 gridCoord)
        {
            this.gridCoord = gridCoord;
            this.screenPosition = gridCoord;
        }
        public void ShipMovement(GameTime gameTime, Keys kstate)
        {
            //var kstate = Keyboard.GetState();
            if (kstate == Keys.Up)
                screenPosition.Y += ForwardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate == Keys.Down)
                screenPosition.Y -= ForwardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate == Keys.Left)
                screenPosition.X += ForwardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate == Keys.Right)
                screenPosition.X -= ForwardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
