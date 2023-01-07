using UnityEngine;
using System.Collections;

public class BoostJump : MonoBehaviour {
	
	bool triggered = false;

	// Before rendering each frame..
	void Update () 
	{
		// Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
		// rather than per frame.
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

    IEnumerator boostPlayerJump(GameObject player)
    {
		NetworkCharacterControllerPrototype characterController = player.GetComponent<NetworkCharacterControllerPrototype>();
        characterController.jumpImpulse = 0.9f;
        yield return new WaitForSeconds(20);
        characterController.jumpImpulse = 0.6f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered & other.gameObject.CompareTag("Player"))
        {
			triggered = true;
            StartCoroutine(boostPlayerJump(other.gameObject));
			gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}