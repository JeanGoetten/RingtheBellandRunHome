using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macaco : MonoBehaviour
{
    private bool get_belled; 

    public GameObject coco; 
    
    void Start()
    {
        get_belled = false; 

        coco.SetActive(false); 
    }

    void Update()
    {
        get_belled = PlayerMovement.belled; 

        if(get_belled){
            coco.SetActive(true); 
        }
    }
}
