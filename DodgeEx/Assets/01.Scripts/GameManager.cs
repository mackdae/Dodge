using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // UI 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 라이브러리

public class GameManager : MonoBehaviour
{
    // 각 텍스트를 할당할 변수 선언
    public GameObject gameoverText; // 게임오버시 활성화할 텍스트 게임오브젝트
    public Text timeText; // 생존시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
    // 변경할 텍스트만 Text 타입으로 선언

    private float surviveTime; // 생존시간
    private bool isGameover; // 게임오버상태

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        // 생존시간과 게임오버 상태 초기화
    }

    void Update()
    {
        if (!isGameover) // 게임오버가 아니면
                         // 이프문이 비교연산자 없이 (bool)로도 작동하는구나
        {
            surviveTime += Time.deltaTime; // 생존시간 갱신
            timeText.text = "Time: " + (int)surviveTime; // timeText 텍스트 컴포넌트를 이용해 표시
        }
        else if (Input.GetKeyDown(KeyCode.R)) // 게임오버 중 R키를 누르면
        {
            SceneManager.LoadScene("SampleScene"); // 씬 로드
            // 로드씬 메소드로 로드할 씬은 빌드세팅에 등록되어 있어야 함. 샘플씬은 자동등록
            // SceneManager.LoadScene(0); 씬의 인덱스로도 로드 가능

            // 새 씬을 로드하면 기존의 모든것을 파괴
            // 파괴하지 않고 그대로 옮기려면 DontDestroyOnLoad
            // 로드방식 2가지 동기식/비동기식
        }
    }

    public void EndGame() // 현재 게임을 게임오버 상태로 변경하는 메소드
    {
        isGameover = true; // 게임오버 상태로 전환
        gameoverText.SetActive(true); // 게임오버 텍스트 게임오브젝트를 활성화

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime>bestTime) // 최고기록보다 현재생존시간이 더 크면
        {
            bestTime = surviveTime; // 최고기록을 현재생존시간으로 변경
            PlayerPrefs.SetFloat("BestTime", bestTime); // 변경된 최고기록을 BestTime 키로 저장
        }

        // PlayerPrefs 플레이어 프리퍼런스(설정), 유니티 내장 클래스
        // 어떤 수치를 로컬기기에 저장하고 다시 불러오기 가능
        // PlayerPrefs로 BestTime 키에 저장된 이전까지의 최고 기록 가져오기
        // PlayerPrefs로 float, int, string 저장 가능
        // 저장값이 존재하지 않으면 기본값 숫자0 문자""을 반환
        // 저장 여부를 검사하려면 bool hasKey = PlayerPrefs.HasKey("Key")

        recordText.text = "Best Time: " + (int)bestTime;
    }
}