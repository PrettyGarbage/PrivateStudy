using System.Collections;
using Assets._02.Scripts.Common;
using UnityEngine;

namespace Assets._02.Scripts.Managers
{
    public class StateManager
    {
        private Define.StateStatus _stateStatus = Define.StateStatus.None;
        
        public IEnumerator Init()
        {
            yield return null;
        }
    }
}