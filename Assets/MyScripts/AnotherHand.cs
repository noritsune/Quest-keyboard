using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherHand : MonoBehaviour
{
    [SerializeField] OVRSkeleton ovrSkeleton;
    private GameObject fingerTip;
    private GameObject[] fingerTips = new GameObject[(int)OVRSkeleton.BoneId.Max];
    // Start is called before the first frame update
    void Start()
    {
        fingerTip = (GameObject)Resources.Load("Sphere");
        for(int i = 0; i < (int)OVRSkeleton.BoneId.Max; i++)
        {
            fingerTips[i] = Instantiate(
                fingerTip,
                ovrSkeleton.Bones[i].Transform.position,
                ovrSkeleton.Bones[i].Transform.rotation
            );
            fingerTips[i].transform.parent = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < (int)OVRSkeleton.BoneId.Max; i++)
        {
            //fingerTipを移動
            fingerTips[i].transform.position = ovrSkeleton.Bones[i].Transform.position + new Vector3(0.0f, 0.0f, 0.5f);
            fingerTips[i].transform.rotation = ovrSkeleton.Bones[i].Transform.rotation;
        }
    }
}
