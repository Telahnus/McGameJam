using UnityEngine;
using System.Collections;

public class collisionFight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	IEnumerator OnCollisionEnter(Collision col){
		if (col.gameObject.tag=="Player") {
			yield return new WaitForSeconds (0.2f);
			Destroy(col.gameObject);
			Destroy (gameObject);
		}
	}
}
