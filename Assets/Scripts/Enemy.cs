using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxhealth = 200;
    public Animator animator;
    public SpriteRenderer enemy;
    public Transform player;
    int currentHealth;
    // Rigidbody2D rigidbody;
    void Start()
    {
        currentHealth = maxhealth;
    }

    void Update() {
        if (transform.position.x > player.position.x)
        {
            enemy.flipX = true;
        }else{
            enemy.flipX = false;
        }
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Damaged");
        currentHealth = currentHealth - damage;
        Debug.Log("current health" + currentHealth);
        if(currentHealth <= 0){
            // Rigidbody2D.constraints =  RigidbodyConstraints2D.FreezeAll;
            Die();
        }
    }

    void Die(){
        Debug.Log("im dead");
        animator.SetBool("Dead", true);
        DisableAllColliders();
        
        this.enabled = false;
    }

    void DisableAllColliders(){
        foreach (Collider2D collider in GetComponents<Collider2D>())
        {
            collider.enabled = false;
        }
    }
}
