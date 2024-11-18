using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BulletObj : MonoBehaviour
{

    public float moveSpeed = 50;

    public TankBaseObj fatherTank;

    public GameObject eftObj;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward* moveSpeed*Time.deltaTime);
    }

    //�h������������˵����ä��r���⤷�����`��ꇆӤΥ�˥åȤ˵����ä��r��������I��
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Cube") ||
            other.CompareTag("Player")&&fatherTank.CompareTag("Enemy")||
            other.CompareTag("Enemy")&&fatherTank.CompareTag("Player"))
        {
            Destroy(this.gameObject);

            //����`�����ܤ���I��
            TankBaseObj tankObj = other.gameObject.GetComponent<TankBaseObj>();
            if (tankObj != null)
            {
                tankObj.Wound(fatherTank);

            }
            
            //�h���������ä��r�˥��ե���������
            if (eftObj!=null)
            {
                GameObject obj = Instantiate(eftObj, this.transform.position, this.transform.rotation);
                audioSource= obj.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
                audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }
           
        } 



    }

    public void SetFather(TankBaseObj obj)
    {
        fatherTank = obj;
    }

}
