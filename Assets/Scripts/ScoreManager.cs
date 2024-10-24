using UnityEngine;
using TMPro; // Only needed if using TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro text (use Text if you're using UI Text)
    private int score = 0;

    // This method will be called when a rock hits the house
    public void AddScore(int points)
    {
        score += points; // Add the given points to the score
        UpdateScoreText(); // Update the UI
    }

    // Update the UI with the current score
    void UpdateScoreText()
    {
        if(score>199){
            scoreText.text = "You Win! Score: " + score.ToString();
        }
        else{
        scoreText.text = "Score: " + score.ToString();
        }
    }
}
