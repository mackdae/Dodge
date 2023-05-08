using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public GameObject fire; // 프리팹 연결할 변수
    public Transform target; // 타겟(위치) 연결할 변수

    public float spawnRateMin = 1f; // 최소 생성주기
    public float spawnRateMax = 4f; // 최대 생성주기

    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 생성후 경과시간

    void Start()
    {
        timeAfterSpawn = 0f; // 경과시간 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 생성주기 랜덤지정
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime; // 프레임마다 경과시간 갱신

        if (timeAfterSpawn >= spawnRate) // 경과시간이 생성주기보다 크면
        {
            // 프리팹 복제본 생성 (인스턴스화)
            GameObject fireCopy = Instantiate(fire, transform.position, transform.rotation);
            fireCopy.transform.LookAt(target); // 타겟을 향해 회전

            timeAfterSpawn = 0f; // 경과시간 초기화
            spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 생성주기 랜덤지정
        }
    }
}