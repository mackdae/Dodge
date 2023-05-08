using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // UI 라이브러리 (텍스트)
using UnityEngine.SceneManagement; // 씬 관리 라이브러리 (로드씬)

public class GameManager : MonoBehaviour
{
    // 갱신할 텍스트용 변수
    public Text timeText; // 타임 텍스트
    public Text recordText; // 레코드 텍스트
    // 껏다켯다만 할 오브젝트용 변수
    public GameObject gameoverText; // 게임오버 텍스트

    float surviveTime; // 생존시간
    bool gameover; // 게임오버여부

    void Start()
    {
        // PlayerPrefs클래스 어떤수치를 로컬기기에 "키"명으로 세이브로드 가능
        float recordTime = PlayerPrefs.GetFloat("Record"); // 최고기록을 "Record"키값으로 초기화
        recordText.text = "Record: " + (float)(int)(recordTime * 100) / 100; // 레코드 텍스트 갱신

        // 소수점 둘째자리까지 값 구하기
        // ((float)(int)(time*100))/100;
        // 이 방법은 코드가 짧고 빠르게 실행되므로, 처리 성능이 더 빠를 수 있습니다.
        // string.Format("{0:N2}", time); 
        // 이 방법은 형식화된 문자열을 반환하기 때문에, 가독성이 좋고 유지보수가 쉽습니다.

        surviveTime = 0; // 생존시간 리셋
        gameover = false; // 게임오버여부 리셋
    }

    void Update()
    {
        if (!gameover) // 게임오버가 폴스면
        {
            surviveTime += Time.deltaTime; // 생존시간 갱신
            timeText.text = "Time: " + (float)(int)(surviveTime * 100) / 100; // 타임 텍스트 갱신
        }

        if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene("SampleScene"); }
        // R: 재시작

        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
        // ESC: 종료

        if (Input.GetKeyDown(KeyCode.Backspace)) // 백스페이스: 최고기록 리셋
        {
            PlayerPrefs.SetFloat("Record", 0);
            recordText.text = "Record: 0";
        }
    }

    public void Gameover()
    {
        gameover = true; // 게임오버 트루
        gameoverText.SetActive(true); // 게임오버 오브젝트 활성

        // PlayerPrefs클래스 어떤수치를 로컬기기에 "키"명으로 세이브로드 가능
        float recordTime = PlayerPrefs.GetFloat("Record");
        // 최고기록을 "Record"키값으로 초기화

        if (surviveTime > recordTime) // 생존시간이 최고기록보다 크면
        {
            recordTime = surviveTime; // 최고기록을 생존시간으로 변경
            PlayerPrefs.SetFloat("Record", recordTime); // 변경된 최고기록을 "Record"키로 저장
        }
        recordText.text = "Record: " + (float)(int)(recordTime * 100) / 100; // 레코드 텍스트 갱신
    }
}