using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour {

    public Transform[] point;
    public int startingPoint;
    public int Target;
    public float speed;

    void Start()
    {
        transform.position = point[startingPoint].position;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, point[Target].position, speed * Time.deltaTime);
        if (transform.position == point[Target].position)
        {
            Target++;
            if (Target == point.Length)
            {
                Target = 0;
            }
        }
    }
}
