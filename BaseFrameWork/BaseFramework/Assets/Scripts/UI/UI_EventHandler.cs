using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// UI 자동화 : 콜백 함수와 이어주기 위한 이벤트핸들러
/// </summary>
public class UI_EventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerClickHandler
{
    public Action<PointerEventData> OnBeginDragHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> OnClickHandler = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragHandler != null)
            OnBeginDragHandler.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null)
            OnClickHandler.Invoke(eventData);
    }
}
