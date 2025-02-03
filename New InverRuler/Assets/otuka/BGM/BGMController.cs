using UnityEngine;
/// <summary>
/// BGM�̍Đ��A�؂�ւ�������X�N���v�g
/// </summary>
public class BGMController : MonoBehaviour
{
    public AudioSource bgmSource;//BGM���Đ�����AudioSource
    public AudioClip normalBGM;//�ʏ펞�ɖ炷BGM
    public AudioClip gameOverBGM;//gameOver(�v���C���[�����S)�������ɖ炷BGM
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