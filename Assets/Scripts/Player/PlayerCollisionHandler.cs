using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private const string STUMBLE_HIT_ANIM_TRIGGER = "Hit";

    [SerializeField] private Animator animator;
    [SerializeField] private float collisionCD = 1f;

    private float currentCollisionCD = 0f;

    private void Update()
    {
        currentCollisionCD += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (currentCollisionCD > collisionCD)
        {
            animator.SetTrigger(STUMBLE_HIT_ANIM_TRIGGER);
            currentCollisionCD = 0;
        }
    }
}
