using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject tower;
    public Color hovercolor;
    private int towervalue = 10;
    private Renderer ren;
    private Color startcolor;

    private GameObject towerOnNode = null;

    private bool hasTower = false;

    void Start()
    {
        ren = GetComponent<Renderer>();
        startcolor = ren.material.color;
    }
    void OnMouseEnter()
    {
        if (hasTower)
        {
            ren.material.color = startcolor;
        }
        else
        {
            ren.material.color = hovercolor;
        }
    }

    void OnMouseExit()
    {
        ren.material.color = startcolor;
    }

    private void OnMouseDown()
    {
        if (!hasTower)
        {
            towerOnNode = Instantiate(tower, transform.position, Quaternion.identity);
            StorageController.RemoveGamePoints(towervalue);
            hasTower = true;
        }
        else
        {
            Destroy(towerOnNode);
            StorageController.AddGamePoints(towervalue / 2);
            hasTower = false;
        }
    }
}
