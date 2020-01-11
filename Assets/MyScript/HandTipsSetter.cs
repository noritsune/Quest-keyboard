using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTipsSetter : MonoBehaviour
{
    [SerializeField] OVRHand MYHand;
    [SerializeField] OVRSkeleton MYSkelton;
    private GameObject fingerTip;
    private GameObject[] fingerTips = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        //ovrSkeleton = GetComponent<OVRSkeleton>(); //同オブジェクト内のOVRSkeletonを参照
        fingerTip = (GameObject)Resources.Load("FingerTip");
    }

    // Update is called once per frame
    void Update()
    {
        if (MYHand.IsTracked && fingerTips[0] == null)
        {
            for (int i = 0; i < 5; i++) //全関節にfingerTipを生成
            {
                fingerTips[i] = Instantiate(
                    fingerTip,
                    MYSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.position,
                    MYSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.rotation * Quaternion.Euler(90, 0, 0)
                );
            }

            fingerTips[0].tag = "oya";
            fingerTips[1].tag = "hito";
            fingerTips[2].tag = "naka";
            fingerTips[3].tag = "kusuri";
            fingerTips[4].tag = "ko";
        }

        if (MYHand.IsTracked)
        {
            for (int i = 0; i < 5; i++) //fingerTipを移動
            {
                fingerTips[i].transform.position = MYSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.position;
                fingerTips[i].transform.rotation = MYSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip + i].Transform.rotation * Quaternion.Euler(90, 0 , 0);
            }
        }
    }
}
