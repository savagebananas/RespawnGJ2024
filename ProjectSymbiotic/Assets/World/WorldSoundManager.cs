using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SoundType
{
    Attack,
    Hurt,
    Chain,
    Seesaw,
    Movement,
    World,
    BGM
    //etc.
}
[RequireComponent(typeof(AudioSource)),ExecuteInEditMode]
public class WorldSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SoundList[] soundList;
    private static WorldSoundManager instance;
    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// SoundType+number of clip in soundtype!
    /// </summary>
    /// <param name="sound"></param>
    /// <param name="number"></param>
    /// <param name="volume"></param>
    public static void PlaySound(SoundType sound,int number, int volume)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip clip=clips[number];
        instance.audioSource.PlayOneShot(clip, (float)volume / 100.0f);
;    }
#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names=Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList,names.Length);
        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
#endif
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}
