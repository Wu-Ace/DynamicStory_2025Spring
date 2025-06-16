using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("AudioManager");
                    instance = obj.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume = 1f;
        [Range(0.1f, 3f)]
        public float pitch = 1f;
        public bool loop = false;
        public bool playOnStart = false; // 是否在开始时播放
        [HideInInspector]
        public AudioSource source;
    }

    public Sound[] sounds;
    private Dictionary<string, Sound> soundDictionary = new Dictionary<string, Sound>();

    private void Awake()
    {
        // 确保只有一个AudioManager实例
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // 初始化所有音效
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            soundDictionary[s.name] = s;
        }
    }

    private void Start()
    {
        // 播放所有标记为playOnStart的音效
        foreach (Sound s in sounds)
        {
            if (s.playOnStart)
            {
                Play(s.name);
            }
        }
    }

    // 播放指定名称的音效
    public void Play(string name)
    {
        if (soundDictionary.TryGetValue(name, out Sound sound))
        {
            sound.source.Play();
        }
        else
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
    }

    // 停止指定名称的音效
    public void Stop(string name)
    {
        if (soundDictionary.TryGetValue(name, out Sound sound))
        {
            sound.source.Stop();
        }
    }

    // 暂停指定名称的音效
    public void Pause(string name)
    {
        if (soundDictionary.TryGetValue(name, out Sound sound))
        {
            sound.source.Pause();
        }
    }

    // 继续播放指定名称的音效
    public void Resume(string name)
    {
        if (soundDictionary.TryGetValue(name, out Sound sound))
        {
            sound.source.UnPause();
        }
    }

    // 设置指定音效的音量
    public void SetVolume(string name, float volume)
    {
        if (soundDictionary.TryGetValue(name, out Sound sound))
        {
            sound.source.volume = Mathf.Clamp01(volume);
        }
    }

    // 检查指定音效是否正在播放
    public bool IsPlaying(string name)
    {
        if (soundDictionary.TryGetValue(name, out Sound sound))
        {
            return sound.source.isPlaying;
        }
        return false;
    }
}