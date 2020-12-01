using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    // public Transform transform;
    public SpriteRenderer spriteRenderer;
    public Vector2 speed = new Vector2(20, 20);

    Vector2 input;
    public Rigidbody2D rigidbody;
    bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if(Input.GetAxis("Horizontal") < 0){
            isFlipped = true;
            Flip(isFlipped);
        }
        if(Input.GetAxis("Horizontal") > 0){
            isFlipped = false;
            Flip(isFlipped);
        }

        Vector2 movement = new Vector2(speed.x * input.x, speed.y * input.y);
        movement *= Time.deltaTime;

        rigidbody.MovePosition(rigidbody.position + movement);
    }
        // Update is called once per frame
    void FixedUpdate() {
        
    }
    void Flip(bool isFlipped){
        spriteRenderer.flipX = isFlipped;
    }
}