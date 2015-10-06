using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class REboot : MonoBehaviour {

    public int incremental = 662607004;
    public bool aFaitLeTour = false;
    public GameObject panel;
    private Text text;
    private float coolDown;

    void Start()
    {
        text = GameObject.Find("GuiTEXT").GetComponent<Text>();
        panel.SetActive(true);
        //panel.GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), 2);
    }

    void Update()
    {
        if (coolDown > 0)
            coolDown -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        panel.GetComponent<Image>().DOColor(new Color(0, 0, 0, 1), 1).OnComplete(Unfade);
        if (other.tag == "Player")
        {
            if (aFaitLeTour)
                incremental++;

            SpawnMessage(incremental.ToString());
        }
    }

    void Unfade()
    {
        panel.GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), 1);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            DeleteMessage();
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
