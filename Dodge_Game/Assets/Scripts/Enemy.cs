using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int directionVector = 1;
    private int speed = 7;
    private float DAMAGE;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetDirectionVector(int directionVector)
    {
        this.directionVector = directionVector;
        if (directionVector == -1)
        {
            Quaternion rot = transform.rotation;
            rot.y = 180;
            transform.rotation = rot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += directionVector * speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x > 7.3 || pos.x < -7.3) gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    public float getDamage()
    {
        Debug.Log(DAMAGE);
        return DAMAGE;
    }

    public void setDamage(float damage)
    {
        this.DAMAGE = damage;
    }


}
