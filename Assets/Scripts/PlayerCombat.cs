using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    Rigidbody2D player;
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    bool isFlipped;
    Vector3 attackPointNormal = new Vector3(0.81f, 0.12f, 0);
    Vector3 attackPointFlipped = new Vector3(-0.81f, 0.12f, 0);
    
    void Update()
    {
        isFlipped = FindObjectOfType<PlayerMovement>().isFlipped;
        if(isFlipped){
            attackPoint.localPosition = attackPointFlipped;
        }else{
            attackPoint.localPosition = attackPointNormal;
        }

        // Debug.Log(isFlipped);
        if (Time.time >= nextAttackTime)
        {    
            if(Input.GetAxis("Fire1") > 0){
                TrigerAttack();
                // Attack();
                nextAttackTime = Time.time + 1.8f / attackRate;
            }
        }
    }

    void TrigerAttack(){
        animator.SetTrigger("Attack");
        //attack function will call on on event attack animation
    }
    void Attack(){
        // Debug.Log(FindObjectOfType<PlayerMovement>().isFlipped);
        // if((isFlipped && attackPoint.position.x > 0) || (!isFlipped && attackPoint.position.x < 0)){
        //     attackPoint.position = new Vector3(-1 * attackPoint.position.x, attackPoint.position.y, attackPoint.position.z);
        // }else{
        //     attackPoint.position = new Vector3(attackPoint.position.x, attackPoint.position.y, attackPoint.position.z);
        // }
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            // Debug.Log(enemy.name);
        }
    }
     void OnDrawGizmosSelected() {
         if (attackPoint == null)
         {
             return;
         }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
