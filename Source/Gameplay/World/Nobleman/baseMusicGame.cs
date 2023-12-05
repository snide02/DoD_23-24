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
        public List<Entity> entities = new List<Entity>();
        int bpm = 2;
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
            Globals.collisionSystem = new CollisionSystem();

            Entity playerInstance = new Player("Player", "2D/Sprites/Item", new Vector2(100, 100), 0.0f, new Vector2(16, 16));
            Entity ball = new Obstacle("Ball", "2D/Sprites/Special1", new Vector2(100, 150), 0.0f, new Vector2(16, 16));
            Entity randomThing = new Entity("RandomThing", Layer.NPC);
            randomThing.AddComponent(new TransformComponent(randomThing,
                new Vector2(-50, -50), 0.0f, new Vector2(16, 16)));
            randomThing.AddComponent(new RenderComponent(randomThing, "2D/Sprites/Item"));
            randomThing.AddComponent(new CollisionComponent(randomThing, true, true));
            Entity camera = new Entity("Camera", Layer.Camera);
            camera.AddComponent(new CameraComponent(camera, playerInstance));


            NPC book = new NPC("Book", "2D/Sprites/Special1", new Vector2(80, 64), 0.0f, new Vector2(16, 16), "Content/NPCText/TestNPC.txt");

            TileMapGenerator tileMapGenerator = new TileMapGenerator("Content/map.tmx", "Tiny Adventure Pack\\");
            entities.AddRange(tileMapGenerator.GetTiles());
            entities.Add(playerInstance);
            entities.Add(ball);
            entities.Add(randomThing);
            entities.Add(camera);
            entities.Add(book);
            entities.Add(book.GetOverlapZone());
        }

        public void Door()
        {

        }

        public void Health()
        {

        }


        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(gameTime);
            }

            Globals.collisionSystem.Update(gameTime);
        }

        public void Draw()
        {
            foreach (Entity entity in entities)
            {
                entity.Draw();
            }
        }

        public Entity GetCamera()
        {
            foreach (Entity entity in entities)
            {
                if (entity.name == "Camera")
                {
                    return entity;
                }
            }
            return null;
        }
    }
}
