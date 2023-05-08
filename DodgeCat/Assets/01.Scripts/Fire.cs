using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Rigidbody fireRigidbody;
    public float speed = 10f;

    void Start()
    {
        fireRigidbody.velocity = transform.forward * speed; // 리지드바디 속도 = 앞방향 * 속력        
    }
    private void OnTriggerEnter(Collider other)
    {
        // 충돌시 파괴
        if (other.tag != "Stove")
        {
            Destroy(gameObject, 0.2f);
        }

        // 충돌오브젝트가 Player 태그를 가진 경우 SnowMan 가져오기
        if (other.tag == "Player")
        {
            SnowMan player = other.GetComponent<SnowMan>();

            // SnowMan을 가져왔으면 SnowMan의 Die() 실행
            if (player != null)
            {
                player.Die();
            }
        }
    }
}