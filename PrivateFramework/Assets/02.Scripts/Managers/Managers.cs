using System.Collections;
using System.Collections.Generic;
using Assets._02.Scripts.Managers;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    private static Managers Instance => s_instance;

    private GameManager _game = new GameManager();
    private SoundManager _sound = new SoundManager();
    private StateManager _state = new StateManager();
    private InputManager _input = new InputManager();
    
    public static GameManager Game => Instance._game;
    public static SoundManager Sound => Instance._sound;
    public static StateManager State => Instance._state;
    public static InputManager Input => Instance._input;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Init()
    {
        if (s_instance) yield break;

        var go = GameObject.Find(Constants.MANAGERS_ROOT);
        if (!go)
        {
            go = new GameObject { name = Constants.MANAGERS_ROOT };
            go.AddComponent<Managers>();
        }
        DontDestroyOnLoad(go);
        s_instance = go.GetComponent<Managers>();
        
        //매니저 추가되면 아래로 추가
        yield return s_instance._game.Init();
        yield return s_instance._sound.Init();
        yield return s_instance._state.Init();
        yield return s_instance._input.Init();
    }
}
