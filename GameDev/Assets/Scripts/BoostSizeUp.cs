using UnityEngine;
using System.Collections;

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
		int max = 8;
        for (int i=0; i<max; i++)
        {
            player.transform.localScale = new Vector3(i/3f+1,i/3f+1,i/3f+1);
            yield return new WaitForSeconds(0.1f);
            player.transform.localScale = new Vector3(i/3f+2,i/3f+2,i/3f+2);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(5);
        for (int i=0; i<max; i++)
        {
            player.transform.localScale = new Vector3((max-i)/3+2,(max-i)/3+2,(max-i)/3+2);
            yield return new WaitForSeconds(0.1f);
            player.transform.localScale = new Vector3((max-i)/3+1,(max-i)/3+1,(max-i)/3+1);
            yield return new WaitForSeconds(0.1f);
        }
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