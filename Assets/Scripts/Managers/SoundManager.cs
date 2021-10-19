using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>(); //ĳ�̿���

    AudioSource _currentBgm = null;

    public void Init()
    {
        GameObject root = GameObject.Find(Constant.SOUND_ROOT);
        if(root == null)
        {
            root = new GameObject { name = Constant.SOUND_ROOT };
            Object.DontDestroyOnLoad(root);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
            for(int i = 0; i < soundNames.Length -1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Define.Sound.Bgm].loop = true;
        }
    }

   //���߿� ������ �����Ǿ��� ��... JSON/XML������ ������ ��θ� �ִ� ��쿡 Ȱ��
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

    /// <summary>
    /// �޸� ���� ���� Ŭ���� ��Ȳ�� �ٲ� ���� Ŭ����������.
    /// </summary>
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
        if (path.Contains(Constant.SOUND_RESOURCE_PATH) == false)
            path = Constant.SOUND_RESOURCE_PATH + path;

        AudioClip audioClip = null;

        if (audioClip == null)
            Util.DebugLog($"Can't Find Effect {type} Resource : {path}", Define.Debug.Error);

        if (type == Define.Sound.Bgm)
        {
            audioClip = Managers.Resource.Load<AudioClip>(path);
        }
        else
        {
            if(_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        return audioClip;
    }
}
