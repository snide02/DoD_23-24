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
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
#endregion
namespace DoD_23_24
{
    public class DialogueComponent : Component
    {
        string text;
        SpriteFont font;

        public DialogueComponent(Entity entity) : base(entity)
        {
            font = Globals.content.Load<SpriteFont>("2D/UI/DefaultFont");
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw()
        {
            if (text != null)
            {
                Globals.spriteBatch.DrawString(font, text, new Vector2(entity.GetComponent<TransformComponent>().pos.X + 30, entity.GetComponent<TransformComponent>().pos.Y + 30), Color.White);
            }
        }

        public void SetText(string text)
        {
            this.text = text;
        }
    }
}