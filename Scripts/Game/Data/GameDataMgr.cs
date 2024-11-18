using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ゲームデータクラス
/// Singleton パターン
/// </summary>
public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();

    public static GameDataMgr Instance { get => instance;  }

    //音楽データ
    public MusicData musicData;
    //ランクデータ
    public RankList rankData;
    private GameDataMgr() {
        //データ初期化
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"Music") as MusicData;

        //初めてゲーム起動する時、音楽を初期化する 
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

    //データ変更と保存用API


    public void AddRankInfo(string name,int score,float time)
    {
        rankData.list.Add(new RankInfo(name,score,time));
        //並び替え
        rankData.list.Sort((a,b)=>a.time < b.time ? -1 : 1);
        //10個を超えたデータを削除
        for (int i = rankData.list.Count-1; i >= 10; i--)
        {
            rankData.list.RemoveAt(i);
        }
        //保存
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }


    //音楽オンオフ制御
    public void OpenOrCloseBKMusic(bool isOpen)
    {
        musicData.isOpenBK = isOpen;
        //ステージ上の音楽オンオフ制御
        BKMusic.Instance.ChangeOpen(isOpen);


        //変更後のデータを保存
        PlayerPrefsDataMgr.Instance.SaveData(musicData,"Music");
    }
    //効果音オンオフ制御
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;

        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");

    }

    //音楽の変化処理
    public void ChangeBKValue(float value)
    {
        musicData.bkValue = value;
        //ステージ上の音楽変化制御
        BKMusic.Instance.ChangeValue(value);
        //変更後のデータを保存
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");

    }


    //効果音の変化処理
    public void ChangesoundValue(float value)
    {
        musicData.soundValue = value;

        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");

    }

}

