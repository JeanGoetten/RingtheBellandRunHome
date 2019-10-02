using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    public float bossSpeed; 
    private bool get_bited, get_finish; 
    private void Start() {
        bossSpeed = bossSpeed/10; 
    }
    void FixedUpdate()
    {
        get_bited = PlayerMovement.bited; 
        get_finish = PlayerMovement.finish; 
        if(get_bited | get_finish){
            bossSpeed = 0; 
        }
        transform.Translate((Vector3.left * bossSpeed)*Time.deltaTime);
    }
}
