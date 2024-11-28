using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowBail : MonoBehaviour
{
    public float speed = 5f; // 玉の移動速度
    public float growthRate = 0.1f; // 玉が成長する速さ
    public float maxSize = 3f; // 玉の最大サイズ
    private Vector3 initialScale; // 初期のスケール（サイズ）

    void Start()
    {
        initialScale = transform.localScale; // 玉の初期スケールを保存
    }

    void Update()
    {
        // 玉が下に移動する
        MoveDown();

        // 玉を大きくする
        Grow();
    }

    void MoveDown()
    {
        // 玉が下に進む（Y軸方向に移動）
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void Grow()
    {
        // 玉の現在のスケールを取得
        Vector3 currentScale = transform.localScale;

        // 玉が最大サイズに達していない場合、成長させる
        if (currentScale.x < maxSize && currentScale.y < maxSize)
        {
            // 現在のスケールを元にサイズを増やす
            transform.localScale = new Vector3(
                currentScale.x + growthRate * Time.deltaTime,
                currentScale.y + growthRate * Time.deltaTime,
                currentScale.z
            );
        }
    }
}
