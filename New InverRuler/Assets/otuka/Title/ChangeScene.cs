using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���̐؂�ւ��ɕK�v

public class ChangeScene : MonoBehaviour
{
    public string sceneName; //�ǂݍ��ރV�[����
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //�V�[����ǂݍ���
    public void Load()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        SceneManager.LoadScene(sceneName);
    }

}