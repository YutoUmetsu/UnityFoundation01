using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // 敵のプレハブ
    [SerializeField] private float spawnInterval = 2.0f; // 生成する間隔（秒）

    private BoxCollider spawnArea;
    private float timer;

    void Start()
    {
        // アタッチされているBoxColliderを取得
        spawnArea = GetComponent<BoxCollider>();

        if (spawnArea == null)
        {
            Debug.LogError("BoxColliderが見つかりません！範囲指定用の箱にアタッチしてください。");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0; // タイマーリセット
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null) return;

        // BoxColliderの範囲内のランダムな座標を計算
        Vector3 spawnPosition = GetRandomPositionInBounds();

        // 敵を生成
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomPositionInBounds()
    {
        Bounds bounds = spawnArea.bounds;

        // 範囲内の最小値と最大値の間でランダムな値を決める
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(x, y, z);
    }
}
