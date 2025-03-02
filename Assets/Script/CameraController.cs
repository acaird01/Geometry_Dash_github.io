using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public GameObject Player;
    public GameObject Player2;
    Transform AT;
    Transform AT2;
    /*public enum PlayerTyap
    {
        Player1,
        Player2          
    }

    public PlayerTyap playerTyap = PlayerTyap.Player1;*/

    // Start is called before the first frame update
    void Start()
    {
        AT = Player.transform;
        AT2 = Player2.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.instance.playerTyap == GameManager.PlayerTyap.Player1)
        {
            if (Time.timeScale != 0)
            {
                transform.position = Vector3.Lerp(transform.position, AT.position, 2f * Time.deltaTime);
                transform.Translate(0.1f, 0, -10);
            }
            else
                return;
        }
        if(GameManager.instance.playerTyap == GameManager.PlayerTyap.Player2)
        {
            if (Time.timeScale != 0)
            {
                transform.position = Vector3.Lerp(transform.position, AT2.position, 2f * Time.deltaTime);
                transform.Translate(0.1f, 0, -10);
            }
            else
                return;
        }

        /*if (Time.timeScale != 0)
        {
            transform.position = Vector3.Lerp(transform.position, AT.position, 2f * Time.deltaTime);
            transform.Translate(0.1f, 0, -10);
        }
        else
            return;*/
    }
}
