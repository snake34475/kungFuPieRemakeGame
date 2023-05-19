using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager Instance;  //单例模式

    [SerializeField] private AudioSource _musicSource, _effectsSource; //声明一个可遍历的，一个音乐源，一个效果源
    //强制只保持一个
    private void Awake()
    {
        //如果没有管理器，那么我就是管理器
        if (Instance == null)
        {
            Instance = this;
            //并且切换场景的时候禁止删除
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //如果有就删除我
            Destroy(gameObject);
        }
    }
    //提供一个方法，控制传入的音效播放
    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }
}
