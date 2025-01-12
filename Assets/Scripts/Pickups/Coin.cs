using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] private int score;

    protected override void OnPickUp()
    {
        ScoreManager.Instance.IncreaseScore(score);
    }
}
