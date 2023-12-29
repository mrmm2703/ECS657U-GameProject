using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void X1()
    {
        Time.timeScale = 1.0f;
    }

    public void X2()
    {
        Time.timeScale = 2.0f;
    }

    public void X5()
    {
        Time.timeScale = 5.0f;
    }

}
