using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneName; //読み込むシーン名
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
        

        // 他のリセット処理もここに追加
    }
}
