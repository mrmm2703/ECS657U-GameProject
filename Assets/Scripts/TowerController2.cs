using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Controller for the towers to perform certain actions, and detect enemies within the tower collider
public class TowerController2 : BaseTower
{
    protected override void ShootProjectile(GameObject other)
    {
        GameObject projectileInstance = Instantiate(projectile, partToShootFrom.position, Quaternion.identity);
        projectileInstance.GetComponent<Projectile2>().Setup(other.transform);
        PlaySound(SoundController.Sound.Boom);
    }
}



