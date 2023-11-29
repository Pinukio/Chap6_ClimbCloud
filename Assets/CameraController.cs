using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player; //카메라에 적용할 거라 플레이어 게임오브젝트만 받아오면 됨
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(
            transform.position.x, playerPos.y, transform.position.z); //y 좌표만 이동
    }
}
