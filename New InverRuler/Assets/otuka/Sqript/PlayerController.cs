using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI���g�p���邽�߂ɕK�v

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float speed = 3.0f; //�ړ��X�s�[�h
    float axisH; //����
    float axisV; //�c��
    Rigidbody2D rbody; //Rigidbody2D
    //�_���[�W�Ή�
    public static int hp = 3; //�v���C���[��HP
    public static string gameState; //�Q�[���̏��
    bool inDamage = false; //�_���[�W���t���O

    public GameObject[] deathEffects; // ���S���̃G�t�F�N�g�i3�i�K�j
    public GameObject gameOverUI; // �Q�[���I�[�o�[����UI
    public GameObject Button1UI; // �Q�[���I�[�o�[����UI
    public GameObject Button2UI; // �Q�[���I�[�o�[����UI
    public GameObject gameStartText; // GAME START�̃e�L�X�g
    public BGMController bgmController; // BGM�R���g���[���[
    public AudioSource deathSound; // ���S���̌��ʉ�
    public AudioSource explosionSound; // �������ʉ�

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // FPS��60�ɌŒ�
        rbody = GetComponent<Rigidbody2D>(); //Rigidbody2D�𓾂�
        gameState = "playing"; //�Q�[���̏�Ԃ��v���C���ɂ���
        gameOverUI.SetActive(false); // �Q�[���I�[�o�[UI���\���ɂ���
        Button1UI.SetActive(false); // �Q�[���I�[�o�[UI���\���ɂ���
        Button2UI.SetActive(false); // �Q�[���I�[�o�[UI���\���ɂ���

        // GAME START�e�L�X�g��\������R���[�`�����J�n
        StartCoroutine(ShowGameStartText());
    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal"); //���E�L�[����
        axisV = Input.GetAxisRaw("Vertical"); //�㉺�L�[����

        if (hp == 0)
        {
            StartCoroutine(GameOver());
        }
    }

    void FixedUpdate()
    {
        //�ړ����x���X�V����
        rbody.velocity = new Vector2(axisH, axisV).normalized * speed;
    }

    //�ڐG
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            GetDamage();
        }
    }

    //�_���[�W
    void GetDamage()
    {
        if (gameState == "playing")
        {
            hp--; //�����炷
            if (hp > 0)
            {
                //�_���[�W�t���OON
                inDamage = true;
                Invoke("DamageEnd", 0.25f);
            }
        }
    }

    public void Clear()
    {
        // �N���A���̏���
    }

    //�Q�[���I�[�o�[
    IEnumerator GameOver()
    {
       

        gameState = "gameover";
        //�Q�[���I�[�o�[���o
        GetComponent<Collider2D>().enabled = false; //�v���C���[�����������

        // 3�i�K�̃G�t�F�N�g��0.2�b���\��
        foreach (GameObject effectPrefab in deathEffects)
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f); // 0.5�b��ɃG�t�F�N�g������
            yield return new WaitForSeconds(0.2f);
        }

        Destroy(player, 0.1f); // �v���C���[������

        // �Q�[���I�[�o�[UI��\��
        gameOverUI.SetActive(true);
        Button1UI.SetActive(true);
        Button2UI.SetActive(true);

        // �Q�[���I�[�o�[BGM���Đ�����
        if (bgmController != null)
        {
            bgmController.PlayGameOverBGM();
        }
    }

    // �v���C���[�̃��C�t�����Z�b�g���郁�\�b�h
    public void ResetPlayerHealth()
    {
        hp = 3; // �����l�ɖ߂�
    }

    // GAME START�e�L�X�g��\�����A�Q�[�����~����R���[�`��
    IEnumerator ShowGameStartText()
    {
        gameStartText.SetActive(true); // �e�L�X�g��\��
        Time.timeScale = 0f; // �Q�[�����~
        yield return new WaitForSecondsRealtime(3f); // 3�b�҂�
        gameStartText.SetActive(false); // �e�L�X�g���\��
        Time.timeScale = 1f; // �Q�[�����ĊJ
    }
}








