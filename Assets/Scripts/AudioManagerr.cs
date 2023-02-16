using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManagerr : MonoBehaviour
{
    public Sonido[] sonidos;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sonido s in sonidos)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

   public void Play (string name)
    {
        Sonido s = Array.Find(sonidos, sonido => sonido.name == name);
        s.source.Play();
    }
}
