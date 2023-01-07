using UnityEngine;
using System.Collections;

public class BoostSpeed : MonoBehaviour {
	
	bool triggered = false;

	// Before rendering each frame..
	void Update () 
	{
		// Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
		// rather than per frame.
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

    IEnumerator boostPlayerSpeed(GameObject player)
    {
		NetworkCharacterControllerPrototype characterController = player.GetComponent<NetworkCharacterControllerPrototype>();
        characterController.maxSpeed = 10f;
        characterController.acceleration = 20f;
        yield return new WaitForSeconds(20);
        characterController.maxSpeed = 4f;
        characterController.acceleration = 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered & other.gameObject.CompareTag("Player"))
        {
			triggered = true;
            StartCoroutine(boostPlayerSpeed(other.gameObject));
			gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}