using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; //탄알 속력
    private Rigidbody bulletRigidbody; //이동에 사용할 리지드바디 컴포넌트
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed; //로컬상의 0,0,1
        // 리지드바디의 속도 = 앞방향 * 속력
        // transform은 변수, Transform은 타입
        // bulletRigidbody.velocity = new Vector3(0, 0, 1) * speed; //글로벌상의 0,0,1

        Destroy(gameObject, 3f); //3초 뒤 파괴
        // gameObject 자신의 오브젝트를 가리키는 변수
    }
    private void OnTriggerEnter(Collider otherrr) //한정자 반환형식 메소드(매개변수타입 변수명)
        // OnCollisionEnter(Collision collision) 충돌 정보
        // OnTriggerEnter(Collider other) 충돌한 객체의 정보
    {
        if(otherrr.tag=="Player") //인스펙터에서 플레이어 오브젝트에 설정했던 태그
        {// 충돌오브젝트가 Player 태그를 가진 경우 PlayerController 컴포넌트 가져오기
            PlayerController playerController = otherrr.GetComponent<PlayerController>();
            if (playerController !=null)
            {// PlayerController 컴포넌트가 있는 경우 PlayerController의 Die() 메소드 실행
                playerController.Die();
            }// 없을 경우를 대비한 if문
        }
    }
}