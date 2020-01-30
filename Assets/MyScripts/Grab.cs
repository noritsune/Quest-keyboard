using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour
{
    [SerializeField] OVRHand ovrHand;
    [SerializeField] OVRSkeleton ovrSkeleton;
    CatchTrigger[] catchTrigger = new CatchTrigger[5];
    private string[] tagText = { "oya", "hito", "naka", "kusuri", "ko" };
    private bool isGrab = false;
    private Collider grabbingCol;

    void Start()
    {
        ////コンポーネントを取得
        for (int i = 0; i < 5; i++)
        {
            catchTrigger[i] = transform.Find(tagText[i] + "/Sphere").GetComponent<CatchTrigger>();
        }
    }

    private void FixedUpdate()
    {
        if (catchTrigger[0].touchingCol != null)
        {
            if (!isGrab)
            {
                for (int i = 1; i < 5; i++)
                {
                    if (catchTrigger[0].touchingCol == catchTrigger[i].touchingCol)
                    {
                        isGrab = true;
                        Debug.Log(tagText[i] + "指でつかんだ");
                        grabbingCol = catchTrigger[0].touchingCol;
                        grabbingCol.gameObject.transform.parent = transform;
                        grabbingCol.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }
        }
        else
        {
            if (isGrab)
            {
                isGrab = false;
                Debug.Log("はなした");
                grabbingCol.GetComponent<Rigidbody>().isKinematic = false;
                grabbingCol.transform.parent = null;
                grabbingCol = null;
            }
        }
    }
}