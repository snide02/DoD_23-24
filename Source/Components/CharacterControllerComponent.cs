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
    public class CharacterControllerComponent : Component
    {
        public float speed = 50f;
        public float xSpeed, ySpeed = 0f;

        TransformComponent transform;
        CollisionComponent collision;

        public CharacterControllerComponent(Entity entity) : base(entity)
        {
            transform = entity.GetComponent<TransformComponent>();
            collision = entity.GetComponent<CollisionComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            Movement(gameTime);
        }

        public void Movement(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();

            //Left
            if (kstate.IsKeyDown(Keys.Left))
            {
                xSpeed = -speed;
            }

            if (kstate.IsKeyUp(Keys.Left))
            {
                xSpeed = 0f;
                collision.leftCollisionForce = 0f;
            }

            //Right
            if (kstate.IsKeyDown(Keys.Right))
            {
                xSpeed = speed;
            }

            if (kstate.IsKeyUp(Keys.Right))
            {
                collision.rightCollisionForce = 0f;
            }

            //Up
            if (kstate.IsKeyDown(Keys.Up))
            {
                ySpeed = -speed;
            }

            if (kstate.IsKeyUp(Keys.Up))
            {
                ySpeed = 0f;
                collision.upCollisionForce = 0f;
            }

            //Down
            if (kstate.IsKeyDown(Keys.Down))
            {
                ySpeed = speed;
            }

            if (kstate.IsKeyUp(Keys.Down))
            {
                collision.downCollisionForce = 0f;
            }

            transform.pos.X += (xSpeed + collision.leftCollisionForce + collision.rightCollisionForce) * (float)gameTime.ElapsedGameTime.TotalSeconds;
            transform.pos.Y += (ySpeed + collision.upCollisionForce + collision.downCollisionForce) * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}

