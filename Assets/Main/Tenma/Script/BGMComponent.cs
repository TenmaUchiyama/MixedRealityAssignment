using System.Collections;
using System.Collections.Generic;
using Oculus.VoiceSDK.UX;
using UnityEngine;

public class BGMComponent : MonoBehaviour
{

          
          
public List<string> audioClipPaths = new List<string>();
   public List<AudioClip> audioClips = new List<AudioClip>(); // 再生したいオーディオクリップのリスト
private List<AudioSource> audioSources = new List<AudioSource>();


    private bool isPlaying = false;

    public bool IsPlaying => isPlaying;


  void Start()
    {
         foreach (AudioClip audioClip in audioClips)
        {
            if (audioClip != null)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>(); // 新しいAudioSourceを追加
                audioSource.clip = audioClip; // AudioClipを設定
                audioSource.loop = true; // ループ設定
                audioSource.spatialBlend = 1.0f; // 3Dサウンド設定
                audioSources.Add(audioSource); // AudioSourceをリストに追加
                 audioSource.Play();
                 audioSource.Pause();
                Debug.Log($"AudioClip '{audioClip.name}' loaded and AudioSource created.");
            }
            else
            {
                Debug.LogError("AudioClip is null");
            }
        }
    }

    public void StartSound()
    {Debug.Log("<color=green>StartSound</color>");
        StartCoroutine(PlaySounds());
    }


     private IEnumerator PlaySounds()
    {

        
        foreach (AudioSource audioSource in audioSources)
        {
            // audioSource.Play();
            StartCoroutine(FadeIn(audioSource, 1.0f));
            yield return null; // 1フレーム待つことでメインスレッドの負荷を分散
        }

        isPlaying = true;
    }


public IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
{
 Debug.Log("<color=blue>FadeinSound</color>");
    audioSource.volume = 0;
    audioSource.Play();

    while (audioSource.volume < 1.0f)
    {
        audioSource.volume += Time.deltaTime / FadeTime;

        yield return null;
    }
}

    public void StopSound()
    {
        Debug.Log("<color=blue>StopSound</color>");
        foreach (AudioSource audioSource in audioSources)
        {
            // audioSource.Pause();
            StartCoroutine(FadeOut(audioSource, 1.0f));
    
        }
   
        isPlaying = false;
    }


public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
{
    float startVolume = audioSource.volume;

    while (audioSource.volume > 0)
    {
        audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

        yield return null;
    }

    audioSource.Pause();
    audioSource.volume = startVolume;
}
}
