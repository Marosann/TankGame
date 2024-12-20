using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{

    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
   


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;



        //ボタンがクリックされた�rの�I尖
        btnBegin.clickEvent += () =>
        {
            //シ�`ン俳り紋え
            SceneManager.LoadScene("GameScene");

        };
        btnSetting.clickEvent += () =>
        {
            //Setting鮫中を�_く 
            SettingPanel.Instance.ShowMe();
            //ゲ�`ム�_兵鮫中を�Lす、�`恬�咾魴世�
            HideMe();
        };
        btnQuit.clickEvent += () => 
        {
            //ゲ�`ムを�]じる
            Application.Quit();
        };
        btnRank.clickEvent += () => 
        {
            //ランキング鮫中を�_く
            RankPanel.Instance.ShowMe();
            HideMe();
        
        };
    }

  
} 
