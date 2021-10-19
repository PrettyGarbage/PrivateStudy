using System.Collections;
using System.Collections.Generic;
using Assets._02.Scripts.Data;
using UnityEngine;

public class GameManager
{
    private InGameData _inGameData;

    public InGameData InGameData => _inGameData;

    public void Init()
    {
        _inGameData = new InGameData();
    }

    public void Restart()
    {
        //리스타트 해줘야할 애들 넣어주자
    }
}
