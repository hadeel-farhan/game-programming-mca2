using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickups : MonoBehaviour
{
    public float rotationAmount = 45f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate the gem pickup objects around themselves
        transform.Rotate(Vector3.up * rotationAmount * Time.deltaTime);
    }
}
