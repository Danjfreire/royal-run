using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private float startTime;

    private float remainingTime;
    private bool gameOver;

    private void Start()
    {
        remainingTime = startTime;
    }

    private void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (gameOver) return;

        remainingTime -= Time.deltaTime;
        timeText.text = remainingTime.ToString("F1");

        if (remainingTime <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}
