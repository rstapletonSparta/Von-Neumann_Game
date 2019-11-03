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
        private Texture2D texture;
        private Color myColor;
        private Vector2 screenPosition;
        private float width;
        private float height;

        private float forwardSpeed;
        private Vector2 coord;

        public Vector2 ScreenPosition { get => screenPosition; set => screenPosition = value; }
        public Texture2D Texture { get => texture; set => texture = value; }
        public float Width { get => width; }
        public float Height { get => height; }
        public Color MyColor { get => myColor; set => myColor = value; }

        public float ForwardSpeed { get => forwardSpeed; set => forwardSpeed = value; }
        public Vector2 Coord { get => coord; set => coord = value; }


        public ShipClass(float width, float height, Color myColor)
        {
            this.width = width;
            this.height = height;
            this.myColor = myColor;
        }
        
    }
}
