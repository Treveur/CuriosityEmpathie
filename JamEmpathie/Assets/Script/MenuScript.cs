using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Button playButton;
    public Button creditButton;
    public Button quitButton;

    // Use this for initialization
    void Start ()
    {

        playButton = playButton.GetComponent<Button>();
        creditButton = creditButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void PlayGame()
    {

        Application.LoadLevel(1);
    }

    public void CreditGame()
    {
        Debug.Log("Jeu réalisé par Alexendre Allais, David Birge-Cotte, Adrien Jouanet, Aurélien Montero et Benjamin Ramauge");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
