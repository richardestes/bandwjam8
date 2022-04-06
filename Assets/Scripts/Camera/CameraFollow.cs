using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    
    [SerializeField]
    public Vector3 offset;
    
    [SerializeField][Range(1,10)]
    public float smoothFactor;

    private void Start()
    {
        if (!player) player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if (player)
        {   
            Follow();
        }
    }
    
    void Follow()
    {
        Vector3 playerPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
