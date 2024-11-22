using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public PlayerController playerController; // PlayerControllerスクリプトを参照
    public AudioSource click;
    public void Retry()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        // プレイヤーのライフを初期値に戻す
        playerController.ResetPlayerHealth();

        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}




