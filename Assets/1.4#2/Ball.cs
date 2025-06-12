using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 direction = new Vector3(1, 2, 0);
    [SerializeField] private float speed = 3;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Vector2 min, max;


    void Start()
    {
        direction = direction.normalized;
    }


    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        transform.position += velocity;

        if (transform.position.x + transform.localScale.x / 2 > max.x)
        {
            direction.x = -direction.x;
        }
        if (transform.position.x - transform.localScale.x / 2 < min.x)
        {
            direction.x = -direction.x;
        }
        if (transform.position.y + transform.localScale.y / 2 > max.y)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y - transform.localScale.y / 2 < min.y)
        {
            direction.y = -direction.y;
        }
    }
}
