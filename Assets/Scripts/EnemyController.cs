using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private float speed = 1f;
    private int layers = 1;
    private bool activated;

    private SoundController soundController;

    // Move on every frame if active
    void Update()
    {
        if (activated)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    // Run before activating to setup speed and layers
    public void Setup(float enemySpeed, int enemyLayers)
    {
        speed = enemySpeed;
        layers = enemyLayers;
    }

    // Activate the enemy and begin moving
    public void Activate()
    {
        activated = true;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Change rotation 
        if (other.gameObject.tag == "TurnLandmark")
        {
            Vector3 eulerRotation = new Vector3(other.gameObject.transform.eulerAngles.x, other.gameObject.transform.eulerAngles.y+90, other.gameObject.transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
        // Destory self and remove health points from player
        if (other.gameObject.tag == "DespawnLandmark")
        {
            soundController.PlaySound(SoundController.Sound.Uhh);
            StorageController.RemoveHealthPoints(layers);
            if (StorageController.GetHealthPoints() < 1)
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Projectile")
        {
            TakeHit(other.gameObject);
            soundController.PlaySound(SoundController.Sound.Pop);
        }
        if (other.gameObject.tag == "Projectile2")
        {
            Debug.Log("projetcviel2");
            other.GetComponent<Projectile2>().DestroySelf();
            StorageController.AddGamePoints(1);
            soundController.PlaySound(SoundController.Sound.Pop);
        }
    }

    // Remove layers destroyed by projectile
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

    private void Start()
    {
        soundController = SoundController.GetControllerInScene();
    }
}
