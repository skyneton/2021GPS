using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float jumpPower = 7.0f;

    private Rigidbody2D rigid;
    bool isGround = true;
    bool canJump = true;

    public Transform groundChecker;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        IsOnGround();
        Jump();
        AttackMotion();
    }

    private void FixedUpdate() {
        Move();
    }

    void IsOnGround() {
        isGround = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);
        if (isGround) {
            canJump = true;
        }
    }

    void AttackMotion() {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {

            anim.SetBool("isAttack", true);
            moveSpeed = 2.5f;
            jumpPower = 5.5f;
            SoundManager.instance.PlaySwordSwingSound();

            Collider2D col = Physics2D.OverlapCircle(transform.position, 2, (1 << LayerMask.NameToLayer("Enemy")));

            if(col != null) {
                AttackEntity(col.gameObject.GetComponent<Enemy>());
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)) {
            anim.SetBool("isAttack", false);
            moveSpeed = 5f;
            jumpPower = 7f;
        }
    }

    void Jump() {
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && (canJump || isGround)) {
            Vector2 velocity = rigid.velocity;
            velocity.y = 0;
            rigid.velocity = velocity;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            if(isGround)
                isGround = false;
            else
                canJump = false;
        }
    }

    void Move() {
        float posX = Input.GetAxis("Horizontal");
        if(posX != 0) {
            if(posX >= 0) {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }else {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        transform.Translate(Mathf.Abs(posX) * Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void AttackEntity(Enemy enemy) {
        enemy.Die();
    }

    public float GetSpeed() {
        return moveSpeed;
    }
}
