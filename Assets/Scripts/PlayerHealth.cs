using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
	{
		maxHealth -= damage;
        Debug.Log("attacked");
        GetComponent<PlayerMovement>().PlayerAnimator.SetTrigger("Damaged");
		if (maxHealth <= 0)
		{
			Die();
		}
	}

    void Die(){
        Debug.Log("you died");
        GetComponent<PlayerMovement>().PlayerAnimator.SetBool("Dead", true);
        
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
