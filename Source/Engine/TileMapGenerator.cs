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

#endregion
using TiledSharp;

namespace DoD_23_24
{
    public class TileMapGenerator
    {
        TileMapManager mapManager;
        TmxMap map;
        private List<Entity> tiles;


        public TileMapGenerator(String mapPath, String tileSetPath)
        {
            map = new TmxMap(mapPath);
            Texture2D tileSet = Globals.content.Load<Texture2D>(tileSetPath + map.Tilesets[0].Name.ToString());
            int tileWidth = map.Tilesets[0].TileWidth;
            int tileHeight = map.Tilesets[0].TileHeight;
            int tileSetTilesWide = tileSet.Width / tileWidth;
            mapManager = new TileMapManager(map, tileSet, tileSetTilesWide, tileWidth, tileHeight);
            tiles = mapManager.CreateTiles();
        }

        public List<Entity> GetTiles()
        {
            return tiles;
        }
    }
}
