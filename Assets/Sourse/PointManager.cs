using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;

    private int Points = 0;

    void Start()
    {
        UpdatepointText();
    }

    public void Addpoint(int points)
    {
        Points += points;
        UpdatepointText();
    }
    private void UpdatepointText()
    {
        if (pointText != null)
        {
            pointText.text = "Очки: " + Points.ToString();
        }
    }
}