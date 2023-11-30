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
    abstract public class Component
    {
        protected readonly Entity entity;

        protected Component(Entity entity)
        {
            this.entity = entity;
        }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw() { }
    }
}