using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    public float speed;

    private float phaseOffset;

    // Start is called before the first frame update
    void Start()
    {
        phaseOffset = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        float angle = speed * Time.time + phaseOffset;
        gameObject.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}