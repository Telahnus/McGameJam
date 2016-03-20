using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

    int myNumber;
    int commandWait;

	// Use this for initialization
	void Start () {
        StartCoroutine(runAI());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator runAI(){
        yield return new WaitForSeconds(commandWait);
    }
}
