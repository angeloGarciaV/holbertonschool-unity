using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float intensity = 1.0f;

    private float phaseOffset;

    void Start()
    {
        phaseOffset = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Cos(Time.time + phaseOffset) * intensity,
            transform.position.z);
    }
}
