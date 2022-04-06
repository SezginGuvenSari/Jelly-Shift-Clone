using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    public static MirrorScript instance;
    public Transform[] mirrorPoses;


    private int index = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    public void ChangeScaleOfTheMirror(Vector3 scale)
    {
        scale.y *= 2;
        transform.localScale = scale;
    }


    public void ChangePosOfTheMirror()
    {
        index++;
        if (mirrorPoses.Length > index)
        {
            transform.position = mirrorPoses[index].transform.position;
        }
    }
}
