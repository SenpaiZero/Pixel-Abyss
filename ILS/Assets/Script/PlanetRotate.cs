using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 300 * Time.deltaTime) * Time.deltaTime);
    }
}
