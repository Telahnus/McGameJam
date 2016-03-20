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
	private float tmpX;
	private float tmpZ;
	private float totalX;
	private float totalZ;
	private Vector3 checkVector;
	private Vector3 initPosition;

    // Use this for initialization
    void Start () {
		totalX=destinationLocation.x;
		totalZ=destinationLocation.z;
	}
	public void setDest(Vector3 target) {
        destinationLocation = target;
    }
	// Update is called once per frame
	void Update () {
        if (curAction != "chilling")
        {
            this.transform.position = Vector3.MoveTowards(transform.position, destinationLocation, wanderSpeed);
        }
	    if (curAction == "chilling")
        {
			if (Time.time > nextActionTime)
			{
				nextActionTime += wanderPeriod;
   				tmpX = Random.Range(-wanderRange, wanderRange);
				totalX += tmpX;
				tmpZ = Random.Range (-wanderRange, wanderRange);
				totalZ += tmpZ;

				move = new Vector3(tmpX, 0, tmpZ);

				wanderTarget = transform.position + move;

				//variables to check distance between two points (Y=0 to ignore vertical axis)
				checkVector = new Vector3 (totalX+tmpX, 0, totalZ+tmpZ);
				initPosition = new Vector3 (destinationLocation.x, 0, destinationLocation.z);
            }

			if (Vector3.Distance(initPosition,checkVector)<60) {
				transform.position = Vector3.MoveTowards (transform.position, wanderTarget, wanderSpeed);
				totalX += tmpX;
				totalZ += tmpZ;
            }
	    }
    }

}
