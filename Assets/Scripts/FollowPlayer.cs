using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    Vector2 playerAxis;

    // Update is called once per frame
    void Update()
    {
        playerAxis = GameObject.Find("Player").GetComponent<PlayerMovement>().input;
        // Debug.Log("x = " + playerAxis.x + " ,y = "+ playerAxis.y);
        if ((playerAxis.x != offset.x) || (playerAxis.y != offset.y))
            offset = new Vector3(playerAxis.x, playerAxis.y, -1); 
        
        transform.position = (player.position + offset);
    }
}
