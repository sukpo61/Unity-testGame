using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]

    private float moveSpeed;

    [SerializeField]

    private GameObject weapon;

    [SerializeField]

    private Transform shootTransform;
    [SerializeField]

    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;


    // Update is called once per frame
    void Update()
    {
        // float forizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(forizontalInput, verticalInput, 0);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;
        // 상하좌우 움직임

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if(Input.GetKey(KeyCode.LeftArrow)){
        //     transform.position -= moveTo;
        // } else if (Input.GetKey(KeyCode.RightArrow)){
        //     transform.position += moveTo;
        // }
        // 좌우 키를 지정해서 움직임.

        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float tox = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(tox, transform.position.y, transform.position.z);

        Shoot();
    }

    void Shoot()
    {
        if (Time.time - lastShotTime > shootInterval)
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("Coin + 1");
            Destroy(other.gameObject);
        }

    }
}
