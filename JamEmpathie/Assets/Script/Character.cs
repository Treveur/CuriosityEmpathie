using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Character : MonoBehaviour {

    public float speed = 10;
    public GameObject light1;
    public GameObject jointMiddleArm;

    [HideInInspector]
    public bool isRotationning; // For SoundManager

    private Vector3 _velo;
    private Rigidbody _rigid;
    private bool lightsEnabled = false;
    private float middleArmCoolDown;
    private int nbrScreenshotTaken = 0;

    public AudioClip[] pinceSounds;

    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

	void Update () {
        middleArmCoolDown -= Time.deltaTime;
        //Velocity axis
        _velo = transform.right * Input.GetAxis("Vertical") * speed;
        _velo.y = _rigid.velocity.y;
            //new Vector3(Input.GetAxis("Vertical") * speed, _rigid.velocity.y, 0);
        _rigid.velocity = _velo;



        //Rotation axis
        if(Input.GetAxis("Horizontal") != 0)
        {
            isRotationning = true;
            transform.DOLocalRotate(transform.localEulerAngles + new Vector3(0, Input.GetAxis("Horizontal"), 0), 0.1f);
        }
        else
        {
            isRotationning = false;
        }

        //L clavier ou B/Y manette
        if (Input.GetKeyUp(KeyCode.L) || Input.GetKeyUp(KeyCode.Joystick1Button1))
        {
            if (lightsEnabled)
                lightsEnabled = false;
            else
                lightsEnabled = true;
        }

        if (lightsEnabled)
            light1.SetActive(true);
        else
            light1.SetActive(false);

        if(Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetMouseButtonDown(1))
        {
            if(middleArmCoolDown <= 0)
            {
                jointMiddleArm.transform.DOPunchRotation(new Vector3(0, 0, 20), 3, 1, 0f);
                middleArmCoolDown = 3.1f;

                AudioClip pince = pinceSounds[Random.Range(0, pinceSounds.Length - 1)];
                GetComponent<AudioSource>().PlayOneShot(pince);
                GetComponent<AudioSource>().DOFade(0, 1.5f).OnComplete(Reson);
            }
                
        }

        //Screenshot
        if (Input.GetKeyUp(KeyCode.Joystick1Button5))
        {
            Debug.Log("Screenshot_"+nbrScreenshotTaken);
            Application.CaptureScreenshot("ScreenShot_"+ nbrScreenshotTaken +".png");
            nbrScreenshotTaken++;
        }

        //Limit character rotation on z
        if (transform.localRotation.z < -10)
        {
            transform.DOLocalRotate(transform.localEulerAngles + new Vector3(0, 0, 10), 0.1f);
        }
        else if (transform.localRotation.z > 10)
        {
            transform.DOLocalRotate(transform.localEulerAngles + new Vector3(0, 0, -10), 0.1f);
        }
    }

    void Reson()
    {
        GetComponent<AudioSource>().DOFade(1, 0.5f);
    }
}
