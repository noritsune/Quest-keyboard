using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTrigger : MonoBehaviour
{
    [HideInInspector] public Collider touchingCol = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "grab")
        {
            Debug.Log(transform.tag + "指が" + other.name + "に当たった");
            touchingCol = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "grab")
        {
            Debug.Log(transform.tag + "指が" + other.name + "から離れた");
            touchingCol = null;
        }
    }
}
