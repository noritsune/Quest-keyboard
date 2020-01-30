using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlock : MonoBehaviour
{
    private Vector3 origin;
    private string[] name = { "Capsule", "Cylinder", "Cube", "座標系" };
    private GameObject[] block = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        origin = GameObject.Find("カプセル発生点").transform.position;
        for(int i = 0; i < name.Length; i++)
        {
            block[i] = (GameObject)Resources.Load(name[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {
        int random = Random.Range(0, name.Length);

        Instantiate(
            block[random],
            origin,
            Quaternion.identity
        );
    }
}
