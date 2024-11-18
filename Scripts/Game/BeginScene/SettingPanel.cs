using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{

    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSe;

    public CustomGUIToggle toggleMusic;
    public CustomGUIToggle toggleSe;

    public CustomGUIButton btnClose; 

    void Start()
    {
        //音楽の変化処理
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeBKValue(value);

        //効果音の変化処理
        sliderSe.changeValue += (value) => GameDataMgr.Instance.ChangesoundValue(value);
        //音楽オンオフ制御
        toggleMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        //効果音オンオフ制御
        toggleSe.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);


        btnClose.clickEvent += () =>
        {   
            //ボタンを隠す
            HideMe();

            //今いるシーンを判断
            if (SceneManager.GetActiveScene().name == "BeginScene") 
            {
                BeginPanel.Instance.ShowMe();

            }

            
        }; 


        HideMe();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
    public void UpdatePanelInfo()
    {
        //音楽データを画面に反映する
        MusicData data = GameDataMgr.Instance.musicData;

        sliderMusic.nowValue = data.bkValue;
        sliderSe.nowValue = data.soundValue;
        toggleMusic.isSel = data.isOpenBK;
        toggleSe.isSel = data.isOpenSound;
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //設定画面を表示するたびに、情報を更新
        UpdatePanelInfo();
    }
}
