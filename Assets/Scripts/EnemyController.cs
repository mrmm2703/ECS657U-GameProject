using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            StorageController.RemoveGamePoints(1);
        }
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            StorageController.AddGamePoints(1);
        }
    }
}
