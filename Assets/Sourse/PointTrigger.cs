using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointTrigger : MonoBehaviour
{
    [SerializeField] private int pointValue = 10;
    [SerializeField] private string ballTag = "Ball";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(ballTag))
        {
            PointManager pointManager = FindObjectOfType<PointManager>();
            if (pointManager != null)
            {
                pointManager.Addpoint(pointValue);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ballTag))
        {
            PointManager pointManager = FindObjectOfType<PointManager>();
            if (pointManager != null)
            {
                pointManager.Addpoint(pointValue);
            }
        }
    }
}