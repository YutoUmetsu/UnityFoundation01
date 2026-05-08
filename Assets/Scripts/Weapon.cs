using UnityEngine;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;
    int score = 300;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // 当たった時の判定（武器側のColliderのIs TriggerがONの場合）
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // シーン内のPlayerスクリプトを探してスコアを加算
            Player player = Object.FindFirstObjectByType<Player>();
            if (player != null)
            {
                player.AddScore(score);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
