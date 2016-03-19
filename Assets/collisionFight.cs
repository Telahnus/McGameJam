using UnityEngine;
using System.Collections;

public class collisionFight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "testCube") {
			Destroy(col.gameObject);
			RigidbodyConstraints.FreezeAll;
		}
	}
}
