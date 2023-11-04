using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    // Static variable for the players score and the text for the display buttons that can be changed later
    public static int scoreVal = 0;
    public TextMeshProUGUI score; 
    public TextMeshProUGUI health;
    public TextMeshProUGUI round;

    // On start we set the text property to display the score value
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update the score, round and health text based on the storage controllers values
    void Update()
    {
        scoreVal = StorageController.GetGamePoints();
        score.text = "Score: " + scoreVal;
        health.text = "Health: " + StorageController.GetHealthPoints().ToString();
        round.text = "Round " + StorageController.GetGameRound().ToString();
    }
}