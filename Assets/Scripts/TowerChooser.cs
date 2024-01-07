using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerChooser : MonoBehaviour
{
    // List of towers and the cost associated with that tower
    public List<GameObject> towers;
    public List<int> towerCosts;

    public List<Button> buyButtons;
    public Button sellButton;
    public Button upgradeButton;
    public TMP_Text upgradeButtonText;
    public TMP_Text levelText;
    public TMP_Text curStatus;
    public TMP_Text upgradedStatus;
    public TMP_Text sellButtonText;
    public GameObject curPanel;
    public GameObject upgradedPanel;

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

        if (node.GetTowerOnNode() == null)
        {
            sellButton.interactable = false;
            foreach (Button b in buyButtons)
            {
                b.interactable = true;
            }
            curPanel.SetActive(false);
            upgradedPanel.SetActive(false);
            upgradeButton.interactable = false;
            levelText.SetText("");
            curStatus.SetText("");
            upgradedStatus.SetText("");
            sellButtonText.SetText("Sell");
        }
        else
        {
            BaseTower tower = nodeToPlaceAt.GetTowerOnNode().GetComponent<BaseTower>();
            sellButton.interactable = true;
            foreach (Button b in buyButtons)
            {
                b.interactable = false;
            }
            curPanel.SetActive(true);
            upgradedPanel.SetActive(true);
            upgradeButton.interactable = true;
            upgradeButtonText.SetText("Upgrade ($" + tower.UpgradeCost().ToString() + ")");
            sellButtonText.SetText("Sell ($" + (tower.CurrentValue() / 2).ToString() + ")");
            levelText.SetText("Level " + tower.GetCurrentLevel().ToString());
            curStatus.SetText(tower.CurrentStats());
            upgradedStatus.SetText(tower.NextLevelStats());
        }
    }

    public void SellTower()
    {
        node.RemoveTower();
        CloseChooser();
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

    public void UpgradeTower()
    {
        BaseTower tower = node.GetTowerOnNode().GetComponent<BaseTower>();
        tower.UpgradeTower();
        SetNode(node);
    }
}