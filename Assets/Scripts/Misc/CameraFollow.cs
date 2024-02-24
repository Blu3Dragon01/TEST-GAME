using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
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
