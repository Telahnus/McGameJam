using UnityEngine;
using System.Collections;

public class behaviour : MonoBehaviour {
    public int owner;
    public string destination;
    public string thisDestination;
    public GameObject minicube;
    public int garrisonValue;
    public float spawnWait;
    public Vector3 spawnValues;
    public int localVoterCount;
    public int foreignVoterCount;
    //public float startWait;
    //public float waveWait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        //yield return new WaitForSeconds(startWait);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
            Quaternion spawnRotation = Quaternion.identity;
            Object temp = null;
            //check for neutral state, they shouldn't be too high
            if (owner == 0)
            {
                if (localVoterCount != garrisonValue)
                {
                    temp = Instantiate(minicube, spawnPosition, spawnRotation);
                }
            } else {
                temp = Instantiate(minicube, spawnPosition, spawnRotation);
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
    void Update ()
    {
        updateVotersInState();
	}

    //updates the variables containing information on voters in each state
    void updateVotersInState()
    {
        //determine how many units are in the sphere of influence of the state
        //report those numbers by changing the variable localVoterCount/foreignVoterCount
        localVoterCount = 0;
        foreignVoterCount = 0;
        //if local voters all killed and all voters are from same enemy, update owner of state
        if (localVoterCount == 0 && areAllForeignVotersTheSame() == true)
        {
            updateOwner();
        }
    }

    //returns a true or false depending on whether all the foreign voters in a state are of the 
    // same owner
    private bool areAllForeignVotersTheSame()
    {
        return true;
    }

    //updates the owner based on current foreign attacker
    private void updateOwner()
    {
        
        //owner = find the owner ;
    }

    //determine units in an area
    void votersInState()
    {
        private Vector3 centre = Transform.position;
        Collider[] voterList = Physics.OverlapSphere(centre, 3);
        //int ownerTemp = voterList[0].gameObject.owner;
        int i = 1;
        while (i < voterList.Length)
        {
            /*
            if (voterList[i].gameObject.owner != ownerTemp)
            {

            }
            */
            i++;
        }
    }


}
