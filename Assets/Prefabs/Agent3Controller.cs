using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class dataToSave3
{
    public string userName;
    public int TL;
    public int TR;
    public int T;
    public int H;//and many more
}

public class Agent3Controller : MonoBehaviour
{
    public dataToSave3 dts;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dts.TL == 1)
        {
            anim.SetTrigger("TalkLeft");
        }
        else if (dts.TR == 1)
        {
            anim.SetTrigger("TalkRight");
        }
        else if (dts.H == 1)
        {
            anim.SetTrigger("RaiseHand");
        }
        else if (dts.T == 1)
        {
            anim.SetTrigger("TalkStraight");
        }


        else
        {
            // Only set to idle if none of the specific conditions are met
            
            anim.Play("Idle"); //does this need to be anim.SetTrigger ?
        }

    }
}