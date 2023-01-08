using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] GameObject obstacle;   
    [SerializeField] int obstacleCount;
    [SerializeField] float obstacleWidth;
    [SerializeField] float obstacleHeight;
    [SerializeField] Vector2 bound1;
    [SerializeField] Vector2 bound2;

    //TEMPLATE FOR OBSTACLE GENERATION
    public void GenerateObstacles()
    {
        for (int i = 0; i <= obstacleCount; i++)
        {
            //ASSUMING THE COURSE'S Y LEVEL IS 0
            Vector3 obstacleLocation = new Vector3(Random.Range(bound1.x, bound2.x), 0f, Random.Range(bound1.y, bound2.y));
            if (Physics.CheckSphere(new Vector3(obstacleLocation.x, -0.1f, obstacleLocation.z), 0.1f) &&
                !Physics.CheckSphere(new Vector3(obstacleLocation.x, obstacleHeight/2, obstacleLocation.z), obstacleHeight/2 - 1)){
                    Debug.Log("Generated Obstacle");
                    Instantiate(obstacle, new Vector3(obstacleLocation.x, obstacleLocation.y, obstacleLocation.z), Quaternion.identity);
                } else {
                    Debug.Log("Failed to generate obstacle");
                }
        }
    }

    public void RemoveObstacles()
    {
        foreach(GameObject placedObstacle in GameObject.FindGameObjectsWithTag(obstacle.tag))
        {
            Destroy(placedObstacle);
        }
    }
}
