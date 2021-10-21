using System;
using System.Collections;
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

        public IEnumerator Init()
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

            yield return null;
        }
        
        public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
        {
            AudioClip audioClip = GetOrAddAudioClip(path, type);
            Play(audioClip, type, pitch);
        }

        public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
        {
            if (audioClip == null) return;

            if (type == Define.Sound.Bgm)
            {
                AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
                if (audioSource.isPlaying)
                    audioSource.Stop();

                _currentBgm = audioSource;
                audioSource.pitch = pitch;
                audioSource.clip = audioClip;
                audioSource.Play();
            }
            else
            {
                AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
                audioSource.pitch = pitch;
                audioSource.PlayOneShot(audioClip);
            }
        }

        public void VolumeUpDown(float value)
        {
            if (_currentBgm == null)
                return;

            _currentBgm.volume = value;
        }
        
        public void Clear()
        {
            foreach(AudioSource audioSource in _audioSources)
            {
                audioSource.clip = null;
                audioSource.Stop();
            }

            _audioClips.Clear();
        }

        AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
        {
            if (path.Contains(Constants.SOUND_RESOURCE_PATH) == false)
                path = Constants.SOUND_RESOURCE_PATH + path;

            AudioClip audioClip = null;
                
            //TODO : 리소스 매니저 만들어야함.
            // if (type == Define.Sound.Bgm)
            // {
            //     audioClip = Managers.Resource.Load<AudioClip>(path);
            // }
            // else
            // {
            //     if(_audioClips.TryGetValue(path, out audioClip) == false)
            //     {
            //         audioClip = Managers.Resource.Load<AudioClip>(path);
            //         _audioClips.Add(path, audioClip);
            //     }
            // }

            return audioClip;
        }
    }
}