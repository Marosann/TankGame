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
        //���S�Ή仯�I��
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeBKValue(value);

        //�������Ή仯�I��
        sliderSe.changeValue += (value) => GameDataMgr.Instance.ChangesoundValue(value);
        //���S���󥪥�����
        toggleMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        //���������󥪥�����
        toggleSe.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);


        btnClose.clickEvent += () =>
        {   
            //�ܥ�����L��
            HideMe();

            //�񤤤륷�`����ж�
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
        //���S�ǩ`������˷�ӳ����
        MusicData data = GameDataMgr.Instance.musicData;

        sliderMusic.nowValue = data.bkValue;
        sliderSe.nowValue = data.soundValue;
        toggleMusic.isSel = data.isOpenBK;
        toggleSe.isSel = data.isOpenSound;
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //�O��������ʾ���뤿�Ӥˡ��������
        UpdatePanelInfo();
    }
}
