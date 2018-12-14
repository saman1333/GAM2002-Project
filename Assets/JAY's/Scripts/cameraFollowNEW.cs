﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowNEW : MonoBehaviour
{

    public Transform target;
    public float smoothing;

    Vector3 offset;

    private float lowY;

    void Start()
    {
        offset = transform.position - target.position;

      
    }


    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

      

    }
}
