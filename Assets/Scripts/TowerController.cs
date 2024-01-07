using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : BaseTower
{
    private int initialCost = 20;

    protected override void Init()
    {
        SetShootRate(CalculateShootRate(upgradeLevel));
    }

    public override string CurrentStats()
    {
        return "Layer Penetration: " + GetPenetrationLayers(upgradeLevel).ToString() + ", Attack Delay: " + CalculateShootRate(upgradeLevel).ToString("F2") + "s";
    }

    protected override int GetLevelCost(int level)
    {
        return Mathf.FloorToInt((8 * level) + initialCost);
    }

    private float CalculateShootRate(int level) {
        return (10f / 31) * (5 * Mathf.Pow(2, ((level * -1) / 2f)) + 1);
    }

    private int GetPenetrationLayers(int level)
    {
        return level;
    }

    public override string NextLevelStats()
    {
        return "Layer Penetration: " + (GetPenetrationLayers(upgradeLevel + 1)).ToString() + ", Attack Delay: " + CalculateShootRate(upgradeLevel + 1).ToString("F2") + "s";
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
        SetShootRate(CalculateShootRate(upgradeLevel));
        return;
    }
}
