using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    Transform player;

    [SerializeField] float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null)
        {
            Vector3 cameraPosition = transform.position;
            cameraPosition.x = player.position.x;
            if(cameraPosition.x<minX)
            {
                cameraPosition.x = minX;
            }
            if(cameraPosition.x>maxX)
            {
                cameraPosition.x = maxX;
            }
            cameraPosition.y = player.position.y;
            transform.position = cameraPosition;
        }
    }
}
