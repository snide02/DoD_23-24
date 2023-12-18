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
        int health = 3;
        float speed = 50f;
        Matrix translation;
        public Rectangle playerBounds;
        private float zoom = 2.0f;
        private Level level;
        public List<GameItem> inventory {  get; set; }

        public Player(string name, string PATH, Vector2 POS, float ROT, Vector2 DIMS) : base(name, Layer.Player)
		{
            playerBounds = new Rectangle((int)pos.X - (int)(dims.X/2), (int)pos.Y - (int)(dims.Y / 2), (int)dims.X, (int)dims.Y);
            this.level = level;
            this.inventory = new List<GameItem>();
        }

        public override void Update(GameTime gameTime)
        {
            Movement(gameTime);
            CalculateTranslation();

            foreach (GameItem item in inventory)
            {
                Console.WriteLine(item.name);
            }

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

            if(otherEntity.name == "Ball")
            {
                takeHealth(otherEntity);
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

        public void takeHealth(Entity obstacle)
        {
            health = health - 1;
            if (health == 0)
                speed = 0;
        }
    }
}