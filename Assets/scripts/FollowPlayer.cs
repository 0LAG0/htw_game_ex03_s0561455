using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer: MonoBehaviour
{
    public Transform player;

    //zeros out the velocity
    Vector3 velocity = Vector3.zero;

    //time to follow player
    public float smoothTime = .15f;

    //enable and set max y value
    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    //enable and set min y value
    public bool YMinEnabled = false;
    public float YMinValue = 0;

    //enable and set max x 
    public bool XMaxEnabled = false;
    public float XMaxValue = 0;

    //enable and set min x 
    public bool XMinEnabled = false;
    public float XMinValue = 0;


    void FixedUpdate()
    {
        //traget position
        Vector3 targetPos = player.position;

        //vertical
        if(YMinEnabled && YMaxEnabled){
            targetPos.y = Mathf.Clamp(player.position.y, YMinValue, YMaxValue);
        }else if (YMinEnabled){
            targetPos.y = Mathf.Clamp(player.position.y, YMinValue, player.position.y);
        }else if (YMaxEnabled){
            targetPos.y = Mathf.Clamp(player.position.y, player.position.y , YMaxValue);
        }
        //horizontal
        if (XMinEnabled && XMaxEnabled){
            targetPos.x = Mathf.Clamp(player.position.x, XMinValue, XMaxValue);
        }else if (XMinEnabled){
            targetPos.x = Mathf.Clamp(player.position.x, XMinValue, player.position.x);
        }else if (XMaxEnabled){
            targetPos.x = Mathf.Clamp(player.position.x, player.position.x, XMaxValue);
        }

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
