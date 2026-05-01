using UnityEngine;
using System.Collections.Generic; // リストを使うために必要
using UnityEngine.SceneManagement; // シーン切り替えに必要

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // どこからでもアクセスできるようにする
    public List<GameObject> enemies = new List<GameObject>();
    public string nextSceneName; // 次のシーン名

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // 最初からシーンに配置されている敵をすべてリストに入れる場合
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    // 敵が倒された時に呼び出すメソッド
    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);

        // リストが空になったらシーン移動
        if (enemies.Count <= 0)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
