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
    public Material neutralMaterialRef;
    public Material khaledMaterialRef;
    public Material trumpMaterialRef;
    public Material cruzMaterialRef;
    public Material kasichMaterialRef;
    //public float startWait;
    //public float waveWait;
    private static GameObject thisState;

    void Start()
    {
        thisState = this.gameObject;
        StartCoroutine(SpawnWaves());
        updateColourOfProvinceRing();
    }

    IEnumerator SpawnWaves()
    {
        //yield return new WaitForSeconds(startWait);
        while (true)
        {
            //if the owner is neutral, they need to stop producing units. They should stop when they hit their 
            //garrison limit. That limit is not set yet, but should be maybe 10/20 depending on game speed.
            if (owner == 0 && listOfLocallyOwnedLocalVoters().Count == garrisonValue)
            {
                yield return new WaitForSeconds(spawnWait); yield break;
            }
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x)/*+ (float)0.8*/, spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z) /*+ (float)1.7*/);
			Vector3 myPosition = transform.position;
			spawnPosition += myPosition;
			Quaternion spawnRotation = Quaternion.identity;
            GameObject temp = null;


            //we start up the voter, the result is an object we "convert" to a gameobject
            temp = (GameObject) Instantiate(voter, spawnPosition, spawnRotation);

            //in order to edit the variables of that object, we have to access its script
            VoterScript tempVoterScript = temp.GetComponent<VoterScript>();

            //send the location of the current province to the voter
            float tempX = thisState.transform.position.x /*+ (float).8*/;
            float tempY = thisState.transform.position.y;
            float tempZ = thisState.transform.position.z /*+ (float)1.7*/;
            tempVoterScript.destinationLocation = new Vector3(tempX, tempY, tempZ);

            //set the colour (using material) based on the owner
            Renderer tempRenderer = temp.GetComponent<Renderer>();
            switch (owner) {
                case 0:
                    tempRenderer.material = neutralMaterialRef;
                    break;
                case 1:
                    tempRenderer.material = khaledMaterialRef;
                    break;
                case 2:
                    tempRenderer.material = trumpMaterialRef;
                    break;
                case 3:
                    tempRenderer.material = cruzMaterialRef;
                    break;
                case 4:
                    tempRenderer.material = kasichMaterialRef;
                    break;
            }

            //need to add check for neutral state, they shouldn't be too high
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
        if (totalVoters != 0 && areAllForeignVotersTheSame()) { updateOwnerMore(); }
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

    public void updateOwner(int newOwner)
    {
        owner = newOwner;
        updateOwnerMore();
    }

    //updates the owner based on current foreign attacker
    private void updateOwnerMore()
    {
        //grab the game engine object
        GameObject tempEngine = GameObject.FindGameObjectWithTag("Engine");
        //grab the script of the object
        Engine tempEnginerScript = tempEngine.GetComponent<Engine>();
        if (tempEnginerScript.isWin())
        {

        }
        updateColourOfProvinceRing();
    }

    private void updateColourOfProvinceRing ()
    {
        //grab the renderer of the torus in ringaround in the province
        Renderer tempRenderer = thisState.transform.FindChild("ringaround").FindChild("Torus").GetComponent<Renderer>();
        //based on the new owner change the material to reflect that
        switch (owner)
        {
            case 0:
                tempRenderer.material = neutralMaterialRef;
                break;
            case 1:
                tempRenderer.material = khaledMaterialRef;
                break;
            case 2:
                tempRenderer.material = trumpMaterialRef;
                break;
            case 3:
                tempRenderer.material = cruzMaterialRef;
                break;
            case 4:
                tempRenderer.material = kasichMaterialRef;
                break;
        }
    }

    public List<GameObject> listOfLocallyOwnedLocalVoters()
    {
        Collider[] tempCollider = listOfVoters();
        List<GameObject> listOfLocalVoters = new List<GameObject>();
        for (int i = 0; i < tempCollider.Length; i++) 
        {
            Collider colliderTemp = tempCollider[i];
            if (colliderTemp.gameObject.tag != "Player") { continue; }
            
            VoterScript voterTemp = colliderTemp.gameObject.GetComponent<VoterScript>();
            if (voterTemp == null) { continue; }
            switch (owner)
            {
                case 0:
                    if (voterTemp.myOwner == 0)
                    {
                        listOfLocalVoters.Add(tempCollider[i].gameObject);
                    }
                    break;
                case 1:
                    if (voterTemp.myOwner == 1)
                    {
                        listOfLocalVoters.Add(tempCollider[i].gameObject);
                    }
                    break;
                case 2:
                    if (voterTemp.myOwner == 2)
                    {
                        listOfLocalVoters.Add(tempCollider[i].gameObject);
                    }
                    break;
                case 3:
                    if (voterTemp.myOwner == 3)
                    {
                        listOfLocalVoters.Add(tempCollider[i].gameObject);
                    }
                    break;
                case 4:
                    if (voterTemp.myOwner == 4)
                    {
                        listOfLocalVoters.Add(tempCollider[i].gameObject);
                    }
                    break;
            }
        }
        return listOfLocalVoters;
    }

}
