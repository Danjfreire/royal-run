using UnityEngine;
using Unity.Cinemachine;
using System;

public class Rock : MonoBehaviour
{
    [SerializeField] float shakeMultiplier = 10f;
    [SerializeField] ParticleSystem collisionParticles;
    [SerializeField] AudioSource rockCollisionSound;
    [SerializeField] float collisionFXcooldown = 1f;

    CinemachineImpulseSource inpulseSource;
    float currentFxCooldown = 0f;

    private void Awake()
    {
        inpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        currentFxCooldown += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        ShakeScreen();
        PlayCollisionFX(other);
    }

    private void ShakeScreen()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeMultiplier;
        shakeIntensity = Math.Min(shakeIntensity, 0.8f);

        inpulseSource.GenerateImpulse(shakeIntensity);
    }

    private void PlayCollisionFX(Collision other)
    {
        if (currentFxCooldown < collisionFXcooldown)
        {
            return;
        }

        ContactPoint contactPoint = other.contacts[0];
        collisionParticles.transform.position = contactPoint.point;
        collisionParticles.Play();
        rockCollisionSound.Play();

        currentFxCooldown = 0;
    }
}
