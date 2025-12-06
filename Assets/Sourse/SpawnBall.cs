using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI text;

    private int spawned = 0;
    private int maxCount = 3;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (spawned < maxCount)
            {
                Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
                spawned++;
                text.text = $"Шариков: {spawned}/{maxCount}";
            }
        }
    }
}