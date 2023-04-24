using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; //최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기
    private Transform target; // 발사 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간
    //퍼블릭으로 작업 후 프리베이트로 변환

    void Start()
    {
        timeAfterSpawn = 0f; // 생성후 지난시간 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 생성주기 랜덤지정

        target = FindObjectOfType<PlayerController>().transform;
        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 발사대상으로 설정
        // 두 줄 버전
        //PlayerController playerController = FindObjectOfType<PlayerController>();
        //target = playerController.transform;
        
        // FindObjectOfType() 메소드는 처리비용이 커서 한두번 실행되는 메소드에만 사용
        // FindObjectsOfType() 은 해당타입 오브젝트를 모두 찾아서 배열로 반환
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime; // timeAfterSpawn 갱신
        if (timeAfterSpawn >= spawnRate) // 누적시간이 생성주기보다 크거나 같으면
        {
            timeAfterSpawn = 0f; // 시간 리셋
            GameObject bullet //bulletPrefab의 복제본을
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // transform.position 위치와 transform.rotation 회전으로 생성
            // Instantiate 인스턴스화, 처리비용 큼
            bullet.transform.LookAt(target);
            // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            // 다음 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
        }
    }
}