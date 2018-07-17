using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour {

    float sawSpeed = 300;
    void Update()
    {
        transform.Rotate(0, 0, sawSpeed * Time.deltaTime);
    }
}
