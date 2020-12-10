using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Vector3 healthBarOffset;
    public Transform objectUseHealthBar;
    // Update is called once per frame
    void Update()
    {
        transform.position = healthBarOffset + objectUseHealthBar.position;
    }
}
