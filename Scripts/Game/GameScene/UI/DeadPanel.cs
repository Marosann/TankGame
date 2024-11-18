using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPanel : BasePanel<DeadPanel>
{


    public CustomGUIButton btnAgain;
    public CustomGUIButton btnCancel;

    // Start is called before the first frame update
    void Start()
    {
        HideMe();

        btnAgain.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");

        };

        btnCancel.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };
        
    }


}
