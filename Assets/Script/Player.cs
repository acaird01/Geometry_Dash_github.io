using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float Player_Speed = 3f;
    public float Player_Jump_Power = 15f;

    public bool isJump = false;
    //public bool CanJump = false;
    private Rigidbody2D rd;

    public float rotateSpeed = 5.0f;
    public ParticleSystem DieEffect;
    public GameObject Player_IMG;

    AudioSource audioSource;
    //public AudioClip Die_Audio;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        audioSource = this.gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentGameState == GameManager.GameState.inGame)
        {
            transform.position += new Vector3(Player_Speed * Time.deltaTime, 0, 0);
            
        }

    }
    [System.NonSerialized]
    public Quaternion targetRot;

    
    private void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameManager.GameState.inGame)
        {
            if (isJump == false)
            {                
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
                //transform.(transform.eulerAngles + new Vector3(0,0,90), 1);
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (isJump != false  /*CanJump == true*/ )
                    {


                        targetRot = Quaternion.Euler(transform.eulerAngles + new Vector3(0.0f, 0.0f, -90.0f));



                        Jump();
                    }
                }
            }
        }
    }
    void Jump()
    {       

        rd.AddForce(Vector3.up * Player_Jump_Power, ForceMode2D.Impulse);
        //transform.Rotate(0, 0, 90, Space.Self);
        

        isJump = false;
        //CanJump = false;
    }

    void JumpPack()
    {
        rd.AddForce(Vector3.up * (Player_Jump_Power + 5f), ForceMode2D.Impulse);
        targetRot = Quaternion.Euler(transform.eulerAngles + new Vector3(0.0f, 0.0f, -90.0f));
        isJump = false;
    }

    void PlayerDie()
    {
        GameManager.instance.Resatart_Scene();
    }

    void End()
    {
        GameManager.instance.GameClear();
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Trap")
        {
            Player_Speed = 0;
            isJump = false;
            DieEffect.Play();
            Player_IMG.SetActive(false);
            audioSource.Play();            
            Invoke("PlayerDie", 1f);
            //PlayerDie();
        }

        
        if (collision.gameObject.tag == "Ground")
        {
            isJump = true;
            //gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            if (gameObject.transform.rotation.z < -88 && gameObject.transform.rotation.z > -92)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (gameObject.transform.rotation.z < -178 && gameObject.transform.rotation.z > -182)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -180);
            }
            else if (gameObject.transform.rotation.z < 92 && gameObject.transform.rotation.z > 88)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (gameObject.transform.rotation.z < 2 && gameObject.transform.rotation.z >= 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (collision.gameObject.tag == "End")
        {
            End();
        }

    }

    void PorterIn()
    {
        Debug.Log("poterin");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JumpPack")
        {
            JumpPack();

            if (isJump == false)
                return;
        }
        if (collision.gameObject.tag == "PorterIn")
        {
            GameManager.instance.PlayerPoterIn();
            
        }
        
    }
}
