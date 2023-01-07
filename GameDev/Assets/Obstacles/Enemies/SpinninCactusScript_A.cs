using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinninCactusScript_A : MonoBehaviour
{
    public float rotationSpeed = -60;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,rotationSpeed)* Time.deltaTime * 5); 
    }
}
