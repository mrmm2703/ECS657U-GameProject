using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public GameController gameController;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
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
            StorageController.RemoveHealthPoints(2);
            if (StorageController.GetHealthPoints() < 1)
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("projectile");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            StorageController.AddGamePoints(1);
        }
        if (other.gameObject.tag == "Projectile2")
        {
            Debug.Log("projetcviel2");
            other.GetComponent<Projectile2>().DestroySelf();
            StorageController.AddGamePoints(1);
        }
    }
}
