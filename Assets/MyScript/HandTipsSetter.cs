using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTipsSetter : MonoBehaviour
{
    [SerializeField] OVRHand ovrHand;
    [SerializeField] OVRSkeleton ovrSkelton;
    [SerializeField] OVRHand.Hand handType;
    private GameObject fingerTip;
    private GameObject[] fingerTips = new GameObject[5];
    private string[] tagText = { "oya", "hito", "naka", "kusuri", "ko" };
    private string[] tipText = { "あ", "い", "う", "え", "お" };

    // Start is called before the first frame update
    void Start()
    {
        //ovrSkeleton = GetComponent<OVRSkeleton>(); //同オブジェクト内のOVRSkeletonを参照
        fingerTip = (GameObject)Resources.Load("FingerTip");
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrHand.IsTracked && fingerTips[0] == null)
        {
            for (int i = 0; i < 5; i++) //指先にfingerTipを生成
            {
                

                //左手関節は右手関節と逆向きなので反転
                if (handType == OVRHand.Hand.HandLeft)
                {
                    fingerTips[i] = Instantiate(
                        fingerTip,
                        ovrSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.position,
                        ovrSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.rotation * Quaternion.Euler(0, 0, 180)
                    );
                }
                else
                {
                    fingerTips[i] = Instantiate(
                        fingerTip,
                        ovrSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.position,
                        ovrSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.rotation
                    );
                }

                //fingerTipのパラメーター設定
                fingerTips[i].transform.Find("Sphere").tag = tagText[i];
                fingerTips[i].GetComponentInChildren<TextMesh>().text = tipText[i];
            }            
        }

        if (ovrHand.IsTracked)
        {
            for (int i = 0; i < 5; i++) //fingerTipを移動
            {
                fingerTips[i].transform.position = ovrSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.position;

                //左手関節は右手関節と逆向きなので反転
                if (handType == OVRHand.Hand.HandLeft)
                {
                    fingerTips[i].transform.rotation = ovrSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.rotation * Quaternion.Euler(0, 0, 180);
                }
                else
                {
                    fingerTips[i].transform.rotation = ovrSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.rotation;
                }
            }
        }
    }
}
