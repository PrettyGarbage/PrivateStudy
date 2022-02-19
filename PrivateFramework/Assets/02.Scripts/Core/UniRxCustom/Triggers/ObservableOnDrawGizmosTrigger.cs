using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _02.Scripts.Core.UniRxCustom.Triggers
{
    [DisallowMultipleComponent]
    public class ObservableOnDrawGizmosTrigger : ObservableTriggerBase
    {
        #region Variable

        private Subject<Unit> _onDrawGizmos;

        #endregion

        #region Property

        public IObservable<Unit> OnDrawGizmosAsObservable()
        {
            return _onDrawGizmos ??= new Subject<Unit>();
        }

        #endregion

        #region Method

        private void OnDrawGizmos()
        {
            if(_onDrawGizmos != null) _onDrawGizmos.OnNext(default(Unit));
        }

        protected override void RaiseOnCompletedOnDestroy()
        {
            if(_onDrawGizmos != null) _onDrawGizmos.OnCompleted();
        }
        #endregion
    }
}