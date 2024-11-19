using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public PlayerController playerController; // PlayerController�X�N���v�g���Q��

    public void Retry()
    {
        // �v���C���[�̃��C�t�������l�ɖ߂�
        playerController.ResetPlayerHealth();

        // ���݂̃V�[�����ēǂݍ��݂���
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}




