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
	public class Entity
	{
        public string name;
        public Layer layer;
		List<Component> components = new List<Component>();
        bool isActive = true;
        Entity parent;

        public Entity(string name, Layer layer) { this.name = name; this.layer = layer;  }

        public Component GetComponent<Component>()
        {
            return components.OfType<Component>().FirstOrDefault();
        }

        public Component AddComponent(Component component)
        {
            components.Add(component);
            return component;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Component component in components)
            {
                component.Update(gameTime);
            }
        }

        public virtual void Draw()
        {
            if(!isActive)
            {
                return;
            }

            foreach (Component component in components)
            {
                component.Draw();
            }
        }

        public void SetActive(bool active)
        {
            isActive = active;
        }
        public bool IsActive()
        {
            return isActive;
        }

        public void SetParent(Entity parent)
        {
            this.parent = parent;
        }

        public Entity GetParent()
        {
            return parent;
        }

        public virtual void OnCollision(Entity otherEntity) { }
    }
}

