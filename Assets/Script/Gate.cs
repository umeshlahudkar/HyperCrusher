using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour, IPointScorer
{

    public enum PointsOperationType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }


    [SerializeField] private PointsOperationType pointsOperationType;
    [SerializeField] private int points;

    [SerializeField] private TextMeshPro pointsText;
    [SerializeField] private GameObject forceField;
    [SerializeField] private MeshRenderer forceFirldMesh;

    [SerializeField] private Material positivePointsMaterial;
    [SerializeField] private Material negativePointsMaterial;


    private void Start()
    {
        InitializeGate();
    }

    private void InitializeGate()
    {
        string txt = "";

        switch(pointsOperationType)
        {
            case PointsOperationType.Addition:
                txt = "+";
                forceFirldMesh.material = positivePointsMaterial;
                break;

            case PointsOperationType.Subtraction:
                txt = "-";
                forceFirldMesh.material = negativePointsMaterial;
                break;

            case PointsOperationType.Multiplication:
                txt = "\u00D7";
                forceFirldMesh.material = positivePointsMaterial;
                break;

            case PointsOperationType.Division:
                txt = "\u00F7";
                forceFirldMesh.material = negativePointsMaterial;
                break;
        }

        txt += points.ToString();

        pointsText.text = txt;
    }

    public int GetIncrementedPoints(int currentPoints)
    {
        int calculatedPoints = 0;
        switch (pointsOperationType)
        {
            case PointsOperationType.Addition:
                calculatedPoints = currentPoints + points;
                break;

            case PointsOperationType.Subtraction:
                calculatedPoints = currentPoints - points;
                break;

            case PointsOperationType.Multiplication:
                calculatedPoints = currentPoints * points;
                break;

            case PointsOperationType.Division:
                calculatedPoints = currentPoints / points;
                break;
        }

        forceField.SetActive(false);

        return calculatedPoints;
    }
}
