using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] private float moveSpeed;
    private int pointsIndex;

    void Start()
    {
        transform.position = points[pointsIndex].transform.position;
    }

    void Update()
    {
        if (pointsIndex <= points.Length - 1)
        {
            // Move towards the target position
            transform.position = Vector2.MoveTowards(transform.position, points[pointsIndex].position, moveSpeed * Time.deltaTime);

            // Check if the distance is very small (considered reached)
            if (Vector2.Distance(transform.position, points[pointsIndex].position) < 0.01f)
            {
                pointsIndex += 1;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            // If reached the last point, reset to the first point
            if (pointsIndex == points.Length)
            {
                pointsIndex = 0;
            }
        }
    }
}
