using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCont : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            MirrorScript.instance.ChangePosOfTheMirror();
        }
    }
}
