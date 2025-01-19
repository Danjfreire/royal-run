using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        scoreText.text = "0";
    }

    public void IncreaseScore(int increase)
    {
        if (GameManager.Instance.GameOver) return;

        score += increase;
        scoreText.text = score.ToString();
    }
}
