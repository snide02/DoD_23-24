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
using System.Diagnostics;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
#endregion
namespace DoD_23_24
{
    public class NPC : Entity
    {
        string textPath, text;
        int currentText;
        bool freezePlayer;


        Entity overlapZone;
        private List<string> conversation = new List<string> { };

        public NPC(string name, string PATH, Vector2 POS, float ROT, Vector2 DIMS, string TEXT) : base(name, Layer.NPC)
        {
            AddComponent(new TransformComponent(this, POS, ROT, DIMS));
            AddComponent(new RenderComponent(this, PATH));
            AddComponent(new CollisionComponent(this, true, false));

            
            textPath = TEXT;

            overlapZone = new Entity("OverlapZone", Layer.NPC);
            overlapZone.AddComponent(new TransformComponent(overlapZone, new Vector2((int)POS.X - 16, (int)POS.Y - 16), 0.0f, new Vector2(48, 48)));
            overlapZone.AddComponent(new CollisionComponent(overlapZone, false, false));
            overlapZone.AddComponent(new OverlapZoneComponent(overlapZone, this));
            overlapZone.SetParent(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void SetText(string textFilePath)
        {
            StreamReader sr = new StreamReader(textFilePath);
            string line = sr.ReadLine();
            while (line != null)
            {
                conversation.Add(line);
                line = sr.ReadLine();
            }
            text = conversation[currentText];
        }

        public void Speak()
        {
            if (currentText == 0)
            {
                SetText(textPath);
                Canvas.dialogueBox.GetComponent<DialogueComponent>().SetText(text);
                Canvas.dialogueBox.SetActive(true);
                freezePlayer = true;
            }

            if (currentText >= conversation.Count)
            {
                Canvas.dialogueBox.SetActive(false);
                freezePlayer = false;
                currentText = 0;
                conversation.Clear();
            }
            else
            {
                text = conversation[currentText];
                Canvas.dialogueBox.GetComponent<DialogueComponent>().SetText(text);
                currentText++;
            }
        }

        public bool CheckIfPlayerFrozen()
        {
            return freezePlayer;
        }

        public Entity GetOverlapZone()
        {
            return overlapZone;
        }
    }
}