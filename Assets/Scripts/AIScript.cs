using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

    public int myNumber;
    public int commandWait;
    private Engine myEngine;
    private GameObject[] states;

    void Awake () {
        myEngine = GameObject.Find("GameEngine").GetComponent<Engine>();
        states = GameObject.FindGameObjectsWithTag("Province");
        StartCoroutine(runAI());
    }

    IEnumerator runAI(){
        yield return new WaitForSeconds(commandWait);
        int r = Random.Range(0, 38);
        GameObject curState = states[r];

    
    }
}
