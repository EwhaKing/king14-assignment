using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    /// <summary>
    /// �������� ����Ƽ�ϴ� �ʹ� ��ճ׿�. ������ ȸ������.
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
        if (horizontal == 0)//����
        {
            rigid.velocity = new Vector2(0,this.rigid.velocity.y);
        }    
        else if (horizontal > 0)//������
        {
            rigid.velocity = new Vector2(velocity, this.rigid.velocity.y);
        }
        else//����
        {
            rigid.velocity = new Vector2(-velocity, this.rigid.velocity.y);
        }

        //����
        if (Input.GetButtonDown("Jump")&& !isJumping)
        {
            this.rigid.velocity = new Vector2(this.rigid.velocity.x, jumpSpeed);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���̸� �������� Ǯ��
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJumping = false;
            spriteRenderer.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Debug.Log("����!");
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
