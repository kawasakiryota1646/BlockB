using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの弾を回復するアイテムを出現させるスクリプト
/// </summary>
public class Healitem : MonoBehaviour
{
    public GameObject ammoPrefab;//回復アイテムのプレハブ
    public float spawnInterval = 10f;//回復アイテムの出現間隔
    private bool isSpawning = false;//回復アイテムが出現する条件

    void Start()
    {
        // 初期化時にはアイテム生成を開始しない
    }

    public void StartSpawningAmmo()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating("TrySpawnAmmo", 0f, spawnInterval);
        }
    }

    void TrySpawnAmmo()
    {
        Instantiate(ammoPrefab, GetRandomPosition(), Quaternion.identity);//回復アイテム作成、出現
    }

    Vector3 GetRandomPosition()
    {
        // カメラの上の位置にランダムに生成
        float x = Random.Range(-3,3 );
        float y = Camera.main.orthographicSize + Camera.main.transform.position.y; // カメラの上端
        return new Vector3(x, y, 0);
    }

    public void OnAmmoCollected()
    {
        // プレイヤーが回復アイテムを取ったら生成を中断
        CancelInvoke("TrySpawnAmmo");
        isSpawning = false;

        // 画面外の回復アイテムを消滅させる
        battery[] ammoItems = FindObjectsOfType<battery>();
        foreach (battery item in ammoItems)
        {
            if (!item.GetComponent<Renderer>().isVisible)
            {
                Destroy(item.gameObject);
            }
        }
    }
}


