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

    //일반적으로 변수는 가장 제한된 범위인 private로 선언하는 것이 좋습니다.
    // 1.캡슐화: 해당 변수를 사용하는 코드가 제한되므로 클래스의 캡슐화가 유지됩니다.
    //           이를 통해 코드의 안정성과 유지보수성이 향상됩니다.
    // 2.보안성: private 변수는 해당 클래스 내부에서만 접근 가능하므로,
    //           외부에서 불필요한 접근을 막을 수 있습니다.
    //           따라서 데이터 보안성을 높일 수 있습니다.
    // 3.에러예방: 다른 개발자들이 의도하지 않은 값을 변경하는 것을 방지할 수 있습니다.
    //             이를 통해 프로그램에서 발생하는 에러를 사전에 예방할 수 있습니다.
    // 4.캐시이점: 해당 변수에 직접 접근할 수 있는 getter와 setter 메서드를 만들 수 있습니다.
    //             이를 통해 변수에 접근할 때마다 계산하는 것이 아닌,
    //             getter에서 캐시된 값을 반환하도록 하여 성능을 향상시킬 수 있습니다.
    //단, public으로 선언해야 하는 경우도 있습니다.
    //예를 들어, 해당 변수를 다른 클래스에서도 자주 사용해야 하거나,
    //해당 변수가 클래스 외부에서 접근 가능해야 하는 경우 등이 있습니다.

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        // private 지정하면 겟컴포넌트 사용으로 해당 오브젝트의 리지드바디를 자동할당
        // 겟컴포넌트 안쓰면 public으로 지정하고 인스펙터뷰에서 수동할당

        // 드래그앤드롭 방식
        //장점
        // 빠르고 간편, 인스펙터 뷰에서 직관적으로 확인 가능
        //단점
        // 할당된 컴포넌트가 삭제되거나 변경될 때 코드도 수정해야 함 //??수정안했는데??
        // 할당된 변수가 많을 경우, 인스펙터 뷰에서 변수를 찾기 어려움

        // GetComponent<T>() 방식
        //장점
        // 컴포넌트를 삭제하거나 변경하더라도 코드 수정 불필요
        // 변수가 많아져도 코드에서 해당 변수를 쉽게 찾아서 수정가능
        //단점
        // 변수를 할당하는 과정에 불필요한 코드가 추가될 가능성
        // 인스펙터 뷰에서 직관적으로 확인하기 어려움
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
        gameObject.SetActive(false); // 자신의 게임 오브젝트를 비활성화
        // gameObject는 유니티에서 정의해놓은 GameObject타입의 변수(사실은 자동구현 프로퍼티(메소드))

        GameManager gameManager = FindObjectOfType<GameManager>();
        // GameManager 타입의 오브젝트를 찾아서 gameManager에 할당
        // GameManager를 Camera에 넣으면 쉽고 더 저렴하게 접근 가능
        // Camera.main.GetComponent<GameManager>();
        // 실무에서는 예외처리도 추가해야 함
        gameManager.EndGame(); // gameManager의 EndGame()메소드 실행
    }
}