using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalManager : MonoBehaviour

{    
    public string nextScene; 

    public int time; 
    
    private void Awake() {
        Cursor.visible = false;
    }
    void Update()
    {
        StartCoroutine(SceneCall()); 
    }
    IEnumerator SceneCall(){
        yield return new WaitForSecondsRealtime(time); 
        SceneManager.LoadScene(nextScene);
    }
}
