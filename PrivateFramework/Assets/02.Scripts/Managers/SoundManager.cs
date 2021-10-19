using System;
using System.Collections.Generic;
using Assets._02.Scripts.Common;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._02.Scripts.Managers
{
    public class SoundManager
    {
        private AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
        private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

        private AudioSource _currentBgm = null;

        public void Init()
        {
            GameObject root = GameObject.Find(Constants.SOUND_ROOT);
            if (!root)
            {
                root = new GameObject { name = Constants.SOUND_ROOT };
                Object.DontDestroyOnLoad(root);

                string[] soundNames = Enum.GetNames(typeof(Define.Sound));
                
                for (int i = 0; i < soundNames.Length - 1; i++)
                {
                    GameObject go = new GameObject { name = soundNames[i] };
                    _audioSources[i] = go.AddComponent<AudioSource>();
                    go.transform.parent = root.transform;
                }

                _audioSources[(int)Define.Sound.Bgm].loop = true;
            }
        }
    }
}