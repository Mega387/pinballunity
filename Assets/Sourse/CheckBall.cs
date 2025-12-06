using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckBall : MonoBehaviour
{
    [SerializeField] private string ballTag = "Ball";
    [SerializeField] private GameObject noWinPanel;
    [SerializeField] private int requiredBalls = 3;

    private int ballsInZone = 0;

    private void Start()
    {
        if (noWinPanel != null)
            noWinPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ballTag))
        {
            ballsInZone++;
            CheckWinCondition();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ballTag))
        {
            ballsInZone--;
        }
    }

    private void CheckWinCondition()
    {
        if (ballsInZone >= requiredBalls)
        {
            ShowWinScreen();
        }
    }

    private void ShowWinScreen()
    {
        if (noWinPanel != null)
        {
            noWinPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}