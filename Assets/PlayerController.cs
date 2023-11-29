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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            key = -1; 
        }

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
        this.animator.speed = speedX / 2.0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }
}
