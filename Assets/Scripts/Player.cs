using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject Weapons;
    private Vector2 moveInput;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnMove(InputValue Value)
    {
        moveInput = Value.Get<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(Weapons,transform.position, transform.rotation);
        }
    }
}
