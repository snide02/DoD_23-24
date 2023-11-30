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
	public class TransformComponent : Component
	{
		public Vector2 pos, dims;
		public float rot, scale;

		public TransformComponent(Entity entity, Vector2 POS, float ROT, Vector2 DIMS) : base(entity)
		{
			pos = POS;
			rot = ROT;
			dims = DIMS;
        }

        public override void Draw()
        {
            if (Globals.isDebugOn)
            {
                RectangleSprite.DrawRectangle(Globals.spriteBatch, new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y), Color.Blue, 2);
            }
        }
    }
}

