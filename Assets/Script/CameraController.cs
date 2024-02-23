using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private Transform followTarget;

    private bool isShaking = false;
    [SerializeField] private float shakeMagnitude = 0.1f;
    [SerializeField] private float shakeDuration = 0.5f;
    [SerializeField] private float frequency = 50f;
    private float shakeTimer = 0f;
    private Vector3 originalPosition;

    private void LateUpdate()
    {
        if (isShaking)
        {
            if (shakeTimer > 0)
            {
                float offsetX = Mathf.Sin(Time.time * frequency) * shakeMagnitude;
                float offsetY = Mathf.Cos(Time.time * frequency) * shakeMagnitude;

                transform.position = originalPosition + new Vector3(offsetX, offsetY, 0);
                shakeTimer -= Time.deltaTime;
                originalPosition = followTarget.position;
            }
            else
            {
                shakeTimer = 0f;
                isShaking = false;
                transform.position = followTarget.position;
            }
        }
        else
        {
            transform.position = followTarget.position;
        }
    }

    // Method to trigger the camera shake effect
    public void ShakeCamera()
    {
        originalPosition = transform.position;
        isShaking = true;
        shakeTimer = shakeDuration;
    }
}
