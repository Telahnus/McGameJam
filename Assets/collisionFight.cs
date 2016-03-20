using UnityEngine;
using System.Collections;

public class collisionFight : MonoBehaviour {
    public int thisowner;
	// Use this for initialization
	void Start () {
        VoterScript vs = this.GetComponent<VoterScript>();
        thisowner = vs.myOwner;
    }
    void OnTriggerEnter(Collider other){   
        if (other.tag == "Player"){
            VoterScript vs = other.GetComponent<VoterScript>();
            if (vs.myOwner != thisowner){
                Destroy(other.gameObject);
                Destroy(this);
            }
        }
    }
}
