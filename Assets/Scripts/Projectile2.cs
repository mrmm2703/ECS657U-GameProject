using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    private Transform shootDirection;
    public float explosionRadius = 0.0f;
    public float speed = 30.00f;

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
            Destroy(shootDirection.gameObject);
            Destroy(gameObject);
        }

        transform.Translate(dir.normalized * distanceInFrame, Space.World);
    }

    public void Setup(Transform ShootDirection)
    {
        shootDirection = ShootDirection;
        
    }

    void DestroySelf()
    {
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(shootDirection);
        }

        
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

    void Damage(Transform enemy)
    {
        Destroy(this.gameObject);
    }

}
