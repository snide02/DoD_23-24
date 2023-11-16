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
        Obstacle ball; 

        //Constructor               - DONE

        //Door Function

        //Start Song Function
            //Start Timer

        //Get Time Function

        //Health Function

        //Update Function           - DONE

        //Draw Function (Square)    - DONE
            //Room Creation Function

        public baseMusicGame()
        {
            musicGame = new Level("Content/map.tmx", "Tiny Adventure Pack\\");
            player = new Player("2D/Sprites/Item", new Vector2(100, 100), new Vector2(16, 16), true, musicGame);
            ball = new Obstacle("2D/Sprites/Item", new Vector2(100, 100), new Vector2(16, 16), true, musicGame);
        }

        public void Door()
        {

        }

        public void Health()
        {

        }


        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            ball.Update(gameTime);
        }

        public void Draw()
        {
            musicGame.Draw();
            player.Draw();
            ball.Draw();
        }

        public Player GetPlayer()
        {
            return player;
        }

    }
}
