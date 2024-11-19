using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneName; //読み込むシーン名
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
            friend.transform.position = Vector3.zero; // 初期位置にリセット
        }

        // 他のリセット処理もここに追加
    }
}
