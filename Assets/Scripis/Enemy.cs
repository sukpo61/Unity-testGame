using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    [SerializeField]

    private float moveSpeed = 10f;

    private float minY = -7f;

    [SerializeField]
    private float hp = 10f;

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;

    }


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }

    }
    //test
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0)
            {
                Destroy(gameObject);
                GameObject enemyObject = Instantiate(coin, transform.position, Quaternion.identity);

            }
            Destroy(other.gameObject);

        }
    }
}
