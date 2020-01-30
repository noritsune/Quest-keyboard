using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rig;
    private Vector3 forceDirection = new Vector3(0.0f,  1.0f, 0.0f);
    GenerateBlock generateBlock;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントを取得
        animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        generateBlock = GetComponent<GenerateBlock>();

        //forceDirection = transform.TransformPoint(forceDirection);
        //Debug.Log(forceDirection);

        //rig.AddForce(forceDirection, ForceMode.Acceleration);
        //rig.AddForce(transform.up,ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.up);
        //rig.AddForce(transform.up, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("KeyDownTrigger");
        generateBlock.Generate();   
    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetTrigger("KeyUpTrigger");
    }

}
