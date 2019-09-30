using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawn : MonoBehaviour
{
    public GameObject goboss;
    private bool get_belled, done; 
    private void Start() {
        done = false; 
    }
    void Update()
    {
        get_belled = PlayerMovement.belled; 

        if(get_belled && !done){
            Instantiate(goboss, new Vector3(154.29f, -1f, 0), Quaternion.identity);
            done = true;  
        }
    }
}
