#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion
namespace DoD_23_24
{

    public class Obstacle : Entity
    {
        float speedX = 50f;
        float speedY = 50f;
        

        TransformComponent transform;

        public Obstacle(string name, string PATH, Vector2 POS, float ROT, Vector2 DIMS) : base(name, Layer.Player)
        {
            transform = (TransformComponent)AddComponent(new TransformComponent(this, POS, ROT, DIMS));
            AddComponent(new RenderComponent(this, PATH));
            AddComponent(new CollisionComponent(this, true, true));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Movement(gameTime);
        }

        public void Movement(GameTime gameTime)
        {
            transform.pos.X += speedX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //transform.pos.Y -= speedY * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void OnCollision(Entity otherEntity)
        {
            Console.WriteLine("I'm Colliding!");

            if (otherEntity.name != "Player")
            {
                if (transform.pos.X <= 0 || transform.pos.X + transform.dims.X >= 100)
                {
                    speedX = speedX * -1; 
                }
                if (transform.pos.Y <= 0 || transform.pos.Y + transform.dims.Y >= 100)
                {
                    speedY = speedY * -1;
                }

            }
            else
            {
                layer = Layer.Tiles;
            }
        }
    }
}
