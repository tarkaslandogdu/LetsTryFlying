using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;

    [SerializeField] Vector3 movomentVector;
    float movomentFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movomentFactor = (rawSinWave + 1f) / 2f;
        Vector3 ofset = movomentVector * movomentFactor;
        transform.position = startingPosition + ofset;
    }
}
