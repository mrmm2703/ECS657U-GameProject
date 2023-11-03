using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootDirection;
    public float speed = 100f;
    private int layerPenentration = 1;

    void Update()
    {
        transform.position += shootDirection * speed * Time.deltaTime;
    }
    
    public void Setup(Vector3 shootDirection)
    {
        this.shootDirection = shootDirection;
        Invoke("DestroySelf", 3);
    }

    public int GetLayerPenetration()
    {
        return layerPenentration;
    }

    // Run when projectile should destroy itself (e.g. after timeout)
    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    // Called when projectile hits an enemy object
    public void HitEnemy()
    {
        Destroy(this.gameObject);
    }
}
