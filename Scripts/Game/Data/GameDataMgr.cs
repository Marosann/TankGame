using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���`��ǩ`�����饹
/// Singleton �ѥ��`��
/// </summary>
public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();

    public static GameDataMgr Instance { get => instance;  }

    //���S�ǩ`��
    public MusicData musicData;
    //��󥯥ǩ`��
    public RankList rankData;
    private GameDataMgr() {
        //�ǩ`�����ڻ�
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"Music") as MusicData;

        //����ƥ��`�����Ӥ���r�����S����ڻ����� 
        if (!musicData.notFirst)
        {
            musicData.notFirst = true;
            musicData.isOpenBK= true;
            musicData.isOpenSound= true;
            musicData.bkValue= 1;
            musicData.soundValue= 1;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music"); 
        }

        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList),"Rank") as RankList;   

         



    }

    //�ǩ`������ȱ�����API


    public void AddRankInfo(string name,int score,float time)
    {
        rankData.list.Add(new RankInfo(name,score,time));
        //�K���椨
        rankData.list.Sort((a,b)=>a.time < b.time ? -1 : 1);
        //10���򳬤����ǩ`��������
        for (int i = rankData.list.Count-1; i >= 10; i--)
        {
            rankData.list.RemoveAt(i);
        }
        //����
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }


    //���S���󥪥�����
    public void OpenOrCloseBKMusic(bool isOpen)
    {
        musicData.isOpenBK = isOpen;
        //���Ʃ`���Ϥ����S���󥪥�����
        BKMusic.Instance.ChangeOpen(isOpen);


        //�����Υǩ`���򱣴�
        PlayerPrefsDataMgr.Instance.SaveData(musicData,"Music");
    }
    //���������󥪥�����
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;

        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");

    }

    //���S�Ή仯�I��
    public void ChangeBKValue(float value)
    {
        musicData.bkValue = value;
        //���Ʃ`���Ϥ����S�仯����
        BKMusic.Instance.ChangeValue(value);
        //�����Υǩ`���򱣴�
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");

    }


    //�������Ή仯�I��
    public void ChangesoundValue(float value)
    {
        musicData.soundValue = value;

        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");

    }

}

