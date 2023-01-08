using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BoostSizeUp : MonoBehaviour {
	
	bool triggered = false;
    
	// Before rendering each frame..
	void Update () 
	{
		// Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
		// rather than per frame.
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

    IEnumerator flashGrowth(GameObject player)
    {
        float originalScale = player.transform.localScale.x;
		player.transform.DOScale(originalScale + 3f, 1f);
        yield return new WaitForSeconds(5);
        player.transform.DOScale(originalScale, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered & other.gameObject.CompareTag("Player"))
        {
			triggered = true;
			Debug.Log("OnTriggerEnter");
            StartCoroutine(flashGrowth(other.gameObject));
			Debug.Log("After growth");
			gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}