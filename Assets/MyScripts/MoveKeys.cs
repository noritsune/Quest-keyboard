using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKeys : MonoBehaviour
{
    [SerializeField] OVRHand ovrHand;
    [SerializeField] OVRSkeleton ovrSkeleton;
    //public struct keyProperty
    //{
    //    public string name;
    //    public OVRSkeleton.BoneId pos;

    //    public keyProperty(string name, OVRSkeleton.BoneId pos)
    //    {
    //        this.name = name;
    //        this.pos = pos;
    //    }
    //}

    //private keyProperty[] key = new keyProperty[]{
    //    new keyProperty{name = "あ", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "か", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "さ", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "た", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "な", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "は", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "ま", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "や", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "ら", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "わ", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "消去", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "空白", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "濁点", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "改行", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "伸ばし棒", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "全消去", pos = OVRSkeleton.BoneId.},
    //    new keyProperty{name = "タイピングゲーム", pos = OVRSkeleton.BoneId.},
    //};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrHand.IsTracked)
        {
            transform.position = ovrSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_WristRoot].Transform.position;
            transform.rotation = ovrSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_WristRoot].Transform.rotation;
        }
    }
}
