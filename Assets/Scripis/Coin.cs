using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private float minY = -7f;
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }
    void Jump()
    {
        Rigidbody2D Rigid = GetComponent<Rigidbody2D>();

        float randomJumpForce = Random.Range(4f, 8f);
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;
        jumpVelocity.x = Random.Range(-2f, 2f);
        Rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
