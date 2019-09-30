using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller; 
    public float runSpeed = 40f; 
    float horizontalMove = 0f;   
    bool jump = false;   
    public GameObject cameraOBJ; 
    public GameObject startTXT; 
    public GameObject jumpTXT; 
    public GameObject speedTXT; 
    public GameObject finalTXT; 
    public GameObject returnTXT; 
    public GameObject winTXT; 
    public GameObject bitedTXT; 

    AudioSource audio; 
	public AudioClip doorBell;
	public AudioClip lose;
	public AudioClip boss;

    public static bool belled;
    public static bool bited;
    public static bool finish;
    private void Awake() {
        Time.timeScale = 1;
        startTXT.SetActive(false); 
        jumpTXT.SetActive(false); 
        speedTXT.SetActive(false); 
        finalTXT.SetActive(false); 
        returnTXT.SetActive(false); 
        winTXT.SetActive(false); 
        bitedTXT.SetActive(false); 
    }
    private void Start() {
        audio = GetComponent<AudioSource>(); 
        belled = false; 
        finish = false; 
        bited = false; 
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            jump = true; 
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; 
    }
    private void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);    
        jump = false; 
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "ketchup"){
            jump = true; 
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Boss"){
            bitedTXT.SetActive(true); 

            bited = true; 

            StartCoroutine(Lose()); 
        }
        if(other.gameObject.tag == "ringBell"){
            returnTXT.SetActive(true); 

            StartCoroutine(Stun());

            audio.clip = doorBell; 
			audio.Play(); 

            belled = true; 
        }
        if(other.gameObject.tag == "Finish" && belled){
            finish = true; 

            winTXT.SetActive(true); 

            StartCoroutine(NextScene());

            Time.timeScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "tela1"){
            cameraOBJ.transform.position = new Vector3(-52f, 0, -10); 
        }
        if(other.gameObject.tag == "tela2"){
            cameraOBJ.transform.position = new Vector3(-30.5f, 0, -10); 
        }
        if(other.gameObject.tag == "tela3"){
            cameraOBJ.transform.position = new Vector3(-9f, 0, -10); 
        }
        if(other.gameObject.tag == "tela4"){
            cameraOBJ.transform.position = new Vector3(12.5f, 0, -10); 
        }
        if(other.gameObject.tag == "tela5"){
            cameraOBJ.transform.position = new Vector3(34f, 0, -10); 
        }
        if(other.gameObject.tag == "tela6"){
            cameraOBJ.transform.position = new Vector3(55.5f, 0, -10); 
        }
        if(other.gameObject.tag == "tela7"){
            cameraOBJ.transform.position = new Vector3(77f, 0, -10); 
        }
        if(other.gameObject.tag == "tela8"){
            cameraOBJ.transform.position = new Vector3(98.5f, 0, -10); 
        }
        if(other.gameObject.tag == "tela9"){
            cameraOBJ.transform.position = new Vector3(120f, 0, -10); 
        }
        if(other.gameObject.tag == "tela10"){
            cameraOBJ.transform.position = new Vector3(141.5f, 0, -10); 
        }
        if(other.gameObject.tag == "starthouse"){
            startTXT.SetActive(true); 
        }
        if(other.gameObject.tag == "jumpArea"){
            jumpTXT.SetActive(true); 
        }
        if(other.gameObject.tag == "speedArea"){
            speedTXT.SetActive(true); 
        }
        if(other.gameObject.tag == "finalHouse"){
            finalTXT.SetActive(true); 
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "starthouse"){
            startTXT.SetActive(false); 
        }
        if(other.gameObject.tag == "jumpArea"){
            jumpTXT.SetActive(false); 
        }
        if(other.gameObject.tag == "speedArea"){
            speedTXT.SetActive(false); 
        }
        if(other.gameObject.tag == "finalHouse"){
            finalTXT.SetActive(false); 
        }
        if(other.gameObject.tag == "starthouse"){
            Destroy(other); 
        }
        if(other.gameObject.tag == "jumpArea"){
            Destroy(other); 
        }
        if(other.gameObject.tag == "speedArea"){
            Destroy(other); 
        }
    }

    IEnumerator Stun(){
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.8f); 
        Time.timeScale = 1;
        audio.clip = boss; 
		audio.Play(); 
    }
    IEnumerator NextScene(){
        yield return new WaitForSecondsRealtime(5); 
        SceneManager.LoadScene("Trans2");
    }
    IEnumerator Lose(){
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3); 
        SceneManager.LoadScene("Trans1");
    }
}
