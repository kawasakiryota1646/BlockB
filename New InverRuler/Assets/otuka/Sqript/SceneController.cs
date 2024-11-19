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
        GameObject[] friends = GameObject.FindGameObjectsWithTag("friend");
        foreach (GameObject friend in friends)
        {
            friend.transform.position = Vector3.zero; // �����ʒu�Ƀ��Z�b�g
        }

        // ���̃��Z�b�g�����������ɒǉ�
    }
}
