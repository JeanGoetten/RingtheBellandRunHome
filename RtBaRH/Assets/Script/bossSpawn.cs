using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawn : MonoBehaviour
{
    public GameObject goboss;
    private bool get_belled, done; 
    public Transform obj_position; 
    private void Start() {
        done = false; 
    }
    void Update()
    {
        get_belled = PlayerMovement.belled; 

        if(get_belled && !done){
            Instantiate(goboss, obj_position.position, Quaternion.identity);
            done = true;  
        }
    }
}
