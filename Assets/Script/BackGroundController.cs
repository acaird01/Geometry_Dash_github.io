﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public float Speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.left * Speed * Time.deltaTime;
        transform.position = curPos + nextPos;

    }
}
