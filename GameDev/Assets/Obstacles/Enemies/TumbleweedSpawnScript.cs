using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedSpawnScript : MonoBehaviour
{
    public GameObject tumbleweed; 
    public float spawnRate;
    public float nextSpawn; 
    public float Speed = 1.5f ;
    public float direction = 1; 
    public float tumbleweedLifeDuration = 2; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawn){
            nextSpawn = Time.time + 1f / spawnRate; 
            spawnTumbleweed();
        }
        
    }

    void spawnTumbleweed(){
        GameObject tumbleweedInstance = Instantiate(tumbleweed, gameObject.transform.position, transform.rotation);
        tumbleweedInstance.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,direction) * Speed);
        Destroy(tumbleweedInstance,tumbleweedLifeDuration); 

    }
}
