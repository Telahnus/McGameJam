using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectMvt : MonoBehaviour {
	public Vector3 target;
	private GameObject[] cylinders;
	private bool hasdest;
	private int count;
	private Behaviour j;
	private List<GameObject> lolv = new List<GameObject>();
	void Start () {
		cylinders = GameObject.FindGameObjectsWithTag("Node");
	}

	void Update () {
	}
	void OnMouseDrag(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			GameObject go = hit.transform.gameObject;
			Behaviour h = (Behaviour)go.GetComponent ("Halo");
			h.enabled = !h.enabled;
		}
	}
	void OnMouseDown(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			GameObject go = hit.transform.gameObject;
			behaviour temp = go.GetComponentInParent<behaviour>();
			lolv = temp.listOfLocallyOwnedLocalVoters();
		}
	}
	void OnMouseUp(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			GameObject go = hit.transform.gameObject;
			target = new Vector3 (hit.point.x, 1.0f, hit.point.z);
			for (int i = 0; i < lolv.Count; i++) {
				VoterScript otherTemp = lolv [i].GetComponent<VoterScript>();
				otherTemp.curAction = "NotChilling";
				lolv[i].transform.position = Vector3.MoveTowards (transform.position, target, 1.0f * Time.deltaTime);
			}
		}
		count = 0;
		shutDownLights();
	}

	void shutDownLights(){
		while (count < cylinders.Length) {
			j = (Behaviour)cylinders [count].GetComponent ("Halo");
			j.enabled = false;
			count++;
		}
	}
}
