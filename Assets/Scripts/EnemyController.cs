using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I HIT SOMETHING!");
        if (other.gameObject.tag == "TurnLandmark")
        {
            Vector3 eulerRotation = new Vector3(other.gameObject.transform.eulerAngles.x, other.gameObject.transform.eulerAngles.y+90, other.gameObject.transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
        if (other.gameObject.tag == "DespawnLandmark")
        {
            Debug.Log("YOU MISSED A BALLOON LOSER!!!");
            Destroy(this);
        }
    }
}
