using UnityEngine;
using System.Collections;

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
            if (owner == 0)
            {
                /*if (localVoterCount != garrisonValue)
                {
                    temp = Instantiate(voter, spawnPosition, spawnRotation);
                }*/
            }
            else {
                temp = Instantiate(voter, spawnPosition, spawnRotation);
            }
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


    //updates the owner based on current foreign attacker
    private void updateOwner()
    {

        //owner = find the owner ;
    }

    //determine units in an area
    void updateVotersInState()
    {
        //determine how many units are in the sphere of influence of the state
        Vector3 centre = thisState.transform.position;
        Collider[] voterList = Physics.OverlapSphere(centre, 3);

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

        /*if (localVoterCount == 0 && areAllForeignVotersTheSame() == true)
        {
            updateOwner();
        }*/
    }

    //returns a true or false depending on whether all the foreign voters in a state are of the 
    // same owner
    private bool areAllForeignVotersTheSame()
    {
        switch (owner)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
        return false;  
    }



}
