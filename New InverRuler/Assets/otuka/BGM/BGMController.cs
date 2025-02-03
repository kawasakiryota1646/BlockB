using UnityEngine;
/// <summary>
/// BGMの再生、切り替えをするスクリプト
/// </summary>
public class BGMController : MonoBehaviour
{
    public AudioSource bgmSource;//BGMを再生するAudioSource
    public AudioClip normalBGM;//通常時に鳴らすBGM
    public AudioClip gameOverBGM;//gameOver(プレイヤーが死亡)した時に鳴らすBGM
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