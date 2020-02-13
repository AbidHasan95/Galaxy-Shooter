using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int totalPoints = 0;
    [SerializeField]
    private Sprite[] livesUI;
    [SerializeField]
    private Image livesObject;
    [SerializeField]
    private Text scoretext;
    public void UpdateLives(int currentlives)
    {
        livesObject.sprite = livesUI[currentlives];
    }

    public void UpdateScore(int points)
    {
        // Update Score UI
        totalPoints += points;
        scoretext.text = "Score: " + totalPoints ;
    }
}
