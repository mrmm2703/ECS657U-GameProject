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

    // Start is called before the first frame update
    void Start()
    {
        soundController = SoundController.GetControllerInScene();
        InvokeRepeating("DoAction", Random.Range(0f, 2f), 1.5f);
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
}
