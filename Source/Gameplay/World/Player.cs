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
	public class Player : Entity
	{
        float speed = 50f;
        TransformComponent transform;
        bool isPressed = false;
        bool isFrozen = false;

        public Player(string name, string PATH, Vector2 POS, float ROT, Vector2 DIMS) : base(name, Layer.Player)
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
            if(isFrozen)
            {
                return;
            }

            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Left))
            {
                transform.pos.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                transform.pos.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Up))
            {
                transform.pos.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                transform.pos.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public override void OnCollision(Entity otherEntity)
        {
            Console.WriteLine("I'm Colliding!");

            if(otherEntity.name == "OverlapZone")
            {
                InteractWithNPC(otherEntity);
            }
        }

        public void InteractWithNPC(Entity overlapZone)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !isPressed)
            {
                overlapZone.GetComponent<OverlapZoneComponent>().GetParentNPC().Speak();
                isFrozen = overlapZone.GetComponent<OverlapZoneComponent>().GetParentNPC().CheckIfPlayerFrozen();
                isPressed = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                isPressed = false;
            }
        }
    }
}