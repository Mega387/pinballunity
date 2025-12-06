using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBlock : MonoBehaviour
{
    [SerializeField] private KeyCode key = KeyCode.X;
    [SerializeField] private float angle = 35f;
    [SerializeField] private float speed = 30f;
    [SerializeField] private float force = 25f;

    private Quaternion startRot;
    private Quaternion targetRot;
    private bool isForward = false;
    private bool isBackward = false;

    void Start()
    {
        startRot = transform.rotation;
        targetRot = Quaternion.Euler(0, angle, 0) * startRot;
    }

    void Update()
    {
        if (Input.GetKeyDown(key) && !isForward && !isBackward)
        {
            isForward = true;
        }

        if (isForward)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, speed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRot) < 0.1f)
            {
                HitBall();
                isForward = false;
                isBackward = true;
            }
        }

        if (isBackward)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, startRot, speed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, startRot) < 0.1f)
            {
                isBackward = false;
                transform.rotation = startRot;
            }
        }
    }

    void HitBall()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 1.5f);

        foreach (Collider col in cols)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 dir = (col.transform.position - transform.position).normalized;
                dir.y += 0.2f;
                rb.AddForce(dir.normalized * force, ForceMode.Impulse);
                break;
            }
        }
    }
}