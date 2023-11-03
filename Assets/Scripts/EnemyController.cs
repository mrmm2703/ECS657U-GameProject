using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private float speed = 1f;
    private int layers = 1;
    private bool activated;

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    public void Setup(float enemySpeed, int enemyLayers)
    {
        speed = enemySpeed;
        layers = enemyLayers;
    }

    public void Activate()
    {
        activated = true;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TurnLandmark")
        {
            Vector3 eulerRotation = new Vector3(other.gameObject.transform.eulerAngles.x, other.gameObject.transform.eulerAngles.y+90, other.gameObject.transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
        if (other.gameObject.tag == "DespawnLandmark")
        {
            Destroy(this.gameObject);
            StorageController.RemoveHealthPoints(layers);
            if (StorageController.GetHealthPoints() < 1)
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
        if (other.gameObject.tag == "Projectile")
        {
            TakeHit(other.gameObject);
        }
        if (other.gameObject.tag == "Projectile2")
        {
            Debug.Log("projetcviel2");
            other.GetComponent<Projectile2>().DestroySelf();
            StorageController.AddGamePoints(1);
        }
    }

    private void TakeHit(GameObject projectile)
    {
        layers = layers - projectile.GetComponent<Projectile>().GetLayerPenetration();
        if (layers < 1)
        {
            projectile.GetComponent<Projectile>().HitEnemy();
            Destroy(this.gameObject);
            StorageController.AddGamePoints(1);
        }
    }
}
