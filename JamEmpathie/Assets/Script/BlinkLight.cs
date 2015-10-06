using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BlinkLight : MonoBehaviour {

     public Color lightColor = new Vector4(1, 0, 0, 0);

    private Light alert;

	// Use this for initialization
	void Start () {
        //lightColor = new Vector4(1, 1, 1, 0);
        alert = GetComponent<Light>();
        InvokeRepeating("switchLight", 0f, 1f);
	}
	
	void switchLight()
    {
        if (alert.enabled)
        {
            alert.enabled = false;
        }
        else
        {
            alert.color = lightColor;
            alert.enabled = true;
        }
    }
	
}
