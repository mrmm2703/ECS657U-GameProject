using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1.0f;
    public float maxCamAngle = 60f;
    public Transform cameraTransform;
    public BoxCollider cameraBounds;

    public float mouseSpeed = 2.0f;

    // Store the camera rotation using mouse
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        float actualSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            actualSpeed = actualSpeed * 3;
        }
        // Camera movement
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 newPosition = transform.position + (Vector3.forward * Time.deltaTime * actualSpeed);
            if (cameraBounds.bounds.Contains(newPosition))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * actualSpeed);
            }
            else
            {
                transform.Translate(Vector3.back * Time.deltaTime * actualSpeed * 2);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 newPosition = transform.position + (Vector3.back * Time.deltaTime * actualSpeed);
            if (cameraBounds.bounds.Contains(newPosition))
            {
                transform.Translate(Vector3.back * Time.deltaTime * actualSpeed);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * actualSpeed * 2);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 newPosition = transform.position + (Vector3.left * Time.deltaTime * actualSpeed);
            if (cameraBounds.bounds.Contains(newPosition))
            {
                transform.Translate(Vector3.left * Time.deltaTime * actualSpeed);
            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * actualSpeed * 2);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 newPosition = transform.position + (Vector3.right * Time.deltaTime * actualSpeed);
            if (cameraBounds.bounds.Contains(newPosition))
            {
                transform.Translate(Vector3.right * Time.deltaTime * actualSpeed);
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * actualSpeed * 2);
            }
        }

        // Camera height
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 newPosition = transform.position + (Vector3.down * Time.deltaTime * actualSpeed);
            if (cameraBounds.bounds.Contains(newPosition))
            {
                transform.Translate(Vector3.down * Time.deltaTime * actualSpeed);
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime * actualSpeed * 2);
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 newPosition = transform.position + (Vector3.up * Time.deltaTime * actualSpeed);
            if (cameraBounds.bounds.Contains(newPosition))
            {
                transform.Translate(Vector3.up * Time.deltaTime * actualSpeed);
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * actualSpeed * 2);
            }
        }

        // Mouse right click camera rotation
        if (Input.GetMouseButton(1))
        {
            actualSpeed = mouseSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                actualSpeed = actualSpeed * 2;
            }
            yaw += actualSpeed * Input.GetAxis("Mouse X");
            pitch -= actualSpeed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        } else
        {
            // Camera rotation
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
                Vector3 newVector = new Vector3(5 * Time.deltaTime * actualSpeed, 0 , 0);
                if (camInRange(cameraTransform.rotation.eulerAngles.x + newVector.x))
                    cameraTransform.Rotate(newVector, Space.Self);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 newVector = new Vector3(5 * Time.deltaTime * actualSpeed * -1, 0, 0);
                if (camInRange(cameraTransform.rotation.eulerAngles.x + newVector.x))
                    cameraTransform.Rotate(newVector, Space.Self);
            }
        }
        
    }

    private bool camInRange(float newRotationX)
    {
        if (newRotationX > 0+maxCamAngle && newRotationX < 360-maxCamAngle) return false;
        return true;
    }
}
