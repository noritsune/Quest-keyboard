using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingGameManageScript : MonoBehaviour {
    public bool isGaming = false;
    public int level = 1;
    private bool isFirstGame = true;
    private string[,] qWord = new string[11,50]{
        {"あ","い","う","え","お","か","き","く","け","こ",
          "さ","し","す","せ","そ","た","ち","つ","て","と",
          "な","に","ぬ","ね","の","は","ひ","ふ","へ","ほ",
          "ま","み","む","め","も","や","ゆ","よ",
          "ら","り","る","れ","ろ","わ","を","ん","","","",""},
        {"","","","","","が","ぎ","ぐ","げ","ご",
         "ざ","じ","ず","ぜ","ぞ","だ","ぢ","っ","で","ど",
         "ぱ","ぴ","ぷ","ぺ","ぽ","ば","び","ぶ","べ","ぼ",
         "","","","","","","","","","",
         "","","","","","","","","",""},
        { "にじ","こい","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","",""},
        { "とまと","きつね","ごりら","","","","","","","",
          "たぬき","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","",""},
        { "きつつき","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","",""},
        { "ぶいあーる","きーぼーど","しーげんご","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","",""},
        { "でぃすぷれい","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","",""},
        { "すまーとふぉん","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","",""},
        { "りーぷもーしょん","こんぷらいあんす","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","",""},
        { "","ぽけっともんすたー","はらけんきゅうしつ","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","","",
          "","","","","","","","","",""},
        { "あーもんど","いとでんわ","うでどけい","えかきうた","おかあさん","かぐやひめ","きねんひん","くさだんご","けっしょう","こいのぼり",
          "さくらんぼ","しゃかいか","すきまかぜ","せいでんき","そーせーじ","たからもの","ちきゅうぎ","つなわたり","てくにっく","ところてん",
          "なんきょく","にっちょく","ぬたうなぎ","ねんりょう","のぼりざか","はりねずみ","ひとりじめ","ふらめんこ","へっどほん","ほうちょう",
          "ましんがん","みすてりー","むしめがね","めんたいこ","もらいなき","やつあたり","ゆうじょう","よーぐると",
          "らっかせい","りこーだー","るーれっと","れもんじる","ろれっくす","わいしゃつ","","んじゃめな","","","",""},
    };
    System.Random random;
    public GameObject levelTextObject;
    public GameObject qTextObject;
    public GameObject mainTextObject;
    private TextMesh levelText;
    private TextMesh qText;
    private TextMesh mainText;
    private int clearedCounter = 0;
    public int cnt = 0;
    GenerateBlock generateBlock;

    // Use this for initialization
    void Start () {
        //コンポーネントを取得
        levelText = levelTextObject.GetComponent<TextMesh>();
        qText = qTextObject.GetComponent<TextMesh>();
        mainText = mainTextObject.GetComponent<TextMesh>();
        generateBlock = GetComponent<GenerateBlock>();
        
        mainText.color = Color.green;

        levelText.text = "";
        qText.text = "";
        qText.text = "";
        random = new System.Random();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void QTextUpdate()
    {
        if (isGaming)
        {
            if(isFirstGame)
            {
                mainText.text = "青文字の単語を入力してEnterを押してください\n" +
                                "[全消去キーで開始]";
                isFirstGame = false;
            }

            levelText.text = "Lv." + level;
            do
            {
                qText.text = qWord[level - 1, random.Next(qWord.GetLength(1))];
            } while (qText.text == "");
            
            generateBlock.Generate(); //積み木を出す
        }
        else
        {
            levelText.text = "";
            qText.text = "";
        }
    }

    public void Check()
    {
        if (mainText.text == qText.text)
        {
            if (level < 10)
            {
                level++;
            }
            else if(level == 10)
            {
                Clear();
            }
            else if(level == 11)
            {
                cnt++;
                levelText.text = cnt + "回目";
            }

            mainText.color = Color.blue;
        }
        else
        {
            mainText.text = "";
            mainText.color = Color.red;
        }
    }

    public void Clear()
    {
        levelText.text = "クリア！";
        qText.text = "　終了します";
        isGaming = false;
        level = 1;
        isFirstGame = true;
        clearedCounter++;
        Debug.Log("クリア！");
    }
}