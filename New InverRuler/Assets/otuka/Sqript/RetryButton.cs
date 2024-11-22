using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public PlayerController playerController; // PlayerController�X�N���v�g���Q��
    public AudioSource click;
    public void Retry()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        // �v���C���[�̃��C�t�������l�ɖ߂�
        playerController.ResetPlayerHealth();

        // ���݂̃V�[�����ēǂݍ��݂���
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}




