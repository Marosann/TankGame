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



        //�ܥ��󤬥���å����줿�r�΄I��
        btnBegin.clickEvent += () =>
        {
            //���`���Ф��椨
            SceneManager.LoadScene("GameScene");

        };
        btnSetting.clickEvent += () =>
        {
            //Setting������_�� 
            SettingPanel.Instance.ShowMe();
            //���`���_ʼ������L�����`���Ӥ����
            HideMe();
        };
        btnQuit.clickEvent += () => 
        {
            //���`����]����
            Application.Quit();
        };
        btnRank.clickEvent += () => 
        {
            //��󥭥󥰻�����_��
            RankPanel.Instance.ShowMe();
            HideMe();
        
        };
    }

  
} 
