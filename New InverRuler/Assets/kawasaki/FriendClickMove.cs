using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendClickMove : MonoBehaviour
{
    public float speed = 5f;  // 移動速度
    private GameObject selectedObject = null;  // 選択されたオブジェクト
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        // 左クリックで選択または移動先を指定
        if (Input.GetMouseButtonDown(0))
        {
            // マウスのワールド座標を取得
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;  // z軸を0に設定して2D空間にする

            // レイキャストでクリックしたオブジェクトを取得
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // もしクリックした場所に何かオブジェクトがあった場合
            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;

                // オブジェクトが「friend」タグを持つ場合にのみ選択
                if (clickedObject.CompareTag("friend"))
                {
                    // 選択されたオブジェクトをセット
                    selectedObject = clickedObject;
                    Debug.Log("Selected object: " + selectedObject.name);
                }
            }
            else if (selectedObject != null)
            {
                // 何もクリックしなかった（背景など）場合は、選択中のオブジェクトを移動
                targetPosition = mousePosition;
                isMoving = true;
                Debug.Log("Target position set: " + targetPosition);
            }
        }

        // 選択したオブジェクトを滑らかに移動させる
        if (isMoving && selectedObject != null)
        {
            // 選択されたオブジェクトを目標位置に向かって移動させる
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position, targetPosition, speed * Time.deltaTime);

            // 目標位置に到達したか確認
            if (Vector3.Distance(selectedObject.transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;  // 移動完了
                Debug.Log("Object reached target position.");
            }
        }
    }
}
