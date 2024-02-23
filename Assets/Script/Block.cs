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
    [SerializeField] private ParticleSystem blockBreakEffect;

    [SerializeField] private MeshRenderer[] brockenBlockmeshRenderers;
    [SerializeField] private MeshRenderer completeBlockmeshRenderers;

    [SerializeField] private Material[] materials;


    private void Start()
    {
        damagePointText.text = damagePoint.ToString();
        AssignMaterial();
    }

    private void AssignMaterial()
    {
        int ran = Random.Range(0, materials.Length);

        completeBlockmeshRenderers.material = materials[ran];

        for(int i = 0; i < brockenBlockmeshRenderers.Length; i++)
        {
            brockenBlockmeshRenderers[i].material = materials[ran];
        }
    }

    public void Damage()
    {
        completeBlock.SetActive(false);
        brockenBlock.SetActive(true);
        blockBreakEffect.Play();
        AudioManager.Instance.PlayBlockBreakSound();

        Destroy(gameObject, 2f);
    }

    public int GetDamagePoint()
    {
        return damagePoint;
    }
}
