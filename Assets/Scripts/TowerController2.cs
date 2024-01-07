using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Controller for the towers to perform certain actions, and detect enemies within the tower collider
public class TowerController2 : BaseTower
{
    private int initialCost = 50;

    protected override void Init()
    {
        SetShootRate(CalculateShootRate(upgradeLevel));
    }

    public override string CurrentStats()
    {
        return "Layer Penetration: " + GetPenetrationLayers(upgradeLevel).ToString() + ", Splash Radius: " + GetSplashRadius(upgradeLevel).ToString() + "Attack Delay: " + CalculateShootRate(upgradeLevel).ToString("F2") + "s";
    }

    protected override int GetLevelCost(int level)
    {
        return Mathf.FloorToInt((10 * level) + initialCost);
    }

    private float CalculateShootRate(int level)
    {
        return 0.5f * (5 * Mathf.Pow(2, ((level * -1) / 2f)) + 1);
    }

    public override string NextLevelStats()
    {
        return "Layer Penetration: " + (GetPenetrationLayers(upgradeLevel + 1)).ToString() + ", Splash Radius: " + GetSplashRadius(upgradeLevel + 1).ToString() + "Attack Delay: " + CalculateShootRate(upgradeLevel).ToString("F2") + "s";
    }

    private float GetSplashRadius(int level)
    {
        return (float) (1.4427 * Mathf.Log(level + 1));
    }

    private int GetPenetrationLayers(int level)
    {
        return level;
    }

    protected override void ShootProjectile(GameObject other)
    {
        GameObject projectileInstance = Instantiate(projectile, partToShootFrom.position, Quaternion.identity);
        projectileInstance.GetComponent<Projectile2>().Setup(other.transform, GetSplashRadius(upgradeLevel), GetPenetrationLayers(upgradeLevel));
        PlaySound(SoundController.Sound.Boom);
    }

    protected override void DoUpgrade(int level)
    {
        SetShootRate(CalculateShootRate(upgradeLevel));
        return;
    }
}



