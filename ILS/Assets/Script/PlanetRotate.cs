using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    public float speed = 300f;
    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime) * Time.deltaTime);
    }
}
