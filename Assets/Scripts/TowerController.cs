using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : BaseTower
{
    protected override void ShootProjectile(GameObject other)
    {
        GameObject projectileInstance = Instantiate(projectile, partToShootFrom.position, Quaternion.identity);
        PlaySound(SoundController.Sound.Phewm);
        Vector3 shootDirection = (other.transform.position - partToShootFrom.position).normalized;
        projectileInstance.GetComponent<Projectile>().Setup(shootDirection);
    }
}
