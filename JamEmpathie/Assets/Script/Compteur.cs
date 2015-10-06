using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class Compteur : MonoBehaviour {

    public int compteur;

    private bool displayText;
    private Text text_number;

	// Use this for initialization
	void Start () {
        compteur = 4000516;
        text_number = GameObject.Find("Compteur").GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (!displayText)
            {
                text_number.text = compteur.ToString();
                displayText = true;
            }
            else
            {
                text_number.text = "";
                displayText = false;
            }

        }


    }

    int incrementNbr(int nbr)
    {
       return nbr++;
    }
}
