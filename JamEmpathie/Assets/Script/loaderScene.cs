using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class loaderScene : MonoBehaviour {

    private AsyncOperation async;

    [SerializeField]
    private Text _progress;

    // Use this for initialization
    void Start () {
        async = Application.LoadLevelAsync(2);
        async.allowSceneActivation = false;
	}
	
	// Update is called once per frame
	void Update () {

        while (!async.isDone && async.progress < 0.9)
        {
            _progress.text = (async.progress * 100) + "%";
            Debug.Log(async.progress);
        }


        Debug.Log("Almost Done");
        async.allowSceneActivation = true;

    }
}
