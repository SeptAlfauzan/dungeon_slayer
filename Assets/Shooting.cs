using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Vector2 MousePos;
    public Camera cam;
    public Transform firePoint;
    public GameObject bulletPrefab;
    float angle;

    public float bulletForce = 200f;
    // Start is called before the first frame update
    void Update()
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }

    }

    private void FixedUpdate() {
        Rigidbody2D rigidBodyFirePoint = firePoint.GetComponent<Rigidbody2D>();

        Vector2 lookDir = MousePos - rigidBodyFirePoint.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rigidBodyFirePoint.rotation = angle;

        Debug.Log(angle);
    }


    // Update is called once per frame
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        // rb.rotation = rb.rotation + angle;
    }
}
