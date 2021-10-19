using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    //�� UI�鿡 �ٴ� �ֵ��� Define�� �ɾ�θ� ���� �������⵵ �ϰ�
    //�κ� item ���ο����� ����ϴ� �༮�̱� ������ ���ο��ٰ� enum ����.
    //�ʵ� ���� ������ �׳� GameObject�� �ҷ��͵� ������.
    enum GameObjects
    {
        ItemIcon,
        ItemNameText,
    }

    string _name = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;
        //�̺�Ʈ �Է�
        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent((PointEventData) => { Util.DebugLog("������ Ŭ��"); });
    }

    public void SetInfo(string name)
    {
        _name = name;
    }

    public void SetIconImage()
    {

    }
}
