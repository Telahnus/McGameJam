using UnityEngine;
using System.Collections;

public class behaviour : MonoBehaviour {
    public int owner;
    public string destination;
    public int ID;
    public GameObject voter;
    public int voterGarrison;
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
        while (owner != 0 && localVoterCount != voterGarrison)
        {
            //for (int i = 0; i < hazardCount; i++)
            //{
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(voter, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
            //}
            //yield return new WaitForSeconds(waveWait);
        }
    }
    // Update is called once per frame
    void Update ()
    {
        updateVotersInState();
	}

    void updateVotersInState()
    {
        localVoterCount = 0;
        foreignVoterCount = 0;
        //determine how many units are in the sphere of influence of the state
        //report those numbers by changing the variable localVoterCount/foreignVoterCount
    }
}
