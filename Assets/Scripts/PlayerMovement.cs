using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Class for the player movement
// By pressing one of the movement buttons, this code moves the player to the respective tile, while limiting the player's movement in a turn depending on their movement points.
public class PlayerMovement : MonoBehaviour
{
    public Tilemap tileMap; // Stores the tile map
    [Header("Movement")]
    public int movementPoints; // Stores the movement points
    public int maxMovementPoints; // Stores the max amount of movement points 
    private Vector3Int startTile; // Stores the start tile
    [Header("Button Directions")]
    private float x; // Stores the x value (changes depending if the player is moving right or left)
    private float y; // Stores the y value (changes depending on the exact button pressed to move)

    // Start is called before the first frame update
    private void Start()
    {
        movementPoints = 0; // Set movement points to 0
        maxMovementPoints = 8; // Set the maximum movement points to 8
    }
    
    // Function for moving right
    public void MoveRight(float yDirection)
    {
        y = yDirection; // Set the y to the y direction of a pressed button
        x = 0.75f; // Set x to 0.75
        transform.localScale = new Vector3(1.5f, 1.5f, 1); // Set the local scale to face right
        Move(); // Run the move function
    }
    // Function for moving left
    public void MoveLeft(float yDirection)
    {
        y = yDirection; // Set the y to the y direction of a pressed button
        x = -0.75f; // Set x to -0.75
        transform.localScale = new Vector3(-1.5f, 1.5f, 1); // Set the local scale to face left
        Move(); // Run the move function
    }

    // Called whenever a collision is detected
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var centerStartTile = tileMap.GetCellCenterWorld(startTile); // Get and set the center of the starting tile
            transform.position = centerStartTile; // Set the object position to the center of the start tile
            movementPoints++; // Add a movement point
        }
    }

    // Function for moving
    void Move()
    {
        if (movementPoints > 0)
        { // If the movement points are greater than 0,
            startTile = tileMap.WorldToCell(transform.position); // Set the start tile to the tile at the current position of this game object
            var moveDirection = tileMap.GetCellCenterWorld(startTile) + new Vector3(x, y, 0); // Create and set the move direction to the center of the start tile, plus the x and y values
            var tilePosition = tileMap.WorldToCell(moveDirection); // Create and set the tile position to the tile positioned at the move direction
            var tileBase = tileMap.GetTile(tilePosition); // Create and set the tile base to the tile position
            if (tileBase != null)
            { // If the tile base is not null (If the tile exists),
                if (tileBase.name == "NormalTile")
                { // If the tile is named "Normal Tile",
                    var tileCentre = tileMap.GetCellCenterWorld(tilePosition); // Create and set the tile centre to the centre of the tile
                    transform.position = tileCentre; // Set this game object's position to the tile centre
                    movementPoints--; // Remove 1 from the movement points
                }
            }
        }
    }
}
