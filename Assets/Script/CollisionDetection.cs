using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        playerController.OnTriggerEnter(other);
    }
}
