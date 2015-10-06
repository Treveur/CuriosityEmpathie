using UnityEngine;
using System.Collections;
using DG.Tweening;

public class soundManager : MonoBehaviour {

    public AudioClip MainAmbianceLoop;
    public AudioClip MainMoveSound;
    public AudioClip MainTurnSound;
    public AudioClip MainCameraSound;
    public AudioClip[] windsounds;

    private AudioSource musicSource;
    private AudioSource moveSource;
    private AudioSource turnSource;
    private AudioSource cameraSource;
    private AudioSource windSource;

    private Character _char;
    private float coolDownWind = 5;

	// Use this for initialization
	void Start () {
        _char = GameObject.Find("Character").GetComponent<Character>();
        musicSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        moveSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        cameraSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        turnSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        windSource = gameObject.AddComponent<AudioSource>() as AudioSource;

        musicSource.loop = true;
        moveSource.loop = true;
        cameraSource.loop = true;
        turnSource.loop = true;
    }
	
	// Update is called once per frame
	void Update () {
        //Music loop
        if (!musicSource.isPlaying)
        {
            musicSource.clip = MainAmbianceLoop;
            musicSource.Play();
        }

        //Movement loop
	    if(_char.GetComponent<Rigidbody>().velocity.x > 0.1f)
        {
            moveSource.clip = MainMoveSound;
            moveSource.DOFade(0.5f, 0.5f);

            if (!moveSource.isPlaying)
                moveSource.Play(); 
        }
        else
        {
            moveSource.DOFade(0, 0.5f);
        }

        //Rotation Loop
        if (_char.isRotationning)
        {
            turnSource.clip = MainTurnSound;
            turnSource.DOFade(0.5f, 0.5f);

            if (!turnSource.isPlaying)
                turnSource.Play();     
        }
        else
        {
            turnSource.DOFade(0, 0.5f);
        }

        //Wind Random 
        if (coolDownWind <= 0)
        {
            coolDownWind = Random.Range(15f, 45f);
            windSource.clip = windsounds[Random.Range(0, windsounds.Length-1)];
            windSource.Play();
            windSource.loop = false;
        }
        else
            coolDownWind -= Time.deltaTime;
    }
}
