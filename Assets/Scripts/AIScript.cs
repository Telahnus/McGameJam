using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

        //grab the game engine object
        GameObject tempEngine = GameObject.FindGameObjectWithTag("Engine");
        //grab the script of the object
        Engine tempEngineScript = tempEngine.GetComponent<Engine>();
        for (int i = 2; i < 5; i++)
        {
            List<GameObject> myStates = tempEngineScript.stateOf(i);
            //if the player has no states left, continue
            if (myStates.Count == 0) { continue; }
            //if the player has at least one state left
            if (myStates.Count != 0)
            {
                //foreach state do a check if they are under attack
                for (int j = 0; j < tempEngineScript.stateOf(i).Count; j++)
                {
                    behaviour temp = myStates[j].GetComponent<behaviour>();
                    if (temp.listOfLocallyOwnedLocalVoters().Count > temp.garrisonValue)
                    {
                        //attack neighbour based on probability?
                    }
                } 
            }
        }
    
    }
}
