using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DoD_23_24.Source.Gameplay.World.Nobleman
{
    internal class baseMusicGame
    {
        int bpm = 2;
        Level musicGame;
        Player player;

        //Moving Object Function

        //Door Function

        //Object Path Function

        //Start Song Function
            //Start Timer

        //Get Time Function

        //Health Function

        //Update Function           - DONE

        //Draw Function (Square)    - DONE

        //Room Creation Function
            //Draw in the room

        public baseMusicGame()
        {
            musicGame = new Level("Content/map.tmx", "Tiny Adventure Pack\\");
            player = new Player("2D/Sprites/Item", new Vector2(100, 100), new Vector2(16, 16), true, musicGame);
        }


        public virtual void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }

        public virtual void Draw()
        {
            musicGame.Draw();
            player.Draw();
        }

        public Player GetPlayer()
        {
            return player;
        }

    }
}
