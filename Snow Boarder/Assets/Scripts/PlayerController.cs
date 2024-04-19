using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float torqueValue = -Input.GetAxis("Horizontal") * torqueAmount;
        rb2d.AddTorque(torqueValue);
    }
}
