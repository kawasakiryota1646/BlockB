using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public PlayerController playerController; // PlayerControllerスクリプトを参照

    public void Retry()
    {
        // プレイヤーのライフを初期値に戻す
        playerController.ResetPlayerHealth();

        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}




