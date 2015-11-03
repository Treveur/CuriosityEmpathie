using UnityEngine;
using System.Collections;

public class CameraMenu : MonoBehaviour {

    [SerializeField]
    private GameObject focusObject;

    [SerializeField]
    private float rotationSpeed;

    private Vector3 point;

	// Use this for initialization
	void Start () {
        point = focusObject.transform.position;
        transform.LookAt(point);
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(point, new Vector3(0f, 1f, 0f), 20 * Time.deltaTime * rotationSpeed);
	}
}
