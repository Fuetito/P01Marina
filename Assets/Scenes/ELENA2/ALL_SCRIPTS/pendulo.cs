using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulo : MonoBehaviour
{
    public float speed = 1.5f;
    public float limit = 75f;
    public bool randomStart = false;
    public float delay = 0;
    private float random = 0;
    void Awake()
    {
        if (randomStart)
        {
            random = Random.Range(0f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time + random * speed + delay);
        transform.localRotation = Quaternion.Euler(angle, 0, 0);
    }
}
