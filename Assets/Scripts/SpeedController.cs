using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public static float GameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GameSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void X1()
    {
        Time.timeScale = 1.0f;
        GameSpeed = 1.0f;
    }

    public void X2()
    {
        Time.timeScale = 2.0f;
        GameSpeed = 2.0f;
    }

    public void X3()
    {
        Time.timeScale = 3.0f;
        GameSpeed = 3.0f;
    }

}
