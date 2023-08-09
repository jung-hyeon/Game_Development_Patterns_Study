using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    void Start()
    {
        /*
         TODO(추가될 내용)
            - 플레이어 세이브 로드
            - 세이브가 없으면 플레이어를 등록 씬으로 리다이렉션한다.
            - 백엔드를 호출하고 일일 챌린지와 보상을 얻는다.
        */
        
        _sessionStartTime = DateTime.Now;
        Debug.Log("Game session start @: " + DateTime.Now);
    }

    void OnApplicationQuit() // 응용 프로그램이 종료되기 전에 모든 GameObjects로 전송됩니다.
    {
        _sessionEndTime = DateTime.Now;
        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);

        Debug.Log("Game session ended @: " + DateTime.Now);
        Debug.Log("Game session lasted: " + timeDifference);
    }

    private void OnGUI() // GUI 이벤트를 렌더링하고 처리하기 위해 호출됩니다.
    {
        if (GUILayout.Button("Next Scene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
