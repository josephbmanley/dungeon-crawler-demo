using Godot;

namespace Godot
{
    public static class TilemapExtensions
    {
        /// <summary>method <c>IsValidMapPosition</c> returns a bool of whether a location in a tilemap has no colliders.</summary>
        public static bool IsValidMapPosition(this TileMap tileMap, Vector2 position)
        {
            int tile_id = tileMap.GetCell((int)position.x, (int)position.y);
            if(tile_id >= 0)
                return tileMap.TileSet.TileGetShapeCount(tile_id) == 0;
            return true;
        }
    }
}