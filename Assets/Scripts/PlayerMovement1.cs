using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public BoxCollider cameraBounds;
    private float speed = 25f;

    public Transform orientation;

    float horizontalInp;
    float verticalInp;

    Vector3 moveDir;

    Rigidbody rb;

    private void OnTriggerExit(Collider other)
    {
        MovePlayer(-1, ForceMode.Impulse);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer(1, ForceMode.Force);
    }
    private void MyInput()
    {
        horizontalInp = Input.GetAxisRaw("Horizontal");
        verticalInp = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer(int oppositeOrNot, ForceMode forcetype)
    {
        float modSpeed = speed * (1 / SpeedController.GameSpeed);
        moveDir = (orientation.forward * verticalInp + orientation.right * horizontalInp) * oppositeOrNot;

        rb.AddForce(moveDir.normalized * modSpeed * 10f, forcetype);

    }
}
