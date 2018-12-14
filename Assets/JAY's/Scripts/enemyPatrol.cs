using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{


    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatroleIndex;

    void Start()
    {
        currentPatroleIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatroleIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f)
        {
            if (currentPatroleIndex + 1 < patrolPoints.Length)
            {
                currentPatroleIndex++;
            }
            else
            {
                currentPatroleIndex = 0;
            }

            currentPatrolPoint = patrolPoints[currentPatroleIndex];
        }
    }
}