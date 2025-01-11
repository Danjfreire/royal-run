using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] private float speedBonus = 2f;

    protected override void OnPickUp()
    {
        LevelGenerator.Instance.AddChunkMoveSpeed(speedBonus);
    }
}
