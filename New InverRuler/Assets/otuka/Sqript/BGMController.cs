using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioClip normalBGM;
    public AudioClip gameOverBGM;
    public AudioClip bossDeathBGM;
    public AudioClip gameClearBGM; // ゲームクリア時のBGM

    void Start()
    {
        // 通常のBGMを再生
        bgmSource.clip = normalBGM;
        bgmSource.loop = true; // ループ再生を有効にする
        bgmSource.Play();
    }

    public void PlayGameOverBGM()
    {
        // ゲームオーバーのBGMに切り替え
        bgmSource.clip = gameOverBGM;
        bgmSource.loop = true; // ループ再生を有効にする
        bgmSource.Play();
    }

   

    public void PlayGameClearBGM()
    {
        // ゲームクリア時のBGMに切り替え
        bgmSource.clip = gameClearBGM;
        bgmSource.loop = false; // ループ再生を有効にする
        bgmSource.Play();
    }

  
}