using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VonNeumannGame
{
    class ShipClass
    {
        private Vector2 coord;
        
        private Texture2D texture;
        private Color myColor;
        private float width;
        private float height;

        public Vector2 Coord { get => coord; set => coord = value; }

        public Texture2D Texture { get => texture; set => texture = value; }
        public float Width { get => width; }
        public float Height { get => height; }
        public Color MyColor { get => myColor; set => myColor = value; }
        
        public ShipClass(float width, float height, Color myColor)
        {
            this.width = width;
            this.height = height;
            this.myColor = myColor;
        }
    }
}
