using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void SetSoundEffectVolume(float value)
    {
        audioMixer.SetFloat("SoundEffectVolume", value);
    }
}
