using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTipsSetter : MonoBehaviour
{
    [SerializeField] OVRHand ovrHand;
    [SerializeField] OVRSkeleton ovrSkeleton;
    enum HandType
    {
        Left,Right
    }
    [SerializeField] HandType handType;
    private GameObject[] fingerTips = new GameObject[5];
    private string[] tagText = { "oya", "hito", "naka", "kusuri", "ko" };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            fingerTips[i] = transform.Find(tagText[i]).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrHand.IsTracked)
        {
            for (int i = 0; i < 5; i++)
            {
                //fingerTipを移動
                fingerTips[i].transform.position = ovrSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.position;
                fingerTips[i].transform.rotation = ovrSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.rotation;
                if (handType == HandType.Left) //左手関節は右手関節と逆向きなので反転
                {
                    fingerTips[i].transform.Rotate(0, 0, 180);
                }
            }
        }
    }
}
