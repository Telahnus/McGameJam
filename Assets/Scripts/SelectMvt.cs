using UnityEngine;
using System.Collections;

public class SelectMvt : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
                GameObject go = hit.transform.gameObject;
				Behaviour h = (Behaviour)go.GetComponent ("Halo");
				h.enabled = !h.enabled;
				GameObject[] movingObjects = GameObject.FindGameObjectsWithTag ("MovingPlayer");
				for (int i = 0; i < movingObjects.Length; i++) {
					movingObjects [i].transform.position = Vector3.MoveTowards (transform.position, hit.collider.transform.position, 0.1f * Time.deltaTime);
				}
				if (hit.collider.gameObject.name == "Voter") {
					GameObject voter = hit.collider.gameObject;
					voter.tag = "MovingPlayer";
				}
            }
		}
	}
}
