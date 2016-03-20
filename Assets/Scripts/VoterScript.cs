using UnityEngine;
using System.Collections;

public class VoterScript : MonoBehaviour {

    public int myOwner;
    public string curAction;
    public GameObject destination;
    public Vector3 destinationLocation;
    // stuff for wandering
    public float wanderRange;
    private Vector3 wanderTarget;
    public float wanderSpeed;
    private float nextActionTime = 0.0f;
    public float wanderPeriod = 1;
    private Vector3 move;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (curAction == "chilling")
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += wanderPeriod;
                move = new Vector3(Random.Range(-wanderRange, wanderRange), 0, Random.Range(-wanderRange, wanderRange));
                wanderTarget = transform.position + move;
            }
            transform.position = Vector3.MoveTowards(transform.position, wanderTarget, wanderSpeed);
        }
	}
}
