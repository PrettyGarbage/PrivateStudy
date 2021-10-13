using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Define.Buttons));
        Bind<Text>(typeof(Define.Texts));
        Bind<GameObject>(typeof(Define.GameObjects));
        Bind<Image>(typeof(Define.Images));

        GameObject go = GetImage((int)Define.Images.ItemIcon).gameObject;

        UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);

        GetButton((int)Define.Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);
    }

    int _score = 0;

    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        Get<Text>((int)Define.Texts.ScoreText).text = $"Á¡¼ö : {_score.ToString()}";
    }
}
