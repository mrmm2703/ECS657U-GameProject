using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChooser : MonoBehaviour
{
    // List of towers and the cost associated with that tower
    public List<GameObject> towers;
    public List<int> towerCosts;

    // Reference to the node where a tower will be placed
    private Node node;

    private SoundController soundController;

    // On start we are making sure that you cannot see the tower chooser panel
    private void Start()
    {
        this.gameObject.SetActive(false);
        soundController = SoundController.GetControllerInScene();
    }

    // Set the node where you want a tower to be placed and show the tower chooser panel
    public void SetNode(Node nodeToPlaceAt)
    {
        node = nodeToPlaceAt;
        this.gameObject.SetActive(true);
    }

    // Select the towerId of the tower you want and pass it to the AddTower method
    public void AddBasicTower()
    {
        AddTower(0);
    }

    public void AddBombTower()
    {
        AddTower(1);
    }

    // Using the towerId we choose the tower from the list of towers and add it to the node
    public void AddTower(int towerId)
    {
        soundController.PlaySound(SoundController.Sound.Click);
        if (node != null)
        {
            node.AddTower(towers[towerId], towerCosts[towerId]);
        }
        CloseChooser();
    }

    // Close the tower chooser panel
    public void CloseChooser()
    {
        this.gameObject.SetActive(false);
    }
}
