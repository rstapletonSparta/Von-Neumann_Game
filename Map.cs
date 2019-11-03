using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;


namespace VonNeumannGame
{
    class Map
    {
        Dictionary<Vector2, Chunk> chunks = new Dictionary<Vector2, Chunk>();
        
        public Chunk CreateChunk(Vector2 i)
        {
            Chunk n = new Chunk(i);
            chunks.Add(i,n);
            return n;
        }
        public void Move()
        {

        }
    }
}
