using UnityEngine;
using System.Collections;

public class loaderScene : MonoBehaviour {

    private AsyncOperation async;

    // Use this for initialization
    void Start () {
        async = Application.LoadLevelAsync(2);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(async.progress);
	}
}
