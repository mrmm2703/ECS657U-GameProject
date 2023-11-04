using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public TowerChooser towerChooser;
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

    public void AddTower(GameObject towerToAdd, int costOfTower)
    {
        towervalue = costOfTower;
        if (StorageController.RemoveGamePoints(towervalue))
        {
            towerOnNode = Instantiate(towerToAdd, transform.position, Quaternion.identity);
            hasTower = true;
        }
    }

    private void OnMouseDown()
    {
        if (!hasTower)
        {
            towerChooser.SetNode(this);
            return;
        }
        else
        {
            Destroy(towerOnNode);
            StorageController.AddGamePoints(towervalue / 2);
            hasTower = false;
        }
    }
}
