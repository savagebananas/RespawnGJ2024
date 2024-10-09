using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
public class WorldSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip[] soundList;
    private static WorldSoundManager instance;
    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;
    }
    public static void PlaySound(SoundType sound, int volume)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound],(float)volume/100.0f);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
