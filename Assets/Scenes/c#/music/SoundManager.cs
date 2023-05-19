using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager Instance;  //����ģʽ

    [SerializeField] private AudioSource _musicSource, _effectsSource; //����һ���ɱ����ģ�һ������Դ��һ��Ч��Դ
    //ǿ��ֻ����һ��
    private void Awake()
    {
        //���û�й���������ô�Ҿ��ǹ�����
        if (Instance == null)
        {
            Instance = this;
            //�����л�������ʱ���ֹɾ��
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //����о�ɾ����
            Destroy(gameObject);
        }
    }
    //�ṩһ�����������ƴ������Ч����
    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }
}
