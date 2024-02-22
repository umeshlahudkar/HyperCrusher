using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour, IDamagable
{
    [SerializeField] private int damagePoint;
    [SerializeField] private TextMeshPro damagePointText;

    [SerializeField] private GameObject completeBlock;
    [SerializeField] private GameObject brockenBlock;


    private void Start()
    {
        damagePointText.text = damagePoint.ToString();
    }

    public void Damage()
    {
        completeBlock.SetActive(false);
        brockenBlock.SetActive(true);
    }

    public int GetDamagePoint()
    {
        return damagePoint;
    }
}
