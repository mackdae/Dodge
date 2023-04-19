using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; //이동에 사용할 Rigidbody 타입의 변수 (컴포넌트)
    public float speed = 10f; //속력 변수
    // 한정자를 public으로 지정하면 유니티 에디터 상에 필드값이 보임
    // [SerializeField] private Rigidbody playerRigidbody;
    // serialize: 직렬화 // [SerializeField]: private를 인스펙터에서 접근 가능하게 직렬화하는 기능
    void Start() 
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input 클래스 GetKey 메소드 KeyCode 열거형상수
        // Input.GetKey는 키보드의 식별자(아스키코드)를 KeyCode 타입으로 받아서 bool 타입으로 반환
        // bool Input.GetKey(KeyCode key);
        //if (Input.GetKey(KeyCode.UpArrow) == true) // 윗 방향키 입력 감지시 z방향 힘 추가
        //{ playerRigidbody.AddForce(0f, 0f, speed); }
        //if (Input.GetKey(KeyCode.DownArrow) == true) // 아래 방향키 입력 감지시 -z방향 힘 추가
        //{ playerRigidbody.AddForce(0f, 0f, -speed); }
        //if (Input.GetKey(KeyCode.RightArrow) == true) // 우측 방향키 입력 감지시 x방향 힘 추가
        //{ playerRigidbody.AddForce(speed, 0f, 0f); }
        //if (Input.GetKey(KeyCode.LeftArrow) == true) // 좌측 방향키 입력 감지시 -x방향 힘 추가
        //{ playerRigidbody.AddForce(-speed, 0f, 0f); }
        //if (Input.GetKey(KeyCode.Space) == true) // 점프ㅋㅋ
        //{ playerRigidbody.AddForce(0f, speed, 0f); }

        // 조작감 개선하기
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        // 수평축 수직축 입력값을 감지 저장
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        // 입력값과 속력을 사용해 실제 이동속도 결정
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // Vector3 속도를 (xSpeed, 0, zSeed)로 생성
        playerRigidbody.velocity = newVelocity;
        // 리지드바디의 속도에 newVelocity 할당
    }
    public void Die()
    {
        gameObject.SetActive(false); //자신의 게임 오브젝트를 비활성화
        //gameObject는 유니티에서 정의해놓은 GameObject타입의 변수(사실은 자동구현 프로퍼티(메소드))
    }
}
