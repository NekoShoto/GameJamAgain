using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class MovingFloor : MonoBehaviour
{
    public float baseSpeed = 2f;
    public float speedIncreasePerPoint = 10f;
    public float threasholdPosition = -5.1f;
    public float resetPosition = 4f;

    public Text scoreText;

    private void Update()
    {
        int score = 0;
        if (scoreText != null)
        {
            // Извлекаем только число из текста
            string digits = Regex.Match(scoreText.text, @"\d+").Value;
            int.TryParse(digits, out score);
        }

        

        float speed = baseSpeed + score * speedIncreasePerPoint;

        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < threasholdPosition)
            transform.position += Vector3.right * resetPosition;
    }
}