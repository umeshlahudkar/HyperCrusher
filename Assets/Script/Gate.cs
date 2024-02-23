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
                break;

            case PointsOperationType.Subtraction:
                txt = "-";
                break;

            case PointsOperationType.Multiplication:
                txt = "\u00D7";
                break;

            case PointsOperationType.Division:
                txt = "\u00F7";
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
