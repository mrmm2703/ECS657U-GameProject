using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Controller for the towers to perform certain actions, and detect enemies within the tower collider
public class TowerController2 : MonoBehaviour
{
    private SoundController soundController;

    // Allows assignment of a specified projectile type
    public GameObject projectile;
    public float turnSpeed = 10f;
    public Transform partToRotate;
    public Transform partToShootFrom;
    // Stores a list of specified enemies in range
    private List<GameObject> enemiesInRange = new List<GameObject>();

    // Start is called before the first frame update, it invokes the DoAction function every 1.5 seconds, and the range is after how long the towers shoot the bullets.
    void Start()
    {
        soundController = SoundController.GetControllerInScene();
        InvokeRepeating("DoAction", Random.Range(0f, 2f), 1.5f);
    }

    // Performs the action of shooting a projectile given the circumstances of the game objects on the map
    private void DoAction()
    {
        if (enemiesInRange.Count > 0)
        {
            GameObject other = enemiesInRange[0];
            while (other == null)
            {
                if (enemiesInRange.Count > 0)
                {
                    other = enemiesInRange[0];
                    enemiesInRange.RemoveAt(0);
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
                partToRotate.rotation = Quaternion.Euler(-90f, rotation.z, 0);

                GameObject projectileInstance = Instantiate(projectile, partToShootFrom.position, Quaternion.identity);
                projectileInstance.GetComponent<Projectile2>().Setup(other.transform);
                soundController.PlaySound(SoundController.Sound.Boom);
                enemiesInRange.RemoveAt(0);
            }
        }
    }

    // If there is a enemy in the collider, a enemy is added to the list
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    // If an enemy is out of the collider, it is removed from the list
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}
