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
				Component halo = GetComponent ("Halo");
				halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
			}
		}
	}

}
