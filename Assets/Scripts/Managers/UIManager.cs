using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 10; //0~���� 9�� ���� ����Ǿ��� ȭ���� �ִٴ� �����Ͽ� �纸

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find(Constant.UI_ROOT);
            if (root == null)
                root = new GameObject { name = Constant.UI_ROOT };
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true; //ĵ���� �ȿ� �� ĵ������ ��ø���� ��� �ڽ��� �ڽŸ��� ��ȣ�� �������ϴ� �ɼ�
        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
            canvas.sortingOrder = 0;
    }

    public T MakeItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;


        GameObject go = Managers.Resource.Instantiate(Constant.UI_ITEM_PATH + Constant.UI_INVEN_ITEM);

        if (parent != null)
            go.transform.SetParent(parent);
        else
            Util.DebugLog("Parent Transform is Null", Define.Debug.Warning);

        return Util.GetOrAddComponent<T>(go);
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate(Constant.UI_SCENE_PATH + name);
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

        go.transform.SetParent(Root.transform);

        return sceneUI;
    }

    public T ShowPopupUI<T>(string name = null) where T :UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate(Constant.UI_POPUP_PATH + name);
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup;
    }

    //ClosePopup���� ���� �� ���� ������ ������� ���� �� �ֵ���
    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count <= 0)
            return;

        if(_popupStack.Peek() != popup)
        {
            Util.DebugLog("Close Popup Failed!", Define.Debug.Warning);
            return;
        }
        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        _order--;
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }

    public void Clear()
    {
        CloseAllPopupUI();
        _sceneUI = null;
    }
}
