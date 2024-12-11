using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    public AudioSource click;
    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;
    public GameObject stage1Options; // Stage1�̃I�v�V�����{�^�����܂�GameObject
    public GameObject stage2Options; // Stage2�̃I�v�V�����{�^�����܂�GameObject
    public GameObject stage3Options; // Stage3�̃I�v�V�����{�^�����܂�GameObject


    void Start()
    {
    stage1Options.SetActive(false); // �m�[�}���X�e�[�W�̃{�^����\��
    stage2Options.SetActive(false); // �m�[�}���X�e�[�W�̃{�^����\��
    stage3Options.SetActive(false); // �m�[�}���X�e�[�W�̃{�^����\��
   
    }
    
    public void OnStage1ButtonClick()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        stage1Options.SetActive(true); // Stage1�̃I�v�V������\��
        stage2Options.SetActive(false); // Stage2�̃I�v�V�������\��
        stage3Options.SetActive(false); // Stage3�̃I�v�V�������\��

    }

    public void OnStage2ButtonClick()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        stage1Options.SetActive(false); // Stage1�̃I�v�V�������\��
        stage2Options.SetActive(true); // Stage2�̃I�v�V������\��
        stage3Options.SetActive(false); // Stage3�̃I�v�V�������\��
    
    }

    public void OnStage3ButtonClick()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        stage1Options.SetActive(false); // Stage1�̃I�v�V�������\��
        stage2Options.SetActive(false); // Stage2�̃I�v�V�������\��
        stage3Options.SetActive(true); // Stage3�̃I�v�V������\��
  
    }
}


