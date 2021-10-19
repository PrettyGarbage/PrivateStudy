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

    //����� ����
    public enum Debug
    {
        Log,
        Warning,
        Error,
    }

    /// <summary>
    /// UI TYPE
    /// </summary>
    //��ư�� ���ӿ�����Ʈ �̸�
    public enum Buttons
    {
        PointButton,
    }
    //�ؽ�Ʈ�� ���ӿ�����Ʈ �̸�
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
