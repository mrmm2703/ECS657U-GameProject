using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int scoreVal = 0;
    public TextMeshProUGUI score; // Rename the variable for clarity

    // Start is called before the first frame update
    void Start()
    {
        // You can access and set the text property of the InputField to display the score value
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally, you can update the InputField's text during the Update method
        scoreVal = StorageController.GetGamePoints();
        score.text = "Score: " + scoreVal;
    }
}
