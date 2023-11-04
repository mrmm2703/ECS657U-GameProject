using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChooser : MonoBehaviour
{
    public List<GameObject> towers;
    public List<int> towerCosts;
    private Node node;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void SetNode(Node nodeToPlaceAt)
    {
        node = nodeToPlaceAt;
        this.gameObject.SetActive(true);
    }

    public void AddBasicTower()
    {
        AddTower(0);
    }

    public void AddBombTower()
    {
        AddTower(1);
    }

    public void AddTower(int towerId)
    {
        if (node != null)
        {
            node.AddTower(towers[towerId], towerCosts[towerId]);
        }
        CloseChooser();
    }

    public void CloseChooser()
    {
        this.gameObject.SetActive(false);
    }
}
