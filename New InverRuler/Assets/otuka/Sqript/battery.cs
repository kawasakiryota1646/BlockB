using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの弾数を回復するアイテムを管理するスクリプト
/// </summary>
public class battery : MonoBehaviour
{
    public int ammoAmount = 5;//弾の回復数
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))//プレイヤータグに反応する
        {
            
            other.GetComponent<BulletController>().AddBullets(ammoAmount);//BulletControllerをコンポーネントして弾を回復させる
            FindObjectOfType<Healitem>().OnAmmoCollected();
            Destroy(gameObject);
        }
    }
}
