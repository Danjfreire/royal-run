using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private float startTime;

    private float remainingTime;
    private bool gameOver;

    public bool GameOver { get { return gameOver; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

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
        if (GameOver) return;

        remainingTime -= Time.deltaTime;
        timeText.text = remainingTime.ToString("F1");

        if (remainingTime <= 0)
        {
            PlayerGameOver();
        }
    }

    private void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}
