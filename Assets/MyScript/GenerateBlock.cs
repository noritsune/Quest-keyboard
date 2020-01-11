using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlock : MonoBehaviour
{
    private Vector3 capsuleOrigin;
    private GameObject capsule;
    private GameObject cylinder;
    private GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        capsuleOrigin = GameObject.Find("カプセル発生点").transform.position;
        capsule = (GameObject)Resources.Load("Capsule");
        cylinder = (GameObject)Resources.Load("Cylinder");
        cube = (GameObject)Resources.Load("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {
        GameObject obj = capsule;
        int random = Random.Range(0, 3);

        switch (random)
        {
            case 0:
                obj = cylinder;
                break;
            case 1:
                obj = cube;
                break;
            default:
                break;
        }

        Instantiate(
            obj,
            capsuleOrigin,
            Quaternion.identity
        );
    }
}
