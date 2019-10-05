using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneController : MonoBehaviour
{    
    public string nextScene; 
    void Update()
    {
        StartCoroutine(SceneCall()); 
    }
    IEnumerator SceneCall(){
        yield return new WaitForSecondsRealtime(5); 
        SceneManager.LoadScene(nextScene);
    }
}
