using UnityEngine;
using Unity.Cinemachine;
using System;

public class Rock : MonoBehaviour
{
    [SerializeField] float shakeMultiplier = 10f;

    CinemachineImpulseSource inpulseSource;

    private void Awake()
    {
        inpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeMultiplier;
        shakeIntensity = Math.Min(shakeIntensity, 0.8f);

        inpulseSource.GenerateImpulse(shakeIntensity);
    }
}
