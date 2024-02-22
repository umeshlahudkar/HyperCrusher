using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float xLimit;
    [SerializeField] private float swipeSpeed;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider playerCollider;

    [SerializeField] private TextMeshPro counterText;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 prevPosition;

    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private EndOfPathInstruction endOfPathInstruction;
    [SerializeField] private float speed = 5;

    private float distanceTravelled;
    private float xMovement;
    private bool canMove;

    private bool init;
    private int pointsCount;

    private void Start()
    {
        UpdatePoint(0);
    }

    private void Update()
    {
        if(GameManager.instance.gameState == GameState.Playing)
        {
            if(!init)
            {
                init = true;
                canMove = true;
                animator.SetBool("run", true);
            }

            if (canMove)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);

                if (Input.GetMouseButtonDown(0))
                {
                    startPosition = Input.mousePosition;
                    prevPosition = startPosition;
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

                if (transform.position.z >= pathCreator.path.length)
                {
                    canMove = false;
                    animator.SetTrigger("victory");
                    animator.SetBool("run", false);
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        IConsumable consumable = other.gameObject.GetComponent<IConsumable>();
        if(consumable != null)
        {
            int consumePoint = consumable.Consume();
            UpdatePoint(pointsCount + consumePoint);
            return;
        }

        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
        if(damagable != null)
        {
            int damagePoint = damagable.GetDamagePoint();
            if (damagePoint <= pointsCount)
            {
                damagable.Damage();
                UpdatePoint(pointsCount - damagePoint);
            }
            else
            {
                Die();
            }
            return;
        }

        IPointScorer pointScorer = other.gameObject.GetComponent<IPointScorer>();
        if(pointScorer != null)
        {
            int calculatedPoint = pointScorer.GetIncrementedPoints(pointsCount);
            UpdatePoint(calculatedPoint);
        }


    }

    private void Die()
    {
        canMove = false;
        animator.SetTrigger("die");
        playerCollider.enabled = false;
    }

    public void UpdatePoint(int points)
    {
        pointsCount = points;
        pointsCount = Mathf.Clamp(pointsCount, 0, points);
        counterText.text = pointsCount.ToString();
    }
}
