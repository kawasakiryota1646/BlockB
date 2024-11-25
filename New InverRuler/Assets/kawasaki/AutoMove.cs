using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    public float moveSpeed = 3.0f;
    private int direction = 1;

    void Update()
    {
        if (transform.position.x >= rightEdge.position.x) direction = -1;
        if (transform.position.x <= leftEdge.position.x) direction = 1;

        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime * direction, transform.position.y, transform.position.z);
    }
}
