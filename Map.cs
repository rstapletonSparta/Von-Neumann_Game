using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;


namespace VonNeumannGame
{
    class Map
    {
        Dictionary<Vector2, Chunk> chunks = new Dictionary<Vector2, Chunk>();
        private Vector2 focusChunk;
        int spacing = 200; // this is from chunkWidth in game1

        
        public Chunk CheckOrCreateChunk(Vector2 pos)
        {
            if (chunks.ContainsKey(pos))
            {
                return chunks[pos];
            }
            else
            {
                Chunk n = new Chunk(pos);
                chunks.Add(pos, n);
                return n;
            }
        }
        public Chunk[] GetInitChunks(Vector2 shipPos)
        {
            // this should be my run time chunk check too
            Chunk[] ch = new Chunk[9];
            
            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Vector2 pos = FocusChunk(shipPos);
                    pos.X = pos.X + (x * spacing);
                    pos.Y = pos.Y + (y * spacing);
                    Chunk newChunk = CheckOrCreateChunk(pos);
                    ch[count] = newChunk;
                    count++;
                    Console.WriteLine(pos);
                }
            }
            return ch;
        }
        public Vector2 FocusChunk(Vector2 shipPos)
        {
            float xModded = shipPos.X % spacing;
            float yModded = shipPos.Y % spacing;
            Vector2 t = new Vector2(shipPos.X - xModded, shipPos.Y - yModded);
            return t;
        }
    }
}
