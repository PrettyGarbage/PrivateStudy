using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    //����ó��
    public static T GetOrAddComponent<T> (GameObject go) where T:UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
        {
            component = go.AddComponent<T>();
            DebugLog($"Added Component : {component.name}", Define.Debug.Warning);
        }

        return component;
    }

    /// <summary>
    /// �ڵ�ȭ �κп��� UI�� Ʈ�������� ã�� �Լ�
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    /// <param name="go">root Object</param>
    /// <param name="name">child object name</param>
    /// <param name="recursive">child of child</param>
    /// <returns></returns>
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : Object
    {
        if (go == null)
            return null;

        if(recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if(string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();

                    return (component != null)? component : null;
                }
            }
        }
        else
        {
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name.Equals(name))
                    return component;
            }
        }

        return null;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform != null)
            return transform.gameObject;

        return null;
    }

    //�α���°� �� ���� ��ƸԴ°Ŷ� �����Ϳ����� ����ϵ���!
    public static void DebugLog(string str, Define.Debug type = Define.Debug.Log)
    {
#if UNITY_EDITOR
        switch(type)
        {
            case Define.Debug.Log:
                Debug.Log(str);
                break;
            case Define.Debug.Warning:
                Debug.LogWarning(str);
                break;
            case Define.Debug.Error:
                Debug.LogError(str);
                break;
        }
#endif
    }
}
