using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace VonNeumannGame
{
    class Map
    {
        Dictionary<Vector2, Chunk> chunks = new Dictionary<Vector2, Chunk>();
        //Chunk[] loadedChunks = new Chunk[9];
        Chunk loadedChunks;

        private int chunkWidth = 200;
        private float speed = 200;

        public Chunk LoadedChunks { get => loadedChunks; set => loadedChunks = value; }

        public Chunk GetInitChunks(Vector2 coord)
        {
            Vector2 pos = FocusChunk(coord);
            Chunk ch = CheckOrCreateChunk(pos);
            return ch;
        }





        
        public Vector2 FocusChunk(Vector2 pos)
        {
            // pos needs to 
            float xModded = pos.X % chunkWidth;
            float yModded = pos.Y % chunkWidth;
            Vector2 t = new Vector2(pos.X - xModded, pos.Y - yModded);
            return t;
        }
        
       
        public void ShipMovement(GameTime gameTime, ShipClass ship)
        {
            var kstate = Keyboard.GetState();
            Vector2 newPos = new Vector2();

            Vector2 shipCoord = ship.Coord;
            if (kstate.IsKeyDown(Keys.Up))
            {
                newPos.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                newPos.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                newPos.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                newPos.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            //foreach (Chunk c in loadedChunks)
            //{
            //    c.ShipMovement(gameTime, k);
            //}
            loadedChunks.ShipMovement(newPos);
        }
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
        //public Chunk GetInitChunks(Vector2 coord)
        //{
        //    this should be my run time chunk check too
        //    Vector2 pos = FocusChunk(coord);
        //    Chunk ch = CheckOrCreateChunk(pos);

        //    Chunk[] ch = new chunk[9];
        //    int count = 0;
        //    for (int x = -1; x <= 1; x++)
        //    {
        //        for (int y = -1; y <= 1; y++)
        //        {
        //            vector2 pos = focuschunk(shipcoord);
        //            pos.x = pos.x + (x * spacing);
        //            pos.y = pos.y + (y * spacing);
        //            chunk newchunk = checkorcreatechunk(pos);
        //            ch[count] = newchunk;
        //            count++;
        //            console.writeline(pos);
        //        }
        //    }
        //    return ch;
        //}

    }
}
