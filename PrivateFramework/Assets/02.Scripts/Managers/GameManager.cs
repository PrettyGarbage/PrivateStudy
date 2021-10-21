using System.Collections;
using System.Collections.Generic;
using Assets._02.Scripts.Data;
using UnityEngine;

public class GameManager
{
    private InGameData _inGameData;

    public InGameData InGameData => _inGameData;

    public IEnumerator Init()
    {
        _inGameData = new InGameData();

        yield return null;
    }

    public void Restart()
    {
        //리스타트 해줘야할 애들 넣어주자
    }
}
