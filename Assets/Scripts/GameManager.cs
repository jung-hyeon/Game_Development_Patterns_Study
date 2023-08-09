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
         TODO(�߰��� ����)
            - �÷��̾� ���̺� �ε�
            - ���̺갡 ������ �÷��̾ ��� ������ �����̷����Ѵ�.
            - �鿣�带 ȣ���ϰ� ���� ç������ ������ ��´�.
        */
        
        _sessionStartTime = DateTime.Now;
        Debug.Log("Game session start @: " + DateTime.Now);
    }

    void OnApplicationQuit() // ���� ���α׷��� ����Ǳ� ���� ��� GameObjects�� ���۵˴ϴ�.
    {
        _sessionEndTime = DateTime.Now;
        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);

        Debug.Log("Game session ended @: " + DateTime.Now);
        Debug.Log("Game session lasted: " + timeDifference);
    }

    private void OnGUI() // GUI �̺�Ʈ�� �������ϰ� ó���ϱ� ���� ȣ��˴ϴ�.
    {
        if (GUILayout.Button("Next Scene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
