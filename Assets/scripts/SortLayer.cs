using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortLayer : MonoBehaviour {
    public string sortLayerName;

    void Start()
    {
        //get each of the sprites that are child of the game object that the script is attached to
        foreach(SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.GetComponent<Renderer>().sortingLayerName = sortLayerName;
        }
    }
}
