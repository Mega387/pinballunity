using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel : MonoBehaviour
{
    [SerializeField] private float repulsionForce = 25f;
    [SerializeField] private float upwardBoost = 0.3f;

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.CompareTag("Ball"))
        {
            PushBall(other);
        }
    }

    void PushBall(GameObject ball)
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb == null) return;

        Vector3 direction = (ball.transform.position - transform.position).normalized;
        direction.y += upwardBoost;
        direction = direction.normalized;




        rb.AddForce(direction * repulsionForce, ForceMode.Impulse);
    }
}