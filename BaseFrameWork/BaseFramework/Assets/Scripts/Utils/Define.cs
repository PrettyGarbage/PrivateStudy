using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum InputEvent
    {
        Press,
        Click,
    }

    public enum CameraMode
    {
        QuarterView,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }

    //디버그 종류
    public enum Debug
    {
        Log,
        Warning,
        Error,
    }

    /// <summary>
    /// UI TYPE
    /// </summary>
    //버튼의 게임오브젝트 이름
    public enum Buttons
    {
        PointButton,
    }
    //텍스트의 게임오브젝트 이름
    public enum Texts
    {
        PointText,
        ScoreText,
    }
    public enum GameObjects
    {
        GridPanel,
    }
    public enum Images
    {
        ItemIcon,
    }

    /// <summary>
    /// Scene Type
    /// </summary>
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }
    
    /// <summary>
    /// Sound Type
    /// </summary>
    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
}
