using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    public GameObject projectile;
    public float turnSpeed = 10f;
    public Transform partToRotate;
    public Transform partToShootFrom;
    private List<GameObject> enemiesInRange = new List<GameObject>();
    private SoundController soundController;

    protected int upgradeLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        soundController = SoundController.GetControllerInScene();
        Init();
    }

    protected abstract void Init();

    protected void SetShootRate(float repeatEverySeconds)
    {
        CancelInvoke("DoAction");
        InvokeRepeating("DoAction", Random.Range(0f, 2f), repeatEverySeconds);
    }

    private void DoAction()
    {
        if (enemiesInRange.Count > 0)
        {
            GameObject other = enemiesInRange[0];
            while (other == null)
            {
                enemiesInRange.RemoveAt(0);
                if (enemiesInRange.Count > 0)
                {
                    other = enemiesInRange[0];
                }
                else
                {
                    break;
                }
            }
            if (other != null)
            {

                Vector3 dir = other.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(-90f, rotation.y, 0f);

                ShootProjectile(other);
            }
        }
    }

    protected abstract void ShootProjectile(GameObject other);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(other.gameObject);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    protected void PlaySound(SoundController.Sound soundToPlay)
    {
        soundController.PlaySound(soundToPlay);
    }

    public int CurrentValue()
    {
        return GetLevelCost(upgradeLevel);
    }

    public int UpgradeCost()
    {
        return GetLevelCost(upgradeLevel + 1);
    }

    protected abstract int GetLevelCost(int level);

    public void UpgradeTower()
    {
        if (StorageController.RemoveGamePoints(UpgradeCost()))
        {
            upgradeLevel = upgradeLevel + 1;
            DoUpgrade(upgradeLevel);
        }
    }

    protected abstract void DoUpgrade(int newLevel);

    protected abstract string CurrentStats();
    protected abstract string NextLevelStats();
}
