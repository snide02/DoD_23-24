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
using System.IO;

#endregion

namespace DoD_23_24
{
    public class GameItem: Basic2D
    {
        public String name { get; set; }
        public String description { get; set; }
        public Texture2D image { get; set; }

        public GameItem(string PATH, Vector2 POS, Vector2 DIMS, bool shouldScale, String name, String description, Texture2D image) : base(PATH, POS, DIMS, shouldScale)
        {
            this.name = name;
            this.description = description;
            this.image = image;
        }

        public override void Update(GameTime gameTime)
        {
            podfgk;dokgdl;ghkavams';dkfsldkasoai30t[j989p'
            base.Update(gameTime);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}

