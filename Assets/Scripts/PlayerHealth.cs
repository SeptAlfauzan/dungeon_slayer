using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Healthbar healthbar;
    public int maxHealth = 100;
    int currentHealth;
    
    private void Start() {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);    
    }
    // Start is called before the first frame update
    public void TakeDamage(int damage)
	{
		currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        // Debug.Log("attacked");
        GetComponent<PlayerMovement>().PlayerAnimator.SetTrigger("Damaged");
		if (currentHealth <= 0)
		{
			Die();
            ShowDeathScreen();
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

    void ShowDeathScreen(){
        var deathScreen = GameObject.Find("Player Died Screen").GetComponent<Canvas>();
        deathScreen.enabled = true;
    }
}
