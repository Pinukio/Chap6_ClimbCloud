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
        this.rigid2D = GetComponent<Rigidbody2D>(); //player의 component를 받아오는 것이므로 gameObject가 정해져 있음
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //점프
        //컴퓨터 버전
        //if(Input.GetKeyDown(KeyCode.Space && this.rigid2D.velocity.y == 0) //y축 속도가 0일 때만 점프가 가능하도록 수정

        //모바일 버전
        if (Input.GetMouseButtonDown(0) && rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;
        /* 컴퓨터 버전
        if(Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            key = -1; 
        }
        */
        //모바일 버전
        if (Input.acceleration.x > this.threshold) key = 1;
        else if (Input.acceleration.x < -this.threshold) key = -1;

        float speedX = Mathf.Abs(this.rigid2D.velocity.x); //현재 플레이어의 속도

        // 속도 제한
        if (speedX < maxWalkSpeed) 
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        // 이미지 반전
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        // 플레이어의 속도에 맞춰 애니메이션 속도를 바꾼다.
        if(this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedX / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        //플레이어가 화면 밖으로 떨어지면 처음부터 시작
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }
}
