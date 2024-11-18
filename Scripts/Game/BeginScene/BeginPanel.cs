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



        //ボタンがクリックされた時の処理
        btnBegin.clickEvent += () =>
        {
            //シーン切り替え
            SceneManager.LoadScene("GameScene");

        };
        btnSetting.clickEvent += () =>
        {
            //Setting画面を開く 
            SettingPanel.Instance.ShowMe();
            //ゲーム開始画面を隠す、誤作動を防ぐ
            HideMe();
        };
        btnQuit.clickEvent += () => 
        {
            //ゲームを閉じる
            Application.Quit();
        };
        btnRank.clickEvent += () => 
        {
            //ランキング画面を開く
            RankPanel.Instance.ShowMe();
            HideMe();
        
        };
    }

  
} 
