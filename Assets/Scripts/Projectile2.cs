using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    private Transform shootDirection;
    public float explosionRadius = 0f;
    public float speed = 30.00f;
    public Material explosionMaterial;
    private GameObject explosionObject;

    // Update is called once per frame
    void Update()
    {
        if (shootDirection == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = shootDirection.position - transform.position;
        float distanceInFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceInFrame) { 
            DestroySelf(); 
        }

        transform.Translate(dir.normalized * distanceInFrame, Space.World);
    }

    public void Setup(Transform ShootDirection)
    {
        shootDirection = ShootDirection;
        
    }

    public void DestroySelf()
    {
        if (explosionRadius > 0f)
        {
            Debug.Log("explosion > 0");
            Explode();
        }
        else
        {
            Debug.Log("explision > 0 NOT");
            Damage(shootDirection);
        }

        Destroy(shootDirection.gameObject);
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] hitobject = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in hitobject)
        {
            if (col.tag == "Enemy")
            {
                Damage(col.transform);
            }
        }
    }

    void DestroyExplosion()
    {
        Debug.Log("DESTORY MEEEE!");
        Destroy(explosionObject.gameObject);
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

}
