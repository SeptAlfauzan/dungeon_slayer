using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodges : MonoBehaviour
{
    public Transform enemies;
    bool isDodge = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isDodge = true;
        }
    }

    public bool getDodgeVal(){
        return isDodge;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemies")
        {
            DisableAllCollidersEnemy(collision.gameObject.transform);
            Debug.Log(GetComponent<Collider2D>().name);
        }
    }

    void DisableAllCollidersEnemy(Transform enemies){
        foreach (Collider2D collider in enemies.GetComponents<Collider2D>())
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(),collider,  true);
            Debug.Log(collider.name);
        }
    }

    void DisableAllColliders(){
        foreach (Collider2D collider in GetComponents<Collider2D>())
        {
            collider.enabled = false;
        }
    }
}
