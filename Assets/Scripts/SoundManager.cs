using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip ambientLoop;
    public AudioClip[] voiceEffects;

    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    // Singleton instance.
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusic(ambientLoop);
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        EffectsSource.pitch = randomPitch;
        EffectsSource.clip = clips[randomIndex];
        EffectsSource.Play();
    }



    //Hardcoded bad, but fast
    public void BioHazard ()
    {
        AudioClip[] biohaz = new AudioClip[2];
        biohaz[0] = voiceEffects[1];
        biohaz[1] = voiceEffects[2];
        //biohaz[2] = voiceEffects[3];
        RandomSoundEffect(biohaz);
    }

    public void MistakeMade ()
    {
        Play(voiceEffects[4]);
    }


    public void SwarmRemoved()
    {
        AudioClip[] biohaz = new AudioClip[2];
        biohaz[0] = voiceEffects[0];
        biohaz[1] = voiceEffects[5];
        RandomSoundEffect(biohaz);
    }


    public void Warning()
    {
        Play(voiceEffects[6]);
    }
}