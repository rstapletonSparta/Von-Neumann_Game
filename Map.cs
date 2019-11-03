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
        public Chunk[] GetInitChunks(Vector2 shipPos)
        {
            // this should be my run time chunk check too
            Chunk[] ch = new Chunk[9];
            int spacing = 200; // this is from chunkWidth in game1
            float xModded = shipPos.X % spacing;
            float yModded = shipPos.Y % spacing;

            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Vector2 t = new Vector2((shipPos.X - xModded) + (x * spacing), (shipPos.Y - yModded) + (y * spacing));
                    Chunk newChunk = new Chunk(t); // this should get get or create
                    ch[count] = newChunk;
                    count++;
                    Console.WriteLine(t);
                }
            }
            return chunks;
        }
    }
}
