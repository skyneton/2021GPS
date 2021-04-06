using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15;
    public float HP = 100;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (HP > 0)
        {
            MoveKey();
        }
    }

    private void MoveKey()
    {
        float posX, posY;
        posX = Input.GetAxis("Horizontal");
        posY = Input.GetAxis("Vertical");

        Vector3 pos = this.transform.position;
        pos.x += posX * Time.deltaTime * speed;
        pos.y += posY * Time.deltaTime * speed;
        if (pos.x > 7.3 || pos.x < -7.3) pos.x = this.transform.position.x;
        if (pos.y > 4.6 || pos.y < -4.6) pos.y = this.transform.position.y;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            HP -= enemy.getDamage();
        }
    }

    public float getHP() {
        return HP;
    }

    public void setHP(float hp) {
        HP = hp;
    }
}
