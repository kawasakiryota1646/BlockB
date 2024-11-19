using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    int currentBullets = 0; //弾の所持数
    public GameObject BulletText;
    int hp = 0; //プレイヤーのHP
    public GameObject lifeImage; //HPの数を表示するImage
    public Sprite life3Image; //HP3画像
    public Sprite life2Image; //HP2画像
    public Sprite life1Image; //HP1画像
    public Sprite life0Image; //HP0画像
    // Start is called before the first frame update
    
    //アイテム数更新
    void UpdateItemCount()
    {
        //弾
        if(currentBullets != ItemKeeper.currentBullets)
        {
            BulletText.GetComponent<Text>().text = ItemKeeper.currentBullets.ToString();
            currentBullets = ItemKeeper.currentBullets;
        }
    }
    void UpdateHP()
    {
       //Player取得
       if(PlayerController.gameState != "gameend")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player != null)
            {
                if(PlayerController.hp != hp)
                {
                    hp = PlayerController.hp;
                    if(hp <= 0)
                    {
                        lifeImage.GetComponent<Image>().sprite = life0Image;
                        //プレイヤー死亡
                        PlayerController.gameState = "gameend"; //ゲーム終了
                    }
                    else if(hp == 1)
                    {
                        lifeImage.GetComponent<Image>().sprite = life1Image;
                    }
                    else if (hp == 2)
                    {
                        lifeImage.GetComponent<Image>().sprite = life2Image;
                    }
                    else
                    {
                        lifeImage.GetComponent<Image>().sprite = life3Image;
                    }
                }
            }
       }
    }
    void Start()
    {
        UpdateHP(); //HP更新
        UpdateItemCount(); //アイテム数更新
    }

    // Update is called once per frame
    void Update()
    {
        UpdateItemCount(); //アイテム数更新
        UpdateHP(); //HP更新
    }
}
