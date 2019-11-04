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
        
        public Vector2 GridCoord { get => gridCoord; }
        public Vector2 ScreenPosition { get => screenPosition; set => screenPosition = value; }
        public Texture2D Texture { get => texture; set => texture = value; }
        public Color MyColor { get => myColor; set => myColor = value; }

        public Chunk(Vector2 gridCoord)
        {
            this.gridCoord = gridCoord;
            this.screenPosition = gridCoord;
        }
        public void ShipMovement(Vector2 dir)
        {
            screenPosition += dir;
        }
    }
}
