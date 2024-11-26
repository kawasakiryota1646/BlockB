using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioClip normalBGM;
    public AudioClip gameOverBGM;
    public AudioClip bossDeathBGM;
    public AudioClip gameClearBGM; // �Q�[���N���A����BGM

    void Start()
    {
        // �ʏ��BGM���Đ�
        bgmSource.clip = normalBGM;
        bgmSource.loop = true; // ���[�v�Đ���L���ɂ���
        bgmSource.Play();
    }

    public void PlayGameOverBGM()
    {
        // �Q�[���I�[�o�[��BGM�ɐ؂�ւ�
        bgmSource.clip = gameOverBGM;
        bgmSource.loop = true; // ���[�v�Đ���L���ɂ���
        bgmSource.Play();
    }

   

    public void PlayGameClearBGM()
    {
        // �Q�[���N���A����BGM�ɐ؂�ւ�
        bgmSource.clip = gameClearBGM;
        bgmSource.loop = false; // ���[�v�Đ���L���ɂ���
        bgmSource.Play();
    }

  
}