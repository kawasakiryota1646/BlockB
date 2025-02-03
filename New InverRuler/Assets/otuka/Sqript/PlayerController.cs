using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI���g�p���邽�߂ɕK�v
/// <summary>
/// �v���C���[��HP���Ǘ�����X�N���v�g
/// </summary>
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
    bool inDamage = true; //�_���[�W���t���O
    public SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 0.5f;
    public GameObject[] deathEffects; // ���S���̃G�t�F�N�g�i3�i�K�j
    public GameObject gameOverUI; // �Q�[���I�[�o�[����UI
    public GameObject retryUI; // �Q�[���I�[�o�[����UI
    public GameObject StageSelectUI; // �Q�[���I�[�o�[����UI
    public GameObject gameStartText; // GAME START�̃e�L�X�g
    public BGMController bgmController; // BGM�R���g���[���[
    public AudioSource damageAudioSource; // �_���[�W���ʉ��p
    public AudioSource explosionAudioSource; // �������ʉ��p
    public GameObject healthPickupPrefab; // �񕜃A�C�e���̃v���n�u
    public Transform cameraTransform; // �J������Transform
    public float spawnRangeX = 10f; // X�������̏o���͈�
    public float spawnHeight = 4f; // Y�������̏o������
    public GameObject retryButton; // ���g���C�{�^��
    public GameObject nextButton; // ���փ{�^��
    public GameObject gameClearText; // GAME�N���A�̃e�L�X�g
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // FPS��60�ɌŒ�
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        rbody = GetComponent<Rigidbody2D>(); //Rigidbody2D�𓾂�
        gameState = "playing"; //�Q�[���̏�Ԃ��v���C���ɂ���
        gameOverUI.SetActive(false); // �Q�[���I�[�o�[UI���\���ɂ���
        retryUI.SetActive(false); // �Q�[���I�[�o�[UI���\���ɂ���
        StageSelectUI.SetActive(false); // �Q�[���I�[�o�[UI���\���ɂ���
        StartCoroutine(SpawnHealthPickups()); // �񕜃A�C�e�����o��������R���[�`�����J�n
        // GAME START�e�L�X�g��\������R���[�`�����J�n
        StartCoroutine(ShowGameStartText());
    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal"); //���E�L�[����
        axisV = Input.GetAxisRaw("Vertical"); //�㉺�L�[����

        
        //hp���O�Ȃ�GameOver�֐��ɔ��
        if (hp <= 0)
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
        //Enemy�^�O�@EnemyBullet�^�O�̐ڐG�����m
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            GetDamage();//GetDamage�֐��Ɉړ�
        }
       
    }



    //�_���[�W
    void GetDamage()
    {
        if (gameState == "playing")//gameState��playing�Ȃ璆�̏��������s
        {
            if (inDamage == true)//true�Ȃ�hp��-1�@false�Ȃ�hp�͕ϓ����Ȃ�
            {
                hp--;
            }

            if (hp > 0)//hp��0�ȏ�Ȃ璆�̏��������s
            {
                // �_���[�W���ʉ����Đ�
                if (damageAudioSource != null)
                {
                    damageAudioSource.Play();
                }
                //�_���[�W�t���OON
                inDamage = false;
                Debug.Log("false");
                StartCoroutine(Flash());
                Invoke("DamageEnd", 0.5f); // 0.5�b��ɖ��G��Ԃ��I��
                //// hp��3�����̏ꍇ�A�񕜃A�C�e�����o��������
                //if (hp < 3)
                //{
                //    Vector3 spawnPosition = new Vector3(cameraTransform.position.x, cameraTransform.position.y + 5, 0);
                //    Instantiate(healthPickupPrefab, spawnPosition, Quaternion.identity);
                //}
            }
        }
    }

    void DamageEnd()
    {
        
        inDamage = true;
        Debug.Log("true");
    }

    IEnumerator SpawnHealthPickups()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f); // 5�b�҂�

            if (hp < 3)
            {
                float randomX = Random.Range(cameraTransform.position.x - spawnRangeX, cameraTransform.position.x + spawnRangeX);
                float spawnY = cameraTransform.position.y + spawnHeight;
                Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);
                Instantiate(healthPickupPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    //�Q�[���I�[�o�[
    IEnumerator GameOver()
    {
        gameState = "gameover";
        // �v���C���[�̑���𖳌��ɂ���
        GetComponent<PlayerController>().enabled = false;
        //Heart�^�O�̕t���Ă���I�u�W�F�N�g��S�č폜
        GameObject[] healthPickups = GameObject.FindGameObjectsWithTag("Heart");
        foreach (GameObject pickup in healthPickups)
        {
            Destroy(pickup);
        }
        // �������ʉ����Đ�
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

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
        retryUI.SetActive(true);
        StageSelectUI.SetActive(true);


        if(gameOverUI == true)
        {
            // �{�^���ƃe�L�X�g���\���ɂ���
            retryButton.SetActive(false);
            nextButton.SetActive(false);
            gameClearText.SetActive(false);
        }



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

    private IEnumerator Flash()
    {
        while (!inDamage)
        {
            spriteRenderer.color = Color.red; // �_�ŐF
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }
    }

    // GAME START�e�L�X�g��\�����A�Q�[�����~����R���[�`��
    IEnumerator ShowGameStartText()
    {
        gameStartText.SetActive(true); // �e�L�X�g��\��
        Time.timeScale = 0f; // �Q�[�����~
        PlayerController.gameState = "paused"; // �Q�[�����~��Ԃɐݒ�
        yield return new WaitForSecondsRealtime(3f);
        gameStartText.SetActive(false); // �e�L�X�g���\��
        Time.timeScale = 1f; // �Q�[�����ĊJ
        PlayerController.gameState = "playing"; // �Q�[�����v���C��Ԃɐݒ�
    }
}








