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
    public Vector2 input;

    public ParticleSystem dust;
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

        SetAnimatorMovement(input);//call fucntion that handle movement animation
        // if (!dust.isPlaying)
        // {
        //     dust.Play();
        // }
        CreateDust(input);

        PlayerAnimator.SetFloat("Speed", input.sqrMagnitude);

        if(Input.GetAxis("Horizontal") < 0){
            isFlipped = true;
            // Flip(isFlipped);
        }
        if(Input.GetAxis("Horizontal") > 0){
            isFlipped = false;
            // Flip(isFlipped);
        }

        
    }

    void SetAnimatorMovement(Vector2 movement){
        PlayerAnimator.SetFloat("Horizontal", movement.x);
        PlayerAnimator.SetFloat("Vertical", movement.y);
    }
    void FixedUpdate() {
        Vector2 movement = new Vector2(speed.x * input.x, speed.y * input.y);
        movement *= Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + movement);
    }
    void PlayerAttack(float attackInput){
        // Debug.Log(attackInput);
        bool statusAttack1 = false;
        if(attackInput > 0){
            clickCount++;
            // isMoveDisable = true;
            statusAttack1 = true;
        }else{
            // isMoveDisable = false;
        }
            PlayerAnimator.SetBool("Attack1", statusAttack1);
    }

    void CreateDust(Vector2 movement){
        // create particle effect when player move
        if ((movement.x !=0 || movement.y != 0))
        {    
           if (!dust.isEmitting)
                dust.Play();
        } else if(dust.isEmitting) {
            dust.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

    }

}