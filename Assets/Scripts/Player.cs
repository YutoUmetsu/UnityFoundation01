using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections; // コルーチンを使うために必要

public class Player : MonoBehaviour
{
    public GameObject Weapons;
    private Vector2 moveInput;
    public float speed;

    [Header("HP設定")]
    [SerializeField] private int hp = 3;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private string gameOverSceneName = "GameOver";

    [Header("スコア設定")]
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    // 無敵判定用
    private bool isInvincible = false;
    [SerializeField] private float invincibleTime = 0.5f;

    void Start()
    {
        UpdateHPText();
        UpdateScoreText(); // スコアの初期表示
    }

    void OnMove(InputValue Value)
    {
        moveInput = Value.Get<Vector2>();
    }

    // 外部（Weapon）から呼ばれるスコア加算メソッド
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(Weapons, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 敵に当たった、かつ無敵じゃない時だけダメージ
        if (collision.gameObject.CompareTag("Enemy") && !isInvincible)
        {
            Destroy(collision.gameObject);

            hp--;
            UpdateHPText();

            if (hp <= 0)
            {
                SceneManager.LoadScene(gameOverSceneName);
            }
            else
            {
                // 無敵開始
                StartCoroutine(BecomeInvincible());
            }
        }
    }

    // 無敵時間を管理するコルーチン
    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;

        // ここで 0.5秒 待機
        yield return new WaitForSeconds(invincibleTime);

        isInvincible = false;
    }

    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = hp.ToString();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // 数字のみ表示
        }
    }
}
