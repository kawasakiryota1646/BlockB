using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneName; //�ǂݍ��ރV�[����
    public PlayerController playerController;
    public AudioSource click;
    public void Load()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        ResetCurrentScene();
        SceneManager.LoadScene(sceneName);
    }

    void ResetCurrentScene()
    {
        
        playerController.ResetPlayerHealth();
        

        // ���̃��Z�b�g�����������ɒǉ�
    }
}
