using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_ver2 : MonoBehaviour
{
    public float Player_Speed = 3f;
    public float Player_Up_Speed = 3f;

    private Rigidbody2D rd;

    // 위로 보고있을 때 트루, 방향 위로 전환
    public bool isUp;
    public float rotateSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentGameState == GameManager.GameState.inGame)
        {
            transform.position += new Vector3(Player_Speed * Time.deltaTime, 0, 0);

        }
    }
    //Quaternion targetRot;

    private void FixedUpdate()
    {
        if(GameManager.instance.currentGameState == GameManager.GameState.inGame)
        {
            if (isUp == true)
            {
                //여기선 한번만 해야됨 2일차 파일 쓰면 될듯?
                // isup이 참일 때 위를 한번 바라보고 아래 마우스버튼에서 상승
                //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Lerp(), rotateSpeed * Time.deltaTime);
            }
            if(Input.GetMouseButton(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    UpMove();
                }
            }
            if(isUp != true)
            {
                // isup이 거짓일 때 즉 터치중이 아닐 때 점차 -30방향을 바라보고 하강 아래 마우스버튼업에서 하강코드

            }
            if(Input.GetMouseButtonUp(0))
            {
                isUp = false;
            }

        }
    }

    void UpMove()
    {
        // 올라가는 코드
        //targetRot = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 30.0f));
        isUp = true;
        rd.AddForce(Vector3.up * Player_Up_Speed, ForceMode2D.Impulse);
        //transform.position += new Vector3(0, Player_Up_Speed * Time.deltaTime,0);
    }

    void PlayerDie()
    {
        GameManager.instance.Resatart_Scene();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Trap")
        {
            PlayerDie();
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PorterOut")
        {
            GameManager.instance.PlayerPoterOut();
        }
    }
}
