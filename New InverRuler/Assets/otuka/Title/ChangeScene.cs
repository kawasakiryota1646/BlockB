using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���̐؂�ւ��ɕK�v
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination; // �}�E�X�C�x���g�ɕK�v

/// <summary>
/// �V�[���̈ړ����Ǘ�����X�N���v�g
/// </summary>
public class ChangeScene : MonoBehaviour
{
    public string sceneName; //�ǂݍ��ރV�[����
    public AudioSource BGM; // SE���Đ����邽�߂�AudioSource
    public AudioSource click; // SE���Đ����邽�߂�AudioSource
    public AudioSource Button_Audio;
    bool first_Button = false;
    // Start is called before the first frame update
    void Start()
    {
       
        if (BGM != null)
        {
            BGM.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�V�[����ǂݍ���
    public void Load()
    {
        //if (BGM != null)
        //{
        //    BGM.Stop();
        //}

        if (click != null)
        {
            click.Play();
        }
        StartCoroutine(ChangeSceneAfterDelay(0.3f)); // 2�b��ɃV�[����ύX
    }
  
    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void OnMouseEnter()
    {
        if(first_Button == false)
        {
            Button_Audio.Play();
            first_Button = true;
        }
    }

    public void OnMouseExit()
    {
        first_Button = false;
    }

}