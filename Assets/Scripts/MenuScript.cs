using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Image FadeImg;
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;
    public bool fading = false;
    public int SceneNumber = 0;

    void Awake(){
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void Update(){
        if (sceneStarting)
            StartScene();
        if (fading){
            Color color = FadeImg.color;
            color.a += 0.01f;
            FadeImg.color = color;
        }
        if (fading && FadeImg.color.a >= 0.95f)
        {
            SceneManager.LoadScene(SceneNumber);
        }
    }

    void FadeToClear(){
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void StartScene(){
        FadeToClear();
        if (FadeImg.color.a <= 0.05f){
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;
            sceneStarting = false;
        }
    }

    public void EndScene(int SceneNumber){
        Debug.Log("pressed start game");
        FadeImg.enabled = true;
        fading = true;
    }

}
