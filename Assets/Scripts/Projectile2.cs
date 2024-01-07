using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{

    // Public variables to be adjusted within the unity editor and for assignments
    private float explosionRadius;
    public float speed = 30.00f;
    public Material explosionMaterial;
    private int layerPenetration;

    // Private fixed variables
    private Transform shootDirection;
    private GameObject explosionObject;

    // Update is called once per frame
    void Update()
    {
        if (shootDirection == null)
        {
            Destroy(gameObject);
            return;
        }

        // Variables to retrieve information on the enemy position
        Vector3 dir = shootDirection.position - transform.position;
        float distanceInFrame = speed * Time.deltaTime;

        // If the magnitude is within the distance in the frame then the DestroySelf function is called
        if (dir.magnitude <= distanceInFrame) { 
            DestroySelf(); 
        }

        // Moves the projectile towards the enemy, like a homing missile
        transform.Translate(dir.normalized * distanceInFrame, Space.World);
    }

    // Makes the shooting direction equal to whatever parameters it is fed
    public void Setup(Transform ShootDirection, float splashRadius, int layerPen)
    {
        explosionRadius = splashRadius;
        shootDirection = ShootDirection;
        layerPenetration = layerPen;
        
    }

    // This explodes/damages the enemy based on the condition of the explosion radius being greater than 0
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

        // Destroys both game objects if the conditions just in case the conditions aren't followed
        Destroy(shootDirection.gameObject);
        Destroy(gameObject);
    }

    
    // Produces a spherical collider that checks what enemies are inside it, then proceeds to damage the enemies within the explosion radius
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

    // To be continued
    void DestroyExplosion()
    {
        Debug.Log("DESTORY MEEEE!");
        Destroy(explosionObject.gameObject);
    }

    public int GetLayerPenetration()
    {
        return layerPenetration;
    }

    // Destroys the enemy
    void Damage(Transform enemy)
    {
        enemy.gameObject.GetComponent<EnemyController>().TakeHit(GetLayerPenetration());
    }

}
