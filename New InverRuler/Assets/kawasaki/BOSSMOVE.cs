using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSMOVE : MonoBehaviour
{
    public float moveSpeed = 3f;          // ボスの移動速度
    public float changeDirectionInterval = 2f; // 移動方向を変える間隔
    private Vector2 targetPosition;       // 移動先の位置
    private float timer = 0f;             // タイマー

    // エリアの制限範囲
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 3f;

    void Start()
    {
        SetRandomTargetPosition();        // 最初の移動先を決定
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 指定した時間間隔ごとにランダムな方向に移動
        if (timer >= changeDirectionInterval)
        {
            SetRandomTargetPosition();
            timer = 0f;  // タイマーをリセット
        }

        // 移動先に向かってボスを移動させる
        MoveTowardsTarget();
    }

    // ランダムな移動先を決定（エリア内に制限）
    void SetRandomTargetPosition()
    {
        // 指定されたエリア内でランダムな位置を決定
        float randomX = Random.Range(minX, maxX);  // X軸の範囲
        float randomY = Random.Range(minY, maxY);  // Y軸の範囲

        targetPosition = new Vector2(randomX, randomY);  // ランダムな位置をターゲットとして設定
    }

    // ボスをターゲット位置に向かって移動させる
    void MoveTowardsTarget()
    {
        // 現在のボスの位置からターゲット位置までの方向を計算
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        // ボスをその方向に移動させる
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

}
