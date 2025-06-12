using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToandFro : MonoBehaviour
{
    [SerializeField] private Transform pointA;    
    [SerializeField] private Transform pointB;   
    [SerializeField] private Transform player;    

    private Vector3 direction;                   
    private float distance;                       
    [SerializeField] private float speed = 1f;    
    private float duration;                      
    private float time = 0f;                     
    private bool fromAToB = true;                

    void Start()
    {
        player.position = pointA.position;

        Vector3 differenceVectorAB = pointB.position - pointA.position;
        Debug.Log("Difference Vector AB: " + differenceVectorAB);

        distance = differenceVectorAB.magnitude;
        Debug.Log("Distance AB: " + distance);

        duration = distance / speed;
        Debug.Log("Duration from A to B at " + speed + " m/s: " + duration);

        direction = differenceVectorAB.normalized;
        Debug.Log("Initial Direction: " + direction);
    }

    void Update()
    {
        time += Time.deltaTime;

        player.position += direction * speed * Time.deltaTime;

        if (time > duration)
        {
            time = 0f;
            fromAToB = !fromAToB;

            if (fromAToB)
            {
                direction = (pointB.position - pointA.position).normalized;
                Debug.Log("Switching to A → B");
            }
            else
            {
                direction = (pointA.position - pointB.position).normalized;
                Debug.Log("Switching to B → A");
            }
        }
    }
}
