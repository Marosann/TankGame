using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    public int atk;
    public int def;
    public int maxHp;
    public int hp;
   //�h��
    public Transform tankHead;


    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    //���󥯤��������r�ˡ��ץ쥤���륨�ե�����
    public GameObject destroyEff;



    public abstract void Fire();
    
    public virtual void Wound(TankBaseObj tank)
    {

        int dmg = tank.atk - def;
        if (dmg <= 0) { return; }
        if (hp - dmg > 0)
        {
            hp -= dmg;
        }
        else
        {
            hp = 0;
            Dead();
        }

    }
    /// <summary>
    ///��Hp��0���¤ˤʤä����ϡ���������
    /// </summary>
    public virtual void Dead()
    {
        //���Ʃ`���Ϥˤ��륪�֥������Ȥ�remove
        Destroy(this.gameObject);
        //�������ե����Ȥ��ʾ
        if(destroyEff!=null) 
        {
            GameObject effObj  = Instantiate(destroyEff,this.transform.position,this.transform.rotation); 

            //���ե����Ȥ˸�������SE��ȡ��
            AudioSource audioScource= effObj.GetComponent<AudioSource>();
            //�O������ˤ������
            audioScource.volume = GameDataMgr.Instance.musicData.soundValue;

            audioScource.mute = GameDataMgr.Instance.musicData.isOpenSound;

            audioScource.Play();
        }
    }








}
