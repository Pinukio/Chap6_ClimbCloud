using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    float threshold = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>(); //player�� component�� �޾ƿ��� ���̹Ƿ� gameObject�� ������ ����
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //����
        //if(Input.GetKeyDown(KeyCode.Space)) ��ǻ�� ����
        //����� ����
        if (Input.GetMouseButtonDown(0) && rigid2D.velocity.y == 0) 
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;
        /* ��ǻ�� ����
        if(Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            key = -1; 
        }
        */
        //����� ����
        if (Input.acceleration.x > this.threshold) key = 1;
        else if (Input.acceleration.x < -this.threshold) key = -1;

        float speedX = Mathf.Abs(this.rigid2D.velocity.x); //���� �÷��̾��� �ӵ�

        // �ӵ� ����
        if (speedX < maxWalkSpeed) 
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        // �̹��� ����
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        // �÷��̾��� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ۴�.
        this.animator.speed = speedX / 2.0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("��");
        SceneManager.LoadScene("ClearScene");
    }
}
