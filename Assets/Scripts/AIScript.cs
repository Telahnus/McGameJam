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
            List<GameObject> statesUnderAttack = new List<GameObject>();

            List<GameObject> myStates = tempEngineScript.stateOf(i);
            //if the player has no states left, continue
            if (myStates.Count == 0) { continue; }
            //if the player has at least one state left
            if (myStates.Count != 0)
            {
                //determine if the need to defend is paramount
                for (int j = 0; j < tempEngineScript.stateOf(i).Count; j++)
                {
                    behaviour temp = myStates[j].GetComponent<behaviour>();
                    if (temp.totalVoters > temp.listOfLocallyOwnedLocalVoters().Count)
                    {
                        statesUnderAttack.Add(myStates[j]);
                    }
                }
                //if states are under attack, set other states to send help
                if (statesUnderAttack.Count == 1)
                {
                    //determine if we should attack a neighbour
                    for (int j = 0; j < tempEngineScript.stateOf(i).Count; j++)
                    {
                        //send all units to state which is under attack...
                    }
                    continue; //moves calculated, end turn
                }
                if (myStates.Count > (2 * statesUnderAttack.Count))
                {
                    //code for those states not under attack to go help those under attack
                    continue; //moves calculated, end turn
                } else
                {
                    //GIVE UP, under too much attack
                    continue; //moves calculated, end turn
                }

                //determine if we should attack a neighbour
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
