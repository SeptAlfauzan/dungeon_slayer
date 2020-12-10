using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPosition : MonoBehaviour
{
    public Transform unit;
    public Vector3 offset;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = cam.WorldToScreenPoint(unit.position + offset);

        if (transform.position != position)
            transform.position = position;
    }
}
