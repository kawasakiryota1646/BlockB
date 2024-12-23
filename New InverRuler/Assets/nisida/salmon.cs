using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class syake : MonoBehaviour
{
    public float speed = 10f; // ブーメランの移動速度
    public float returnSpeed = 5f; // 戻る時のスピード
    public float maxDistance = 20f; // ブーメランが進む最大距離
    private Vector3 startPosition; // 発射位置
    private bool isReturning = false; // 戻り中かどうか
    private Transform player; // プレイヤーの位置

    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform; // プレイヤーを検索
    }

    void Update()
    {
        // ブーメランが戻っている場合は、プレイヤー位置に向かって戻る
        if (isReturning)
        {
            ReturnToPlayer();
        }
        else
        {
            // ブーメランを前進させる
            MoveForward();
        }
    }

    void MoveForward()
    {
        // ブーメランが最大距離に到達したら戻る
        float distanceTravelled = Vector3.Distance(startPosition, transform.position);
        if (distanceTravelled >= maxDistance)
        {
            isReturning = true;
        }

        // ブーメランがプレイヤーに向かって飛んでいる場合
        Vector3 direction = player.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    void ReturnToPlayer()
    {
        // プレイヤーに向かって戻る
        Vector3 direction = player.position - transform.position;
        transform.position += direction.normalized * returnSpeed * Time.deltaTime;

        // プレイヤーに到達したら、攻撃が完了したので自分自身を削除
        if (Vector3.Distance(transform.position, player.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

}
