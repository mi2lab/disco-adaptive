using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class TimPositionData
{
    public int neutral;
    public int speaker1;
    public int speaker2;
    public int speaker3;
}

[Serializable]
public class TimDataToSave
{
    public string userName;
    public int Idle;
    public int Talk;
    public bool HandUp;
    public bool HandDown;
}

public class Player3Controller : MonoBehaviour
{
    public TimDataToSave dts;
    public TimPositionData positionData;
    
    public Vector3 neutralVector = new Vector3(9.053f, 1.114f, 5.4f);
    public Vector3 speaker1Vector = new Vector3(5.24f, 0.9f, 6.45f);
    public Vector3 speaker2Vector = new Vector3(7.24f, 0.9f, 6.45f);
    public Vector3 speaker3Vector = new Vector3(2.24f, 0.9f, 6.45f);
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
    
        if (dts.Talk == 1)
        {
            anim.SetTrigger("Talk");
        }
        else if (dts.Idle == 1)
        {
            anim.SetTrigger("SitIdle");
        }
        else if (dts.HandUp == true && dts.HandDown == false)
        {
            anim.SetTrigger("RaiseHand");
        }

        else if (dts.Talk == 0 && dts.Idle == 0 && dts.HandUp == false && dts.HandDown == false)
        {
            anim.SetTrigger("SitIdle");
        }
        // Check for HandDown state
        else if (dts.HandUp == false && dts.HandDown == true)
        {
            anim.SetTrigger("HandDown");
        }

    }
}
