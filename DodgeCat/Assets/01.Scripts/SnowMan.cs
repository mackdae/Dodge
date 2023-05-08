using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody snowManRigidbody;
    public GameManager gameManager;
    public Animator snowManAni;
    bool dead; // 죽음여부

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        // Input.GetKey는 키보드의 식별자(아스키코드)를 KeyCode 타입으로 받아서 bool 타입으로 반환
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        // 수평축 수직축 입력여부 * 스피드
        snowManRigidbody.velocity = new Vector3(xSpeed, 0f, zSpeed);

        if (dead) { snowManRigidbody.velocity = new Vector3(0f, 0f, 0f); }
        // 죽음 트루면 제자리 정지
    }

    public void Die()
    {
        dead = true;
        snowManAni.SetBool("Dead", true); // 멜트 애니 재생
        gameManager.Gameover(); // gameManager의 Gameover()메소드 실행
    }
}