using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider playerCollider;
    [SerializeField] private ParticleSystem stunnedEffect;

    [Header("Points Counter")]
    [SerializeField] private GameObject pointsCounter;
    [SerializeField] private TextMeshPro pointsCounterText;

    [Space(10)]
    [SerializeField] private float xLimit;
    [SerializeField] private float swipeSpeed;
    [SerializeField] private float speed = 5;

    [Space(10)]
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private EndOfPathInstruction endOfPathInstruction;


    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 prevPosition;

    private float distanceTravelled;
    private float xMovement;
    private bool canMove;

    private bool init;
    private int pointsCount;


    private void Start()
    {
        UpdatePoint(0);
    }

    public void OnGamePause()
    {
        animator.SetBool("idle", true);
    }

    public void OnGameUnpause()
    {
        animator.SetBool("idle", false);
    }

    private void Update()
    {
        if(GameManager.Instance.GameState == GameState.Playing)
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

                if (distanceTravelled >= pathCreator.path.length)
                {
                    canMove = false;
                    animator.SetTrigger("victory");
                    animator.SetBool("run", false);
                    AudioManager.Instance.PlayGameWinSound();
                }

                UIController.Instance.UpdateProgressBar(distanceTravelled / pathCreator.path.length);
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
            CameraController.Instance.ShakeCamera();
            int damagePoint = damagable.GetDamagePoint();
            if (damagePoint <= pointsCount)
            {
                damagable.Damage();
                UpdatePoint(pointsCount - damagePoint);
            }
            else
            {
                AudioManager.Instance.PlayBlockHitSound();
                Die();
            }
            return;
        }

        IPointScorer pointScorer = other.gameObject.GetComponent<IPointScorer>();
        if(pointScorer != null)
        {
            int calculatedPoint = pointScorer.GetIncrementedPoints(pointsCount);

            if(calculatedPoint > pointsCount)
            {
                AudioManager.Instance.PlayPointAddSound();
            }
            else
            {
                AudioManager.Instance.PlayPointDeductSound();
            }

            UpdatePoint(calculatedPoint);
        }
    }

    private void Die()
    {
        canMove = false;
        animator.SetTrigger("die");
        playerCollider.enabled = false;
        stunnedEffect.gameObject.SetActive(true);
        pointsCounter.SetActive(false);
        AudioManager.Instance.PlayGameLoseSound();
    }

    public void UpdatePoint(int points)
    {
        pointsCount = points;
        pointsCount = Mathf.Clamp(pointsCount, 0, points);
        pointsCounterText.text = pointsCount.ToString();
    }
}
