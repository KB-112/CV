using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public enum NextScene 

{
    Scene6 = 6,
    Scene7 = 7, 
    None

}

public class SceneChange : MonoBehaviour
{
    public NextScene NextStage;
    public CanvasGroup canvasGroup;
    private float currentTime = 0f;
    private float  duration = 2f ,starttime =0f , endtime =1f;
    public static event Action EDIntialPosition;

    public static event Action EDRoom1Active;
    public static event Action EDRoom2Active;

    

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();     
    }

  

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ED") )
        {
           
            StartCoroutine(FadeInFadeOut());
                 
        }
    }  
    IEnumerator FadeInFadeOut()
    {
        float currentTime = 0f;
        float t = 0f;

      
        while (t < 1f)
        {
            currentTime += Time.deltaTime;
            t = Mathf.Clamp01(currentTime / duration);
            canvasGroup.alpha = Mathf.Lerp(starttime, endtime, t);
            yield return null;
        }
       
        yield return new WaitForSeconds(1f);


        if (EDIntialPosition != null)
        {
            EDIntialPosition();
        }

        SceneSwitching();

        currentTime = 0f;
        t = 0f;
        while (t < 1f)
        {
            currentTime += Time.deltaTime;
            t = Mathf.Clamp01(currentTime / duration);
            canvasGroup.alpha = Mathf.Lerp(endtime, starttime, t);
            yield return null;
        }    
    }

   public void SceneSwitching()
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (NextStage)
        {
            case NextScene.Scene6:
                if (EDRoom1Active != null)
                {
                    EDRoom1Active();
                }
                SceneManager.LoadSceneAsync((int)NextScene.Scene6);//Current Scene
                
                Debug.Log("Current Scene");
                break;
            case NextScene.Scene7:
                if (EDRoom2Active != null)
                {
                    EDRoom2Active();
                }
                SceneManager.LoadSceneAsync((int)NextScene.Scene7);//PlayScene
               
                Debug.Log("Current Scene");

                Debug.Log("Play Scene");
                break;
            case NextScene.None:
                // StartCoroutine(FadeInFadeOut());
                break;
        }
       
    }

}
