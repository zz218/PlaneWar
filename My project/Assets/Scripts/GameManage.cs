using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{

    public int planenum;
    private GameObject[] enemys;

    public int score;
    //public static GameManager _instance;
    public Text scoreText;

    [SerializeField] public List<Button> buttonList = new();

    [SerializeField] public List<GameObject> planeList = new();

    public Image image;

    public GameObject canvas;


    // Start is called before the first frame update
    private void Awake()
    {
        buttonList[0].onClick.AddListener(() => {
            ButtonClick(0);
        });
        buttonList[1].onClick.AddListener(() => {
            ButtonClick(1);
        });
        buttonList[2].onClick.AddListener(() => {
            ButtonClick(2);
        });

        canvas = GameObject.Find("Canvas");
        Text test = canvas.GetComponentInChildren<Text>();
        test.enabled = false;

        //StartCoroutine(AddBtnLis());
    }

    void Start()
    {
        //enemys = Resources.LoadAll<GameObject>("Enemys");
     
        //InvokeRepeating("CreateEnemys", 0, 0.4f);

        scoreText = GameObject.Find("Canvas").GetComponentInChildren<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Your Score : " + score;

        //    GameOver._instance.Show(score);
        
    }

    private void CreateEnemys()//生成方法
    {
        int num = UnityEngine.Random.Range(0, enemys.Length);
        GameObject enemy =  Instantiate(enemys[num],
                            new Vector3(UnityEngine.Random.Range(-6.1f, 6.1f),14,1),
                            Quaternion.identity);
        enemy.AddComponent<Enemy>();
        enemy.tag = "Enemy"+num;
    }

    public void addScore(int planescore)
    {
        score += planescore;
    }

    public void ButtonClick(int i)
    {
        //planenum = i;

        //隐藏image和button
        for(int z = 0; z < buttonList.Count; z++)
        {
            buttonList[z].gameObject.SetActive(false);
        }
        image.gameObject.SetActive(false);

        //分数显示
        canvas = GameObject.Find("Canvas");
        Text test = canvas.GetComponentInChildren<Text>();
        test.enabled = true;

        //构建飞机
        GameObject player = Instantiate(planeList[i],
                               new Vector3(0, -5.69f, -3.25f),
                               Quaternion.identity);
        player.AddComponent<PlayerControl>();
        if (i == 2)
        {
            player.transform.Rotate(new Vector3(0,0,90));
        }

        


        //敌人生成

        enemys = Resources.LoadAll<GameObject>("Enemys");

        InvokeRepeating("CreateEnemys", 0, 0.4f);

        


    }

    //IEnumerator AddBtnLis()
    //{
    //    int i = 3;
        
    //    while(i > 0)
    //    {
    //        buttonList[i-1].onClick.AddListener(() => {
    //            ButtonClick(i-1);
    //        });
    //        i--;
    //        //yield return new WaitUntil();
    //    }
    //}
}

