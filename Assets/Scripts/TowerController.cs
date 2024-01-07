using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : BaseTower
{
    private int initialCost = 20;

    protected override void Init()
    {
        SetShootRate(1.5f);
    }

    protected override string CurrentStats()
    {
        return "Layer Penetration: " + GetPenetrationLayers(upgradeLevel).ToString();
    }

    protected override int GetLevelCost(int level)
    {
        return Mathf.FloorToInt((8 * level) + initialCost);
    }

    private int GetPenetrationLayers(int level)
    {
        return level;
    }

    protected override string NextLevelStats()
    {
        return "Layer Penetration: " + (GetPenetrationLayers(upgradeLevel + 1)).ToString();
    }

    protected override void ShootProjectile(GameObject other)
    {
        GameObject projectileInstance = Instantiate(projectile, partToShootFrom.position, Quaternion.identity);
        PlaySound(SoundController.Sound.Phewm);
        Vector3 shootDirection = (other.transform.position - partToShootFrom.position).normalized;
        projectileInstance.GetComponent<Projectile>().Setup(shootDirection, GetPenetrationLayers(upgradeLevel));
    }

    protected override void DoUpgrade(int newLevel)
    {
        return;
    }
}
