using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            EndGame();

        }
    }

    public void EndGame()
    {
        WinPanel.Instance.ShowMe();
    }


}
