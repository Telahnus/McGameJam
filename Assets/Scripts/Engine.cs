using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {
    public GameObject statesPrefab;
    public GameObject[] states;
    // Use this for initialization
    void Start() {
        if (states == null)
        {
            states = GameObject.FindGameObjectsWithTag("State");
        }
    }

    // Update is called once per frame
    void Update() {

    }

    bool isWin(GameObject[] states) {
        behaviour temp1 = states[0].GetComponent<behaviour>();
        for (int i = 1; i < states.Length - 1; i++)
        {

            behaviour temp2 = states[i].GetComponent<behaviour>();
            if (temp1.owner != temp2.owner)
            {
                return false;
            }
        }
        return true;
    }

}
