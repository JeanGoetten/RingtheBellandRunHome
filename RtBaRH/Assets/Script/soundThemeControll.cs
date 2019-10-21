using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundThemeControll : MonoBehaviour
{
    AudioSource audio; 
	public AudioClip theme1;
	public AudioClip theme2;
	public AudioClip theme3;
	public AudioClip theme4;

    bool get_belled, x, y, get_finish, z, w, get_bited; 

    void Start()
    {
        audio = GetComponent<AudioSource>(); 

        audio.clip = theme1; 
		audio.Play(); 

        x = false; 
        y = true; 
        z = true; 
        w = true; 

        audio.loop = true; 
    }

    void Update()
    {
        get_belled = PlayerMovement.belled; 
        get_finish = PlayerMovement.finish; 
        get_bited = PlayerMovement.bited; 
        
        if (get_belled)
        {
            x = true; 
        }
        if(x){
            StartCoroutine(Theme_Change()); 
        }
        if (get_finish)
        {
            Finish(); 
        }
        if (get_bited)
        {
            Lose(); 
        }
    }
    IEnumerator Theme_Change(){

        yield return new WaitForSecondsRealtime(1); 
        if(y){
            audio.clip = theme2; 
	    	audio.Play(); 

            y = false; 
        }
    }
    void Finish(){
        if (z)
        {
            audio.clip = theme3; 
            audio.loop = false; 
	    	audio.Play(); 

            z = false; 
        }
    }
    void Lose(){
        if (w)
        {
            audio.clip = theme4; 
            audio.loop = false; 
	    	audio.Play(); 

            w = false; 
        }
    }
    IEnumerator CD(){
        yield return new WaitForSecondsRealtime(5); 
    }
}
