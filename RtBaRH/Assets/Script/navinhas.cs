using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navinhas : MonoBehaviour
{
    private bool get_belled; 

    public GameObject navinha_0; 
    public GameObject navinha_1; 
    public GameObject navinha_2; 
    public GameObject navinha_3; 
    public GameObject navinha_4; 
    
    void Start()
    {
        get_belled = false; 

        navinha_0.SetActive(false); 
        navinha_1.SetActive(false); 
        navinha_2.SetActive(false); 
        navinha_3.SetActive(false); 
        navinha_4.SetActive(false); 
    }

    void Update()
    {
        get_belled = PlayerMovement.belled; 

        if(get_belled){
            navinha_0.SetActive(true); 
            navinha_1.SetActive(true); 
            navinha_2.SetActive(true); 
            navinha_3.SetActive(true); 
            navinha_4.SetActive(true); 
        }
    }
}
