using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    // public Transform transform;
    public SpriteRenderer spriteRenderer;
    public Vector2 speed = new Vector2(20, 20);
    public Rigidbody2D rigidbody;

    bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if(Input.GetAxis("Horizontal") < 0){
            isFlipped = true;
            Flip(isFlipped);
        }
        if(Input.GetAxis("Horizontal") > 0){
            isFlipped = false;
            Flip(isFlipped);
        }

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
    void Flip(bool isFlipped){
        spriteRenderer.flipX = isFlipped;
    }
}