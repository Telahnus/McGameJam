using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;

public class MenuScript : MonoBehaviour {
	
	public void loadGame () {
        Thread.Sleep(2500);       
        SceneManager.LoadScene("MainScene");
    }

}
