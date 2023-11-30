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
    public class CollisionComponent : Component
    {
        Rectangle bounds;

        public bool isPhysical, isMoveable;

        TransformComponent transform;

        public CollisionComponent(Entity entity, bool isPhysical, bool isMoveable) : base(entity)
        {
            Globals.collisionSystem.addCollision(entity);

            this.isPhysical = isPhysical;
            this.isMoveable = isMoveable;

            transform = entity.GetComponent<TransformComponent>();
            bounds = new Rectangle((int)transform.pos.X, (int)transform.pos.Y, (int)transform.dims.X, (int)transform.dims.Y);
        }

        public override void Update(GameTime gameTime)
        {
            bounds.X = (int)transform.pos.X;
            bounds.Y = (int)transform.pos.Y;
            bounds.Width = (int)transform.dims.X;
            bounds.Height = (int)transform.dims.Y;
        }

        public override void Draw()
        {
            if (Globals.isDebugOn)
            {
                RectangleSprite.DrawRectangle(Globals.spriteBatch, bounds, Color.Red, 1);
            }
        }

        public void ReportCollision(Entity otherEntity)
        {
            //TODO: Fix jumpiness
            CollisionComponent otherCollision = otherEntity.GetComponent<CollisionComponent>();

            if (isPhysical && otherCollision.isPhysical && isMoveable)
            {
                Point penetrationDepthVector = bounds.Center - otherCollision.bounds.Center;
                int overlap = bounds.Width / 2 + otherCollision.bounds.Width / 2 - Math.Abs(penetrationDepthVector.X);
                Console.WriteLine(bounds.Center + " " + otherCollision.bounds.Center);
                Console.WriteLine(penetrationDepthVector + " " + overlap);


                if (overlap > 0)
                {
                    if (penetrationDepthVector.X > 0)
                    {
                        transform.pos.X += overlap;
                    }
                    else
                    {
                        transform.pos.X -= overlap;
                    }
                }

                //overlap = bounds.Height / 2 + otherCollision.bounds.Height / 2 - Math.Abs(penetrationDepthVector.Y);

                //if (overlap > 0)
                //{
                //    if (penetrationDepthVector.Y > 0)
                //    {
                //        transform.pos.Y += overlap;
                //    }
                //    else
                //    {
                //        transform.pos.Y -= overlap;
                //    }
                //}
            }

            entity.OnCollision(otherEntity);
        }

        public bool CheckCollision(Rectangle otherBounds)
        {
            return bounds.Intersects(otherBounds);
        }

        public Rectangle GetBounds()
        {
            return bounds;
        }
    }
}

