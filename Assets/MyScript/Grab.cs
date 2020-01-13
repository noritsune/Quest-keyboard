using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour
{
    [SerializeField] OVRHand ovrHand;
    [SerializeField] OVRSkeleton ovrSkelton;
    [SerializeField] GameObject IndexSphere;
    public float GRAB_STRENGTH = 0.9f;
    private bool isIndexPinching;
    private float ThumbPinchStrength;

    void Update()
    {
        isIndexPinching = ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        ThumbPinchStrength = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Thumb);
        if (ovrHand.IsTracked)
        {
            Vector3 indexTipPos = ovrSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position;
            Quaternion indexTipRotate = ovrSkelton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.rotation;
            IndexSphere.transform.position = indexTipPos;
            IndexSphere.transform.rotation = indexTipRotate;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "grab") //つかめる物なら
        {
            if (ThumbPinchStrength > GRAB_STRENGTH) //つかんだ
            {
                Debug.Log("つかんだ");
                other.gameObject.transform.parent = IndexSphere.transform;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.localPosition -= Vector3.zero;
            }
            else///はなした
            {
                Debug.Log("はなした");
                other.GetComponent<Rigidbody>().isKinematic = false;
                other.transform.parent = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "grab") //つかめる物なら
        {
            Debug.Log("はなした");
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.parent = null;
        }
    }
}