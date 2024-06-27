using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    /// <summary>
    /// 오랜만에 유니티하니 너무 재밌네여. 땡스투 회장쎈빠이.
    /// </summary>
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    TextMeshProUGUI text;
    float horizontal=0;
    public float velocity=3f;
    public float jumpSpeed = 5f;
    bool isJumping = false;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        Debug.Log(text);
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal == 0)//정지
        {
            rigid.velocity = new Vector2(0,this.rigid.velocity.y);
        }    
        else if (horizontal > 0)//오른쪽
        {
            rigid.velocity = new Vector2(velocity, this.rigid.velocity.y);
        }
        else//왼쪽
        {
            rigid.velocity = new Vector2(-velocity, this.rigid.velocity.y);
        }

        //점프
        if (Input.GetButtonDown("Jump")&& !isJumping)
        {
            this.rigid.velocity = new Vector2(this.rigid.velocity.x, jumpSpeed);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //땅이면 점프금지 풀기
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJumping = false;
            spriteRenderer.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Debug.Log("응애!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject.GetComponent<CapsuleCollider2D>());
            text.text = "Don't trust baka >_<";
        }
    }
}
