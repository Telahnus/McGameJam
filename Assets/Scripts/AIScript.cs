using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

    int myNumber;
    int commandWait;
    private Engine myEngine;
    private GameObject[] states;

    void Start () {
        myEngine = GameObject.Find("GameEngine").GetComponent<Engine>();
        states = myEngine.states;
        StartCoroutine(runAI());
    }

    IEnumerator runAI(){
        yield return new WaitForSeconds(commandWait);
    }
}
