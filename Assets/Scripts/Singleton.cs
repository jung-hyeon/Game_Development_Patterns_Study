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
                _instance = FindObjectOfType<T>(); // 지정한 타입의 첫 번째로 로드된 오브젝트 검색

                if (_instance == null) // 찾을 수 없다면 새로 만든다
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();

                }
            }
            return _instance;
        }
    }

    public virtual void Awake() // 해당 함수 호출시 싱글턴 컴포넌트는 메모리에 초기화된 자신의 인스턴스가 이미 있는지 확인해야함.
    {
        if (_instance == null) // 메모리에 없다면 자신이 현재 인스턴스가 됨.
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject); // 씬 사이를 전환할 때도 유지됨.
        }
        else
        {
            Destroy(gameObject); // 이미 만들어져있다면 복제를 막기 위해 자신을 제거(두개를 추가하려고 하면 하나는 자동으로 제거)
        }
    }
}
