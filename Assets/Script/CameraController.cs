using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Vector3 maxPos;
    [SerializeField] [Range(0, 1)] private float progress;

    private void Awake()
    {
        transform.localPosition = initialPos;
    }

    private void LateUpdate()
    {
        transform.localPosition = Vector3.Lerp(initialPos, maxPos, progress);
    }

}
