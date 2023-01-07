using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCactusScript_B : MonoBehaviour
{
    public GameObject CactusCore; 
    public float rotationSpeed = -60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(CactusCore.transform.position, Vector3.up, rotationSpeed * Time.deltaTime * 5); 
    }
}
