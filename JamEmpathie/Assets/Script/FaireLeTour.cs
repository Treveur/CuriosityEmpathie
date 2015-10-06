using UnityEngine;
using System.Collections;

public class FaireLeTour : MonoBehaviour {

    public REboot reboot;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            reboot.aFaitLeTour = true;
    }
}
