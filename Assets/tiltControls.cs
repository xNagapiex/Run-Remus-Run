using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);
    }
} 