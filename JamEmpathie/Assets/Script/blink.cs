using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class blink : MonoBehaviour {

    Image _img;

	// Use this for initialization
	void Start () {
        _img = GetComponent<Image>();
        InvokeRepeating("FadeIn", 0, 1);
        InvokeRepeating("FadeOut", 0.5f, 1);
    }

	void FadeIn () {
        _img.DOColor(new Color(1, 1, 1, 1), 0.5f);
	}

    void FadeOut()
    {
        _img.DOColor(new Color(1, 1, 1, 0), 0.5f);
    }
}
