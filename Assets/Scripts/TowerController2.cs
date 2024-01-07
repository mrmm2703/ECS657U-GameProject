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
        SetShootRate(3f);
    }

    protected override string CurrentStats()
    {
        return "Layer Penetration: " + GetPenetrationLayers(upgradeLevel).ToString() + ", Splash Radius: " + GetSplashRadius(upgradeLevel).ToString();
    }

    protected override int GetLevelCost(int level)
    {
        return Mathf.FloorToInt((10 * level) + initialCost);
    }

    protected override string NextLevelStats()
    {
        return "Layer Penetration: " + (GetPenetrationLayers(upgradeLevel + 1)).ToString() + ", Splash Radius: " + GetSplashRadius(upgradeLevel + 1).ToString();
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
        throw new System.NotImplementedException();
    }
}



