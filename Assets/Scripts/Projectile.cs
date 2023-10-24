using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootDirection;
    public float speed = 30.00f;

    // Update is called once per frame
    void Update()
    {
        transform.position += shootDirection * 100f * Time.deltaTime;
    }

    public void Setup(Vector3 shootDirection)
    {
        this.shootDirection = shootDirection;
    }
}
