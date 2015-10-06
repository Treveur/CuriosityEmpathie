using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraBehavior : MonoBehaviour {

    public float size = 30f;

    private Vector3 _rot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _rot = new Vector3(Input.GetAxis("JoyRightVert"), Input.GetAxis("JoyRightHor"), 0);

       transform.DOLocalRotate(_rot * size, 0.5f);

        //Debug.Log(Input.GetAxis("JoyRightVert"));

        //Input
	}
}
