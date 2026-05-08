using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // 敵の移動速度
    private Transform playerTransform;

    void Start()
    {
        // "Player"タグがついているオブジェクトを探して、その位置情報を取得
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        // プレイヤーが存在する場合のみ追いかける
        if (playerTransform != null)
        {
            // プレイヤーの方を向く（向きを固定したい場合はコメントアウト）
            transform.LookAt(playerTransform);

            // プレイヤーの方向へ進む
            // transform.forward は LookAt で向いた方向を指します
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
