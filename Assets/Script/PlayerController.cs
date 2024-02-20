using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float xLimit;
    [SerializeField] private float swipeSpeed;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 prevPosition;

    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private EndOfPathInstruction endOfPathInstruction;
    [SerializeField] private float speed = 5;

    private float distanceTravelled;
    private float xMovement;
    private bool canMove;
   
    private void StartRuning()
    {
        canMove = true;
        animator.SetBool("run", true);
    }

    bool flag = false;

    private void Update()
    {
        if(canMove)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        }

        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            prevPosition = startPosition;
            StartRuning();
        }
        else if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;

            Vector3 swipeDirection = endPosition - prevPosition;
            float swipeDistance = swipeDirection.magnitude;

            float directionModifier = swipeDirection.x > 0 ? 1 : -1;

            xMovement = playerTransform.localPosition.x + (directionModifier * swipeDistance * swipeSpeed * Time.deltaTime);
            xMovement = Mathf.Clamp(xMovement, -xLimit, xLimit);
            playerTransform.localPosition = new Vector3(xMovement, 0, 0);

            prevPosition = endPosition;
        }

        if(transform.position.z >= pathCreator.path.length && !flag)
        {
            flag = true;
            canMove = false;
            animator.SetTrigger("victory");
        }
    }
}
