using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   
    public Animator animator;
    Rigidbody2D player;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    bool isFlipped;
    public int attackDamage = 10;
    // Update is called once per frame
    void Update()
    {
        isFlipped = FindObjectOfType<PlayerMovement>().isFlipped;
        if(Input.GetAxis("Fire1") > 0){
            Attack();
        }
    }
    void Attack(){
        Debug.Log(FindObjectOfType<PlayerMovement>().isFlipped);
        // if((isFlipped && attackPoint.position.x > 0) || (!isFlipped && attackPoint.position.x < 0)){
        //     attackPoint.position = new Vector3(-1 * attackPoint.position.x, attackPoint.position.y, attackPoint.position.z);
        // }else{
        //     attackPoint.position = new Vector3(attackPoint.position.x, attackPoint.position.y, attackPoint.position.z);
        // }
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
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
