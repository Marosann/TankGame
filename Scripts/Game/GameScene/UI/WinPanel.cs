using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel :BasePanel<WinPanel>
{

    public CustomGUIInput inputName;
    public CustomGUIButton sureBtn;

    private void Start()
    {
        HideMe();
        sureBtn.clickEvent += () =>
        {
            Time.timeScale = 1;
            GameDataMgr.Instance.AddRankInfo(inputName.content.text,GamePanel.Instance.nowScore, GamePanel.Instance.nowTime);
            SceneManager.LoadScene("BeginScene");
        };

    }

}
