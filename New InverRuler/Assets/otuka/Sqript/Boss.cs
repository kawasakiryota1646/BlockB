using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public static TEKIHP tekihp; // PlayerController�X�N���v�g���Q��
    private TEKIHP bossHealth;      //�{�X�̗̑�

    void Update()
    {
        
        bossHealth = GetComponentInParent<TEKIHP>(); // �e�I�u�W�F�N�g����BossHealth���擾

        if (bossHealth.currentHealth == 0)
        {
            ChangeScene();
        }

    }

    void ChangeScene()
    {
        SceneManager.LoadScene("�G���f�B���O"); // ���̃V�[�������w��
    }

    
}

