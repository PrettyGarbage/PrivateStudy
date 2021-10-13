using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    //각 UI들에 붙는 애들을 Define에 걸어두면 양이 많아지기도 하고
    //인벤 item 내부에서만 사용하는 녀석이기 때문에 내부에다가 enum 만듦.
    //필드 수가 적으면 그냥 GameObject로 불러와도 괜찮음.
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
        //이벤트 입력
        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent((PointEventData) => { Util.DebugLog("아이템 클릭"); });
    }

    public void SetInfo(string name)
    {
        _name = name;
    }

    public void SetIconImage()
    {

    }
}
