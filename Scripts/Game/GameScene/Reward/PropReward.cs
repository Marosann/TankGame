using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_PropType
{
    Atk,
    Def,
    MaxHP,
    HP,
}


public class PropReward : MonoBehaviour
{
    public int atkUpValue = 2;
    public int defUpValue = 2;
    public int hpUpValue = 30;
    public int maxHpUpValue = 10;

    public GameObject getEff;
    public E_PropType prop = E_PropType.Atk;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerObj player = other.GetComponent<PlayerObj>();

            switch (prop) 
            {
                
                case E_PropType.Atk:
                    player.atk += atkUpValue;
                    break;
                    case E_PropType.Def:
                    player.def += defUpValue; break;
                    case E_PropType.MaxHP:
                    int beforeMaxHP = player.maxHp;
                    player.maxHp += maxHpUpValue;
                    GamePanel.Instance.UpdateMaxHP(player.maxHp,beforeMaxHP);
                    break;
                    case E_PropType.HP:
                    if(player.hp + hpUpValue > player.maxHp) { player.hp = player.maxHp;}
                    else { player.hp += hpUpValue; }
                    GamePanel.Instance.UpdateHP(player.maxHp,player.hp);
                    break;  


            }
            //«@µÃ¤¹¤ë•r¤Ë¥¨¥Õ¥§¥¯¥ÈÔÙÉú
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);

            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;


            Destroy(this.gameObject);
        }


    }




}
