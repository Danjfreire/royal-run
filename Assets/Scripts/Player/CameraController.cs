using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float minFOV = 40f;
    [SerializeField] private float maxFOV = 90f;
    [SerializeField] private float zoomSpeedMultiplier = 5f;
    [SerializeField] private float zoomDuration = 1f;
    [SerializeField] private ParticleSystem speedUpParticleSystem;

    CinemachineCamera cinemachineCamera;

    private void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmount));
        if (speedAmount > 0)
        {
            speedUpParticleSystem.Play();
        }
    }

    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeedMultiplier, minFOV, maxFOV);

        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration;
            elapsedTime += Time.deltaTime;

            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);

            // wait until next frame
            yield return null;
        }

        // ensure that the fov is the target after the time;
        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
