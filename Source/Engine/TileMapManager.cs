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
using TiledSharp;

namespace DoD_23_24
{
    public class TileMapManager
    {
        TmxMap map;
        Texture2D tileset;
        int tilesetTilesWide;
        int tileWidth;
        int tileHeight;

        public TileMapManager(TmxMap _map, Texture2D _tileset, int _tilesetTilesWide, int _tileWidth, int _tileHeight)
        {
            map = _map;
            tileset = _tileset;
            tilesetTilesWide = _tilesetTilesWide;
            tileWidth = _tileWidth;
            tileHeight = _tileHeight;
        }

        public List<Entity> CreateTiles()
        {
            List<Entity> entities = new List<Entity>();
            for (int i = 0; i < map.Layers.Count; i++)
            {
                for (int j = 0; j < map.Layers[i].Tiles.Count; j++)
                {
                    int gid = map.Layers[i].Tiles[j].Gid;
                    if (gid != 0)
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetTilesWide;
                        int row = (int)Math.Floor(tileFrame / (double)tilesetTilesWide);
                        float x = j % map.Width * map.TileWidth;
                        float y = (float)Math.Floor(j / (double)map.Width) * map.TileHeight;
                        Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);

                        Entity tile = new Entity("Tile_" + gid, Layer.Tiles);
                        tile.AddComponent(new TransformComponent(tile, new Vector2(x, y), 0.0f, new Vector2(tileWidth, tileHeight)));
                        tile.AddComponent(new RenderComponent(tile, tileset, tilesetRec));
                        entities.Add(tile);
                    }
                }
            }
            foreach (TmxObject o in map.ObjectGroups["Collisions"].Objects)
            {
                Entity collisionEntity = new Entity("Tile_" + o.Id, Layer.Tiles);
                TransformComponent transform = new TransformComponent(collisionEntity, new Vector2((float)o.X, (float)o.Y), 0.0f, new Vector2((float)o.Width, (float)o.Height));
                collisionEntity.AddComponent(transform);
                collisionEntity.AddComponent(new CollisionComponent(collisionEntity, true, false));
                entities.Add(collisionEntity);
            }
            return entities;
        }
    }
}