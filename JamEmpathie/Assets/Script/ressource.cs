using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class ressource : MonoBehaviour {

    public GameObject button;
    private bool trigger = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (trigger)
        {
            button.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetMouseButtonDown(1))
            {
                CollectRessource();
            }
        }
	}

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            trigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger = false;
            button.SetActive(false);
        }
    }

    void CollectRessource()
    {
        transform.DOMoveY(transform.position.y - 1f, 1).OnComplete(Scale);
    }

    void Scale()
    {
        transform.DOScale(Vector3.zero, 0.5f).OnComplete(DestroyObj);
        //transform.DOMoveY(transform.position.y - 2, 0.5f).OnComplete(DestroyObj);
    }

    void DestroyObj()
    {
        button.SetActive(false);
        trigger = false;
        Destroy(transform.gameObject);
    }
}
