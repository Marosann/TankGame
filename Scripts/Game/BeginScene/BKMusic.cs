using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class BKMusic : MonoBehaviour
{

    private static BKMusic instance;

    public static BKMusic Instance => instance;

    private AudioSource audioSource;
     
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;  
        //�������Ƥ��륪�֥������Ȥ����S���`����ȡ��
        audioSource= this.GetComponent<AudioSource>();
        ChangeValue(GameDataMgr.Instance.musicData.bkValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenBK);



    }



    public void  ChangeValue(float value)
    {
        audioSource.volume= value;  
    }

    public void ChangeOpen(bool isOpen)
    {
        audioSource.mute = !isOpen;
    }




}
