using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	
	public void loadGame () {
        SceneManager.LoadScene("scene1");
    }

}
