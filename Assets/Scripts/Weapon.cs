using UnityEngine;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // “–‚½‚Á‚½‚Ì”»’èi•Ší‘¤‚ÌCollider‚ÌIs Trigger‚ªON‚Ìê‡j
    // Weapon.cs ‚Ì”»’è•”•ª‚ğC³
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // GameManager‚É•ñ
            GameManager.instance.RemoveEnemy(other.gameObject);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
