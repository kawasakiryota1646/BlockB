using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneName; //�ǂݍ��ރV�[����
    public PlayerController playerController;
    public void Load()
    {
        ResetCurrentScene();
        SceneManager.LoadScene(sceneName);
    }

    void ResetCurrentScene()
    {
        
        playerController.ResetPlayerHealth();
        

        // ���̃��Z�b�g�����������ɒǉ�
    }
}
