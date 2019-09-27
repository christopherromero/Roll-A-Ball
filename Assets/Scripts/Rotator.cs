using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    private float y = 75;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, y, 0.0f) * Time.deltaTime);
    }
}
