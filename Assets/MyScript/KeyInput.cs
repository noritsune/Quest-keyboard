using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    public string TextSet;
    private string str = "";
    private string SPECIAL_CHAR1 = "あぁいぃうぅえぇおぉかがきぎくぐけげこごさざしじすずせぜそぞただちぢつづってでとどはばぱひびぴふぶぷへべぺほぼぽやゃゆゅよょ";
    private string SPECIAL_CHAR2 = "ぁぃぅぇぉがぎぐげござじずぜぞだぢっでどぱぴぷぺぽゃゅょ";
    private string SPECIAL_CHAR3 = "っぱぴぷぺぽ";
    private GameObject mainTextObject;
    private TextMesh mainText;
    private Rigidbody rigidBody;
    private Animator animator;
    private GameObject[] toys = new GameObject[3];
    private string[] toysName = { "Capsule", "Sphere", "Cube" };
    private string[] toysCommand = { "かぷせる", "すふぃあ", "きゅーぶ" };

    TypingGameManageScript typingGameManager;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        mainTextObject = GameObject.Find("mainText");
        mainText = mainTextObject.GetComponent<TextMesh>();
        mainText.color = Color.green;
        mainText.text = "";
        rigidBody = mainTextObject.GetComponent<Rigidbody>();
        
        for (int i = 0; i < toysName.Length; i++)
        {
            toys[i] = (GameObject)Resources.Load(toysName[i]);
        }

        typingGameManager = GameObject.Find("TypingGameManager").GetComponent<TypingGameManageScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //衝突時
    private void OnTriggerEnter(Collider other)
    {
        if (mainText.color == Color.green &&
            (other.gameObject.tag == "oya" ||
             other.gameObject.tag == "hito" ||
             other.gameObject.tag == "naka" ||
             other.gameObject.tag == "kusuri" ||
             other.gameObject.tag == "ko" ))
        {
            animator.SetTrigger("KeyDownTrigger");
            

            animator.SetTrigger("KeyUpTrigger");

            switch (TextSet)
            {
                case "Space":
                    mainText.text += "␣";
                    break;

                case "Enter":
                    
                    if(typingGameManager.isGaming)
                    {
                        typingGameManager.Check();
                    }
                    else
                    {
                        bool isEnter = true;
                        for (int i = 0; i < toysCommand.Length; i++)
                        {
                            if (mainText.text == toysCommand[i])
                            {
                                Instantiate(toys[i]);
                                isEnter = false;
                            }
                        }
                        if(isEnter) mainText.text += "↲\n";
                    }
                    break;

                case "BackSpace":
                    while (mainText.text.Substring(mainText.text.Length - 1, 1) == "\n")
                    {
                        mainText.text = mainText.text.Substring(0, mainText.text.Length - 1);
                    }

                    if (mainText.text.Length > 0)
                    {
                        mainText.text = mainText.text.Substring(0, mainText.text.Length - 1);
                    }
                    break;

                case "Dakuten":
                    string Last_char = mainText.text.Substring(mainText.text.Length - 1, 1);
                    int index = SPECIAL_CHAR1.IndexOf(Last_char);
                    int offset = 0;

                    if (index != -1)
                    {
                        if (SPECIAL_CHAR2.IndexOf(Last_char) != -1)
                        {
                            offset--;
                            if (SPECIAL_CHAR3.IndexOf(Last_char) != -1)
                            {
                                offset--;
                            }
                        }
                        else
                        {
                            offset++;
                        }

                        mainText.text = mainText.text.Substring(0, mainText.text.Length - 1);
                        mainText.text += SPECIAL_CHAR1.Substring(index + offset, 1);
                    }
                    break;

                case "Clean":
                    rigidBody.isKinematic = false;
                    break;

                case "TypingGame":
                    typingGameManager.isGaming = !typingGameManager.isGaming;
                    typingGameManager.QTextUpdate();
                    if (!typingGameManager.isGaming)
                    {
                        rigidBody.isKinematic = false;
                        typingGameManager.cnt = 0 ;
                    }

                    break;

                default:
                    switch (other.gameObject.tag)
                    {
                        case "oya":
                            str = TextSet.Substring(0, 1);
                            break;
                        case "hito":
                            str = TextSet.Substring(1, 1);
                            break;
                        case "naka":
                            str = TextSet.Substring(2, 1);
                            break;
                        case "kusuri":
                            str = TextSet.Substring(3, 1);
                            break;
                        case "ko":
                            str = TextSet.Substring(4, 1);
                            break;
                        default:
                            break;
                    }

                    if (str == "　") str = "";

                    mainText.text += str;
                    break;

            }

            if (mainText.color == Color.green || mainText.color == Color.yellow)
            {
                mainText.color = Color.yellow;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        float time = 0.2f;
        if (mainText.color == Color.blue) time = 0.5f;
        if (mainText.color == Color.red) time = 3.0f;

        StartCoroutine(DelayMethod(time, () =>
        {
            if(mainText.color == Color.blue || mainText.color == Color.red)
            {
                mainText.text = "";
                if(mainText.color == Color.blue)
                {
                    typingGameManager.QTextUpdate();
                }
                else
                {
                    mainText.text = "";
                }
            }
            mainText.color = Color.green;
        }));

    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
    
}

