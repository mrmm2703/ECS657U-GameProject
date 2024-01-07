using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    // Public variables that can be assigned with their respective types
    public TowerChooser towerChooser;
    public GameObject tower;
    public Color hovercolor;

    // Private fixed variables
    private int towervalue = 10;
    private Renderer ren;
    private Color startcolor;
    private GameObject towerOnNode = null;
    private bool hasTower = false;
    private SoundController soundController;

    // Initialising the start color of the node
    void Start()
    {
        ren = GetComponent<Renderer>();
        startcolor = ren.material.color;
        soundController = SoundController.GetControllerInScene();
    }

    // As the mouse hovers over the node the color changes based on whether there is a tower on it or not
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (hasTower)
        {
            ren.material.color = startcolor;
        }
        else
        {
            ren.material.color = hovercolor;
        }
    }



    // As the mouse exits the color reverts back to the start color
    void OnMouseExit()
    {
        ren.material.color = startcolor;
    }

    // A tower is added based on the game points the player has, and then realises there is a tower there
    public void AddTower(GameObject towerToAdd, int costOfTower)
    {
        if (hasTower) return;
        towervalue = costOfTower;
        if (StorageController.RemoveGamePoints(towervalue))
        {
            towerOnNode = Instantiate(towerToAdd, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
            hasTower = true;
        }
    }

    public void RemoveTower()
    {
        if (hasTower)
        {
            Destroy(towerOnNode);
            StorageController.AddGamePoints(towervalue / 2);
            hasTower = false;
        }
    }

    // As the mouse clicks, the tower chooser menu appears as long as there is no tower on the node. Re-clicking the tower sells the tower at half its purchase price
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        soundController.PlaySound(SoundController.Sound.Click);

        towerChooser.SetNode(this);
        return;

    }
}
