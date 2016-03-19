using UnityEngine;
using System.Collections;

public class VoterWander : MonoBehaviour {
    public float speed;
    public Vector3 target;
    private bool hasdest;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)){
                target = new Vector3(hit.point.x, 0.01f, hit.point.z);
                hasdest = true;
            }
        }
        if (hasdest){
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
}
