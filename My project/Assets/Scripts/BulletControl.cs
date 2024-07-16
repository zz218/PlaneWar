using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class BulletControl: MonoBehaviour
{
    public int score  = 0;
    public string scoretext;
    public GameObject canvas;

    public GameManage gamemanage;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;

        scoretext = GameObject.Find("Canvas").GetComponentInChildren<Text>().text;
        gamemanage = GameObject.Find("GameManage").GetComponent<GameManage>();
        //Debug.Log(scoretext);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 10);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                if(this.name == "EnemyBullet")
                {
                    Debug.Log("玩家扣血");
                    other.SendMessage("Damage",Random.Range(5,21),SendMessageOptions.DontRequireReceiver);
                    Destroy(gameObject);

                }
                break;
            case "Enemy0":
                if (this.name == "PlayerBullet")
                {
                    Debug.Log("敌机扣血");
                    //score += 1;
                    
                    ////scoretext = $"分数： {score}";
                    //scoretext = scoretext + 1;
                    //Debug.Log(scoretext);

                    gamemanage.score += 1;

                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
                break;
            case "Enemy1":
                if (this.name == "PlayerBullet")
                {
                    Debug.Log("敌机扣血");
                    //score += 2;

                    ////scoretext = $"分数： {score}";
                    //scoretext = scoretext + 2;
                    //Debug.Log(scoretext);
                    gamemanage.score += 2;

                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
                break;
            case "Enemy2":
                if (this.name == "PlayerBullet")
                {
                    Debug.Log("敌机扣血");
                    //score += 5;

                    //// scoretext = $"分数： {score}";
                    //scoretext = scoretext + 5;
                    //Debug.Log(scoretext);

                    gamemanage.score += 5;
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
                break;
            default:
                if(this.name != other.name)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}
