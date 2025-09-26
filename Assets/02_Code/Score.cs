using UnityEngine;
using UnityEngine.UI; // Only needed if displaying the score with UI

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public float pointsPerSecond = 20; // Change this for your preferred rate
    public Text scoreText; // Attach your UI Text component here

    void Update()
    {
        score += pointsPerSecond * Time.deltaTime;
        if (scoreText != null)
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }
}
