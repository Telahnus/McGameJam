using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class behaviour : MonoBehaviour
{
    public int owner;
    public string destination;
    public string thisDestination;
    public GameObject voter;
    public int garrisonValue;
    public float spawnWait;
    public Vector3 spawnValues;
    public int neutralVoters;
    public int khaledVoters;
    public int trumpVoters;
    public int cruzVoters;
    public int kasichVoters;
    public int totalVoters;
    //public float startWait;
    //public float waveWait;
    private static GameObject thisState;

    void Start()
    {
        thisState = this.gameObject;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        //yield return new WaitForSeconds(startWait);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
			Vector3 myPosition = transform.position;
			spawnPosition += myPosition;
			Quaternion spawnRotation = Quaternion.identity;
            Object temp = null;
            //check for neutral state, they shouldn't be too high

            temp = Instantiate(voter, spawnPosition, spawnRotation);
            //tempOwner = temp.owner;
            //switch (tempOwner) {
            // case 0:
            // case 1:
            // case 2:
            // }
            yield return new WaitForSeconds(spawnWait);
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateVotersInState();
    }

    //determine units in an area
    void updateVotersInState()
    {

        Collider[] voterList = listOfVoters();

        int i = 0;
        neutralVoters = 0;
        khaledVoters = 0;
        trumpVoters = 0;
        cruzVoters = 0;
        kasichVoters = 0;
        while (i<voterList.Length && voterList[i].gameObject == voter)
        {
            VoterScript voterTemp = voterList[0].GetComponent<VoterScript>();
            switch (voterTemp.myOwner)
            {
                case 0:
                    neutralVoters++; break;
                case 1:
                    khaledVoters++; break;
                case 2:
                    trumpVoters++; break;
                case 3:
                    cruzVoters++; break;
                case 4:
                    kasichVoters++; break;

            }
            i++;
        }

        // check that shit though
        if (totalVoters != 0 && areAllForeignVotersTheSame()) { updateOwner(); }
    }

    private Collider[] listOfVoters()
    {
        //determine how many units are in the sphere of influence of the state
        Vector3 centre = thisState.transform.position;
        return Physics.OverlapSphere(centre, 3);
    }

    //returns a true or false depending on whether all the foreign voters in a state are of the same owner
    //true means that owner will change. Flase will not
    private bool areAllForeignVotersTheSame()
    {
        totalVoters = neutralVoters + khaledVoters + trumpVoters + cruzVoters + kasichVoters;
        switch (owner)
        {
            case 0:
                if (khaledVoters == totalVoters) { owner = 1; return true; }
                if (trumpVoters == totalVoters) { owner = 2; return true; }
                if (cruzVoters == totalVoters) { owner = 3; return true; }
                if (kasichVoters == totalVoters) { owner = 4; return true; }
                break;
            case 1:
                if (trumpVoters == totalVoters) { owner = 2; return true; }
                if (cruzVoters == totalVoters) { owner = 3; return true; }
                if (kasichVoters == totalVoters) { owner = 4; return true; }
                break;
            case 2:
                if (khaledVoters == totalVoters) { owner = 1; return true; }
                if (cruzVoters == totalVoters) { owner = 3; return true; }
                if (kasichVoters == totalVoters) { owner = 4; return true; }
                break;
            case 3:
                if (khaledVoters == totalVoters) { owner = 1; return true; }
                if (trumpVoters == totalVoters) { owner = 2; return true; }
                if (kasichVoters == totalVoters) { owner = 4; return true; }
                break;
            case 4:
                if (khaledVoters == totalVoters) { owner = 1; return true; }
                if (trumpVoters == totalVoters) { owner = 2; return true; }
                if (cruzVoters == totalVoters) { owner = 3; return true; }
                break;
        }

        return false;  
    }

    //updates the owner based on current foreign attacker
    private void updateOwner()
    {
        //ADD CODE TO CHANGE MATERIAL OF RING TO REFLECT NEW OWNER
    }

    private void listOfLocallyOwnedLocalVoters()
    {
        Collider[] tempCollider = listOfVoters();
        List<GameObject> listOfLocalVoters = new List<GameObject>();
        for (int i = 0; i < tempCollider.Length; i++) 
        {
            VoterScript voterTemp = tempCollider[i].GetComponent<VoterScript>();
            switch (voterTemp.myOwner)
            {
                case 0:
                    if (tempCollider[i].gameObject == voter && voterTemp.myOwner == 0)
                    {
                        listOfLocalVoters.Add(tempCollider[i].gameObject);
                    }
                    break;
                case 1:
                    if (tempCollider[i].gameObject == voter && voterTemp.myOwner == 1)
                    {
                        listOfLocalVoters.Add(tempCollider[i].gameObject);
                    }
                    break;
                case 2:
                    if (tempCollider[i].gameObject == voter && voterTemp.myOwner == 2)
                    {
                        listOfLocalVoters.Add(tempCollider[i].gameObject);
                    }
                    break;
                case 3:
                    if (tempCollider[i].gameObject == voter && voterTemp.myOwner == 3)
                    {
                        listOfLocalVoters.Add(tempCollider[i].gameObject);
                    }
                    break;
                case 4:
                    if (tempCollider[i].gameObject == voter && voterTemp.myOwner == 4)
                    {
                        listOfLocalVoters.Add(tempCollider[i].gameObject);
                    }
                    break;
            }
        }
    }

}
