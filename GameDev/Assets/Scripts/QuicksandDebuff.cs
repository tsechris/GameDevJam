using UnityEngine;
using System.Collections;

public class QuicksandDebuff : MonoBehaviour {

	// Before rendering each frame..
	void Update () 
	{

	}

    void debuffPlayerMovement(GameObject player)
    {
		NetworkCharacterControllerPrototype characterController = player.GetComponent<NetworkCharacterControllerPrototype>();
        characterController.maxSpeed = 1f;
        characterController.acceleration = 2f;
        characterController.jumpImpulse = 0f;
    }

    void returnPlayerMovement(GameObject player)
    {
		NetworkCharacterControllerPrototype characterController = player.GetComponent<NetworkCharacterControllerPrototype>();
        characterController.maxSpeed = 4f;
        characterController.acceleration = 10f;
        characterController.jumpImpulse = 5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            debuffPlayerMovement(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            returnPlayerMovement(other.gameObject);
        }
    }
}