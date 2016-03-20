using UnityEngine;
using System.Collections;

public class SelectMvt : MonoBehaviour {
	public Vector3 target;
	private bool hasdest;

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
				if (Physics.Raycast(ray, out hit, 100)){
						target = new Vector3(hit.point.x, 0.01f, hit.point.z);
						hasdest = true;
					if (hasdest){
						transform.position = Vector3.MoveTowards(transform.position, target, 1.0f*Time.deltaTime);
					}
					GameObject[] movingObjects = GameObject.FindGameObjectsWithTag ("MovingPlayer");
					for (int i = 0; i < movingObjects.Length; i++) {
						movingObjects [i].transform.position = Vector3.MoveTowards (transform.position, hit.collider.transform.position, 0.1f * Time.deltaTime);
					}
				}
			}
		}
	}
}
