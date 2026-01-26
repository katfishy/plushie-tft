using UnityEngine;

public class Board_Initiate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int column = 8;
    private int row = 4;
    public float tileSize = 0.2f;
    public Tile tilePrefab;
    private Tile[,] tiles;

    void Start()
    {
        generate_board();
    }

    void generate_board(){
        Tile[,] tiles = new Tile[row, column];
        for (int i = 0; i < row; i++){
            for (int j = 0; j < column; j++){
                Vector3 tile_location = new Vector3(i*tileSize, 0f, j*tileSize);
                Tile tile = Instantiate(tilePrefab, tile_location, Quaternion.identity, transform);

                tile.coord = (i,j);
                tile.occupied = false;
                //tile.occupant = null;

                tiles[i, j] = tile;
            }

        }
    } 
}
