using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan : MonoBehaviour
{
    public Rigidbody snowManRigidbody;
    public float speed = 10f;

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        // Input.GetKey는 키보드의 식별자(아스키코드)를 KeyCode 타입으로 받아서 bool 타입으로 반환
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        // 수평축 수직축 입력여부 * 스피드
        snowManRigidbody.velocity = new Vector3(xSpeed, 0f, zSpeed);

        // 예제에서 변수를 하나 더 거치는 이유가 뭘까?
        //Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //snowManRigidbody.velocity = newVelocity;
        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        // 리지드바디의 속도에 newVelocity 할당
    }

    public void Die()
    {
        //gameObject.SetActive(false);
        // 게임오브젝트 비활성화
        // 디스트로이로 안 하는 이유가 있나?
        Destroy(gameObject);
        // 이부분을 스케일 애니메이션으로 하고 싶어

        //GameManager gameManager = FindObjectOfType<GameManager>();
        // GameManager 타입의 오브젝트를 찾아서 gameManager에 할당
        //gameManager.EndGame(); // gameManager의 EndGame()메소드 실행
    }
}