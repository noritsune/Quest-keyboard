using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl: MonoBehaviour {

    private Vector3 defaultPosition;

    // Use this for initialization
    void Start()
    {
        defaultPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "room")
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<TextMesh>().text = "";
            transform.localPosition = defaultPosition;

        }
    }
}
