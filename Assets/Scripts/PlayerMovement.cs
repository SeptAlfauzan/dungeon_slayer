using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    // public Transform transform;
    public SpriteRenderer spriteRenderer;
    public Vector2 speed = new Vector2(5, 5);
    public Animator PlayerAnimator;
    public new Rigidbody2D rigidbody;
    public bool isFlipped = false;
    bool isMoveDisable = false;
    Vector2 input;
    float playerAttack;
    int clickCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        playerAttack = Input.GetAxis("Fire1");
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

// change animation to attack
        // PlayerAttack(playerAttack);
// change idle animation to run animation
        float animatorSpeed = GetSetSpeedAnimator(input);
        PlayerAnimator.SetFloat("Speed", animatorSpeed);

    Debug.Log(animatorSpeed);
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

    void PlayerAttack(float attackInput){
        // Debug.Log(attackInput);
        bool statusAttack1 = false;
        if(attackInput > 0){
            clickCount++;
            isMoveDisable = true;
            statusAttack1 = true;
        }else{
            isMoveDisable = false;
        }
        // if(clickCount == 2){
        // Debug.Log(clickCount);
        //     PlayerAnimator.SetBool("Attack2", true);
        //     clickCount = 0;
        // }else{
        //     PlayerAnimator.SetBool("Attack2", false);
        // }
            PlayerAnimator.SetBool("Attack1", statusAttack1);
    }

    float GetSetSpeedAnimator(Vector2 inputAxis){
        if(Mathf.Abs(inputAxis.x) > 0 || Mathf.Abs(inputAxis.y) > 0){
            return 1;
        }
        return -1;
    }
}