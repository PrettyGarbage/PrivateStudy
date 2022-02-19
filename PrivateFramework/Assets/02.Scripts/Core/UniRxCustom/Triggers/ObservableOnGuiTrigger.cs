using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _02.Scripts.Core.UniRxCustom.Triggers
{
    [DisallowMultipleComponent]
    public class ObservableOnGuiTrigger : ObservableTriggerBase
    {
        #region Variable

        private Subject<Unit> _onGui;

        #endregion

        #region Property

        public IObservable<Unit> OnGuiAsObservable()
        {
            return _onGui ??= new Subject<Unit>();
        }

        #endregion

        #region Unity Event

        private void OnGUI()
        {
            if(_onGui != null) _onGui.OnNext(default(Unit));
        }

        #endregion

        #region Method

        protected override void RaiseOnCompletedOnDestroy()
        {
            if(_onGui != null)
                _onGui.OnCompleted();
        }
        #endregion
    }
}