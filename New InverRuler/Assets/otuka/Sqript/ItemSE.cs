using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

/// <summary>
/// 回復アイテムを獲得した時に鳴らすSEを管理するスクリプト
/// </summary>
public class ItemSE : MonoBehaviour
{
    public AudioSource itemSE;
    public AudioSource itemSE2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {
            // 敵または敵の弾との衝突を無効にする
            Physics2D.IgnoreCollision(other, GetComponent<Collider2D>());
        }
        else if (other.CompareTag("Heart"))
        {
            itemSE.Play();
        }
        else if (other.CompareTag("Heal"))
        {
            itemSE2.Play();
        }
    }
}
