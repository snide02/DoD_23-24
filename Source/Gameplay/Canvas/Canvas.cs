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

using System.Reflection.Metadata;
using System.Diagnostics;

#endregion

namespace DoD_23_24
{
    public class Canvas
    {
        public List<Entity> entities = new List<Entity>();
        public static Entity dialogueBox;

        public Canvas()
        {
            dialogueBox = new Entity("Dialogue Box", Layer.UI);
            dialogueBox.AddComponent(new TransformComponent(dialogueBox,
                new Vector2(200, 400), 0.0f, new Vector2(400, 200)));
            dialogueBox.AddComponent(new RenderComponent(dialogueBox, "2D/Sprites/DialogueBox"));
            dialogueBox.AddComponent(new DialogueComponent(dialogueBox));
            dialogueBox.SetActive(false);

            entities.Add(dialogueBox);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw()
        {
            foreach (Entity entity in entities)
            {
                entity.Draw();
            }
        }
    }
}