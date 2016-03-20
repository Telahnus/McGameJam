using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectMvt : MonoBehaviour {
	public Vector3 target;
	private GameObject[] cylinders;
	private bool hasdest;
	private int count=0;
	private Behaviour j;
	private List<GameObject> lolv = new List<GameObject>();
	void Start () {
		cylinders = GameObject.FindGameObjectsWithTag("Node");
	}

	void Update () {
	}
	void OnMouseDrag(){
		Ray rayDrag = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (rayDrag, out hit) && hit.transform.gameObject.name=="hitbox") {
			GameObject go = hit.transform.gameObject;
			Behaviour h = (Behaviour)go.GetComponent ("Halo");
			shutDownLights();
			h.enabled = true;
		}
	}
	void OnMouseDown(){
		Ray rayDown = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitDown;
		if (Physics.Raycast (rayDown, out hitDown) && hitDown.transform.gameObject.name=="hitbox") {
			GameObject go = hitDown.transform.gameObject;
			behaviour temp = go.GetComponentInParent<behaviour>();
			lolv = temp.listOfLocallyOwnedLocalVoters();
		}
	}
	void OnMouseUp(){
		Ray rayUp = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitUp;
        if (Physics.Raycast(rayUp, out hitUp) && hitUp.transform.gameObject.name == "hitbox")
        {
            GameObject go = hitUp.transform.gameObject;
            target = new Vector3(hitUp.point.x, 1.0f, hitUp.point.z);
            movement(target);
        }

		count = 0;
		shutDownLights();
	}

    void movement(Vector3 target)
    {
        for (int i = 0; i < lolv.Count; i++)
        {
            VoterScript otherTemp = lolv[i].GetComponent<VoterScript>();
            otherTemp.curAction = "NotChilling";
            lolv[i].transform.position = Vector3.MoveTowards(transform.position, target, 1.0f * Time.deltaTime);
        }
    }

	void shutDownLights() {
		while (count < cylinders.Length) {
			j = (Behaviour)cylinders [count].GetComponent ("Halo");
			j.enabled = false;
			count++;
		}
	}
}
