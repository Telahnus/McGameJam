using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

    int myNumber;
    int commandWait;
    private Engine myEngine;
    private GameObject[] states;
    //khaled=1; trump=2; cuz=3; kasch=4

    void Start () {
        myEngine = GameObject.Find("GameEngine").GetComponent<Engine>();
        states = myEngine.states;
        StartCoroutine(runAI());
    }

    IEnumerator runAI(){
        yield return new WaitForSeconds(commandWait);
    }
}
