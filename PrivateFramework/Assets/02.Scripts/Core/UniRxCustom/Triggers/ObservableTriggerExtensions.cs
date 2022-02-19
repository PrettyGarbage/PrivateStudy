using System;
using System.Collections;
using System.Collections.Generic;
using _02.Scripts.Core.Extensions;
using _02.Scripts.Core.UniRxCustom.Triggers;
using UniRx;
using UnityEngine;

public static class ObservableTriggerExtensions
{
    #region Method

    public static IObservable<Unit> OnDrawGizmosAsObservable(this Component component)
    {
        if (component == null || component.gameObject == null)
            return Observable.Empty<Unit>(); //아무런 아이템을 발행하지 않고, 완료를 발행하는 옵저버블을 생성

        return Extension.GetOrAddComponent<ObservableOnDrawGizmosTrigger>(component.gameObject)
            .OnDrawGizmosAsObservable();
    }

    public static IObservable<Unit> OnGuiAsObservable(this Component component)
    {
        if (component == null || component.gameObject == null)
            return Observable.Empty<Unit>();

        return Extension.GetOrAddComponent<ObservableOnGuiTrigger>(component.gameObject).OnGuiAsObservable();
    }

    #endregion
}
