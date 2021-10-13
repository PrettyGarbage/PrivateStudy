using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(Define.GameObjects));

        GameObject gridPanel = Get<GameObject>((int)Define.GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        //�ӽ��ڵ� ���߿� �����޾ƿͼ� ����������.
        for(int i = 0; i < 8; i++)
        {
            GameObject item = Managers.UI.MakeItem<UI_Inven_Item>(parent: gridPanel.transform).gameObject;
            UI_Inven_Item invenItem= item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetInfo($"������{i}��");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
