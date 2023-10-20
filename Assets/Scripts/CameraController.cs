using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int speed = 1;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 5 * Time.deltaTime * speed * -1, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 5 * Time.deltaTime * speed, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            cameraTransform.Rotate(new Vector3(5 * Time.deltaTime * speed, 0, 0), Space.Self);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cameraTransform.Rotate(new Vector3(5 * Time.deltaTime * speed * -1, 0, 0), Space.Self);
        }
    }
}
