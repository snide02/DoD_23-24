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
using System.Reflection.Emit;
#endregion
namespace DoD_23_24
{
    public class CameraComponent : Component
    {
        TransformComponent targetTransform;
        public float zoom = 2f;

        public CameraComponent(Entity entity, Entity target) : base(entity)
        {
            targetTransform = target.GetComponent<TransformComponent>();
        }

        public Matrix GetTranslation()
        {
            var dx = (Globals.WIDTH / (zoom * 2)) - (int)targetTransform.pos.X - (int)(targetTransform.dims.X / 2);
            var dy = (Globals.HEIGHT / (zoom * 2)) - (int)targetTransform.pos.Y - (int)(targetTransform.dims.Y / 2);
            return Matrix.CreateTranslation(dx, dy, 0f) * Matrix.CreateScale(zoom);
        }
    }
}