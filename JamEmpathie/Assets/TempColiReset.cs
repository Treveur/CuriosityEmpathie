using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TempColiReset : MonoBehaviour {

    public GameObject playerControl;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            playerControl.transform.position = playerControl.transform.position + new Vector3(0, 1, 0);
            playerControl.transform.DORotate(Vector3.zero, 0);
            Debug.Log("RETOURNEMENT DEBUG LOL !");
        }
    }
/*
    void OnTriggerStay(Collider other)
    {
        if(other.tag != "Player" && other.tag != "TriggerMSG")
        {
            playerControl.transform.position = playerControl.transform.position + new Vector3(0, 1, 0);
            playerControl.transform.DORotate(Vector3.zero, 0);
            Debug.Log("RETOURNEMENT DEBUG LOL !");
            Debug.Log(other);
        }
    }*/
}
