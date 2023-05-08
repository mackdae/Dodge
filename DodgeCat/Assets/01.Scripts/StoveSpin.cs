using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveSpin : MonoBehaviour
{
    public float speed = 100f; // 회전속도
    public float spinRateMin = 2f; // 최소 회전주기
    public float spinRateMax = 4f; // 최대 회전주기

    float spinRate; // 회전주기
    float timeAfterSpin; // 회전 경과시간
    float spinRandom; // 회전방향+정지여부

    void Start() // 첫실행
    {
        timeAfterSpin = 0f; // 경과시간 초기화
        spinRate = Random.Range(spinRateMin, spinRateMax); // 회전주기 랜덤지정
        spinRandom = Random.Range(-1, 2); // 회전방향+정지여부 랜덤지정
                                          // -1반시계방향, 0정지, 1시계방향
    }

    void Update() // 프레임마다 실행
    {
        timeAfterSpin += Time.deltaTime; // 프레임마다 경과시간 갱신
        if (timeAfterSpin >= spinRate) // 경과시간이 회전주기보다 크면
        {
            timeAfterSpin = 0f; // 경과시간 초기화
            spinRate = Random.Range(spinRateMin, spinRateMax); // 회전주기 랜덤지정
            spinRandom = Random.Range(-1, 2); // 회전방향+정지여부 랜덤지정
        }
        else // 경과시간이 생성주기보다 작으면 계속 회전
        {
            transform.Rotate(0f, speed * spinRandom * Time.deltaTime, 0f);
        }
    }
}