using System.Collections;
using System.Collections.Generic;
using Assets._02.Scripts.Managers;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    static Managers Instance
    {
        get 
        { 
            Init();
            return s_instance;
        }
    }

    private GameManager _game = new GameManager();
    private SoundManager _sound = new SoundManager();
    
    public static GameManager Game => Instance._game;
    public static SoundManager Sound => Instance._sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Init()
    {
        if (s_instance) return;
        
        var go = GameObject.Find(Constants.MANAGERS_ROOT);
        if (!go)
        {
            go = new GameObject { name = Constants.MANAGERS_ROOT };
            go.AddComponent<Managers>();
        }
        DontDestroyOnLoad(go);
        s_instance = go.GetComponent<Managers>();
        
        //매니저 추가되면 아래로 추가
        s_instance._game.Init();
        s_instance._sound.Init();
    }
}
