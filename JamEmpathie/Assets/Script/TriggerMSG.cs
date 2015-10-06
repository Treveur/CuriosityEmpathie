using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;


public class TriggerMSG : MonoBehaviour {

   // public enum TypeMessage { Text, Audio };

   // public TypeMessage typeMsg;
    public string message = "null";
    public AudioClip audioMessage;

    private Text text;
    private float coolDown;
    public bool playing = false;
    private GameObject SoundManager;

    void Start()
    {
        text = GameObject.Find("GuiTEXT").GetComponent<Text>();
        SoundManager = GameObject.Find("SoundManager");
    }

    void Update()
    {
        //if (playing)
        if(GameObject.Find("Character").GetComponent<AudioSource>().isPlaying)
        {
            //SoundManager.SetActive(false);
        }
        else
        {
            //SoundManager.SetActive(true);
        }

        if(coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")   
        {
            playing = true;
            SpawnMessage(message);
            GameObject.Find("Character").GetComponent<AudioSource>().ignoreListenerVolume = true;
            GameObject.Find("Character").GetComponent<AudioSource>().clip = audioMessage;
            //GameObject.Find("Character").GetComponent<AudioSource>().PlayOneShot(audioMessage, 1);
            GameObject.Find("Character").GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playing = false;
            DeleteMessage();
        }
    }

    void SpawnMessage(string msg)
    {
        text.DOColor(Color.white, 1);
        text.text = msg;
    }

    void DeleteMessage()
    {
        text.DOColor(new Color(1, 1, 1, 0), 1);
    }
}
