using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform cameraTransform;

    public float mouseSpeed = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float actualSpeed = mouseSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                actualSpeed = actualSpeed * 2;
            }
            yaw += actualSpeed * Input.GetAxis("Mouse X");
            pitch -= actualSpeed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        } else
        {
            float actualSpeed = speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                actualSpeed = actualSpeed * 3;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * actualSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * Time.deltaTime * actualSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * actualSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * actualSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0, 5 * Time.deltaTime * actualSpeed * -1, 0), Space.World);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0, 5 * Time.deltaTime * actualSpeed, 0), Space.World);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                cameraTransform.Rotate(new Vector3(5 * Time.deltaTime * actualSpeed, 0, 0), Space.Self);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                cameraTransform.Rotate(new Vector3(5 * Time.deltaTime * actualSpeed * -1, 0, 0), Space.Self);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                cameraTransform.Translate(Vector3.down * Time.deltaTime * actualSpeed, 0);
            }
            if (Input.GetKey(KeyCode.E))
            {
                cameraTransform.Translate(Vector3.up * Time.deltaTime * actualSpeed, 0);
            }
        }

        
    }
}
