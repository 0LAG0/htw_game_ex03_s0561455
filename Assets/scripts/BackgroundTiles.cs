using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTiles : MonoBehaviour {
    // array of prefabs for the tiles
    public GameObject[] tiles;
    //start position of the tiles
    public Vector3 tileStartPos;
    //tile spacing
    Vector2 tileSpacing;
    //grid width
    public int gridWidth;
    //grid height
    public int gridHeight;

    private void Start()
    {
        //get size of tiles
        tileSpacing = tiles[0].GetComponent<Renderer>().bounds.size;
        //loop through rows
        for (int i =0; i< gridHeight; i++)
        {
            //loop through colums
            for(int j =0; j < gridWidth; j++)
            {
                int randomTile = Random.Range(0, tiles.Length);

                GameObject gob = Instantiate(tiles[randomTile], new Vector3(tileStartPos.x + (j * tileSpacing.x), tileStartPos.y + (i * tileSpacing.y)), Quaternion.identity) as GameObject;
                //add all gamme objects as a child of BGTiles
                gob.transform.parent = GameObject.Find("BGTiles").transform;
            }

        }
    }

}
