using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] //请求添加2d的盒型碰撞体



public class PlayerControl : MonoBehaviour
{

    // Start is called before the first frame update
    private GameObject bg;
    private GameObject bulletPrefab;
    private Transform firePos;

    public int hp = 100;

    public int bulletNumber = 5;//子弹
    public float angle = 10;//角度
    void Start()
    {
        bg = GameObject.Find("BG");
        bulletPrefab = Resources.Load<GameObject>("Bullet");
        firePos = transform.GetChild(0);
        InvokeRepeating("Attack", 0, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        bg.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, Time.time / 5));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RangeAttack();//特殊攻击
        }
            
    }

    //移动
    void OnMouseDrag()
    {
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 1;
        targetPos.x = Mathf.Clamp(targetPos.x, -12.34f, 12.34f);
        targetPos.y = Mathf.Clamp(targetPos.y, -6.9f, 6.9f); 
        transform.position = targetPos;
    }
    private void Attack()
    {
        GameObject tempBullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        tempBullet.AddComponent<BulletControl>();
        tempBullet.name = "PlayerBullet";
    }
    private void RangeAttack()//特殊攻击
    {
        for (int i = -bulletNumber / 2; i < bulletNumber / 2 + 1; i++)
        {
            GameObject tempBullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation); 
            tempBullet.transform.Rotate(0, 0, angle * i);
            tempBullet.AddComponent<BulletControl>();

            tempBullet.name = "PlayerBullet";
        }
            

    }

    private void Damage(int damage)
    {
        if(hp > 0)
        {
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
                UnityEditor.EditorApplication.isPlaying = false;
                //Application.Quit();
                //sile
            }
            else
            {
                // Shou shang
            }
        }
    }
}
