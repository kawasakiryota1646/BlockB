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
    public GameObject stage1Options; // Stage1のオプションボタンを含むGameObject
    public GameObject stage2Options; // Stage2のオプションボタンを含むGameObject
    public GameObject stage3Options; // Stage3のオプションボタンを含むGameObject
    public GameObject stage1Options2; // Stage1のオプションボタン2を含むGameObject
    public GameObject stage2Options2; // Stage2のオプションボタン2を含むGameObject
    public GameObject stage3Options2; // Stage3のオプションボタン2を含むGameObject

    void Start()
    {
        stage1Options.SetActive(false); // 最初は非表示にする
        stage2Options.SetActive(false); // 最初は非表示にする
        stage3Options.SetActive(false); // 最初は非表示にする
        stage1Options2.SetActive(false); // 最初は非表示にする
        stage2Options2.SetActive(false); // 最初は非表示にする
        stage3Options2.SetActive(false); // 最初は非表示にする
    }

    public void OnStage1ButtonClick()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        stage1Options.SetActive(true); // Stage1のオプションを表示
        stage2Options.SetActive(false); // Stage2のオプションを非表示
        stage3Options.SetActive(false); // Stage3のオプションを非表示
        stage1Options2.SetActive(true); // Stage1のオプションを表示
        stage2Options2.SetActive(false); // Stage2のオプションを非表示
        stage3Options2.SetActive(false); // Stage3のオプションを非表示
    }

    public void OnStage2ButtonClick()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        stage1Options.SetActive(false); // Stage1のオプションを非表示
        stage2Options.SetActive(true); // Stage2のオプションを表示
        stage3Options.SetActive(false); // Stage3のオプションを非表示
        stage1Options2.SetActive(false); // Stage1のオプションを非表示
        stage2Options2.SetActive(true); // Stage2のオプションを表示
        stage3Options2.SetActive(false); // Stage3のオプションを非表示
    }

    public void OnStage3ButtonClick()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        stage1Options.SetActive(false); // Stage1のオプションを非表示
        stage2Options.SetActive(false); // Stage2のオプションを非表示
        stage3Options.SetActive(true); // Stage3のオプションを表示
        stage1Options2.SetActive(false); // Stage1のオプションを非表示
        stage2Options2.SetActive(false); // Stage2のオプションを非表示
        stage3Options2.SetActive(true); // Stage3のオプションを表示
    }
}


