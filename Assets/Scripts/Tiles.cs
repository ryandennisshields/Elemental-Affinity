using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Class for tile identification
// This code grabs the tiles on the board and sets them to specifics for a level.
public class Tiles : MonoBehaviour
{
    public Tilemap tiles; // Stores the tilemap
    public Tilemap objectTiles; // Stores the environemental object tilemap
    private int gridBoundStartX = -9, gridBoundStartY = -2, gridBoundEndX = 9, gridBoundEndY = 5; // Stores and sets the tile grid

    // Start is called before the first frame update
    void Start()
    {
        for (int x = gridBoundStartX; x < gridBoundEndX; x++)
        { // For every tile between the grid x start and end,
            for (int y = gridBoundStartY; y < gridBoundEndY; y++)
            { // For every tile between the grid y start and end,
                TileBase tileBase = tiles.GetTile(new Vector3Int(x, y, 0)); // Grabs and stores the tile base of the current tile
                if (tileBase != null)
                { // If the tile base is not null (If the tile exists),
                    tileBase.name = "NormalTile"; // Set the tile's name to Normal Tile
                }
            }
        }
    }
}
