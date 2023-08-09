//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>(); // ������ Ÿ���� ù ��°�� �ε�� ������Ʈ �˻�

                if (_instance == null) // ã�� �� ���ٸ� ���� �����
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();

                }
            }
            return _instance;
        }
    }

    public virtual void Awake() // �ش� �Լ� ȣ��� �̱��� ������Ʈ�� �޸𸮿� �ʱ�ȭ�� �ڽ��� �ν��Ͻ��� �̹� �ִ��� Ȯ���ؾ���.
    {
        if (_instance == null) // �޸𸮿� ���ٸ� �ڽ��� ���� �ν��Ͻ��� ��.
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject); // �� ���̸� ��ȯ�� ���� ������.
        }
        else
        {
            Destroy(gameObject); // �̹� ��������ִٸ� ������ ���� ���� �ڽ��� ����(�ΰ��� �߰��Ϸ��� �ϸ� �ϳ��� �ڵ����� ����)
        }
    }
}
