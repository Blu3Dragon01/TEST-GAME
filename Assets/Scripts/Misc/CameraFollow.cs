using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //This script will be attached to the main camera and follow a target.
    //It requires:
    //1. A reference to the player transform position
    //2. Minimum/Maximum X and Y clamp values (areas where the camera cannot go past on the X and Y)
    //3. A way to smoothly move while following the character

    [SerializeField] Transform targetPlayer;

    [SerializeField] float minXClamp;
    [SerializeField] float maxXClamp;
    [SerializeField] float minYClamp;
    [SerializeField] float maxYClamp;

    [SerializeField] float smoothTime = 0.2f;

    private Vector3 velocity;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cameraPos = transform.position;

        cameraPos.x = Mathf.Clamp(targetPlayer.transform.position.x,minXClamp, maxXClamp);
        cameraPos.x = Mathf.Clamp(targetPlayer.transform.position.y, minYClamp, maxYClamp);
        transform.position = Vector3.SmoothDamp(transform.position, cameraPos, ref velocity, smoothTime);
    }
}
