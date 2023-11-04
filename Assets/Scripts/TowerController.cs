using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject projectile;
    private List<GameObject> projectilesInRange = new List<GameObject>();
    private SoundController soundController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DoAction", Random.Range(0f, 2f), 1.5f);
        soundController = SoundController.GetControllerInScene();
    }

    private void DoAction()
    {
        if (projectilesInRange.Count > 0)
        {
            GameObject other = projectilesInRange[0];
            while (other == null)
            {
                if (projectilesInRange.Count > 0)
                {
                    other = projectilesInRange[0];
                    projectilesInRange.RemoveAt(0);
                } else
                {
                    break;
                }
            }
            if (other != null)
            {
                GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);
                soundController.PlaySound(SoundController.Sound.Phewm);
                Vector3 shootDirection = (other.transform.position - transform.position).normalized;
                projectileInstance.GetComponent<Projectile>().Setup(shootDirection);
                projectilesInRange.RemoveAt(0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            projectilesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            projectilesInRange.Remove(other.gameObject);
        }
    }
}
