using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float distance = 5f;
    private Vector3 startPos;
    [SerializeField] private float direction = 1f;

    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (transform.position.x >= startPos.x + distance)
        {
            direction = -1f;
        }
        else if (transform.position.x <= startPos.x)
        {
            direction = 1f;
        }
    }
}