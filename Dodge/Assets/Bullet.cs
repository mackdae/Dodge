using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; //ź�� �ӷ�
    private Rigidbody bulletRigidbody; //�̵��� ����� ������ٵ� ������Ʈ
    void Start()
    {
        // ���� ������Ʈ���� Rigidbody������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed; //���û��� 0,0,1
        // ������ٵ��� �ӵ� = �չ��� * �ӷ�
        // transform�� ����, Transform�� Ÿ��
        // bulletRigidbody.velocity = new Vector3(0, 0, 1) * speed; //�۷ι����� 0,0,1

        Destroy(gameObject, 3f); //3�� �� �ı�
        // gameObject �ڽ��� ������Ʈ�� ����Ű�� ����
    }
    private void OnTriggerEnter(Collider otherrr) //������ ��ȯ���� �޼ҵ�(�Ű�����Ÿ�� ������)
        // OnCollisionEnter(Collision collision) �浹 ����
        // OnTriggerEnter(Collider other) �浹�� ��ü�� ����
    {
        if(otherrr.tag=="Player") //�ν����Ϳ��� �÷��̾� ������Ʈ�� �����ߴ� �±�
        {// �浹������Ʈ�� Player �±׸� ���� ��� PlayerController ������Ʈ ��������
            PlayerController playerController = otherrr.GetComponent<PlayerController>();
            if (playerController !=null)
            {// PlayerController ������Ʈ�� �ִ� ��� PlayerController�� Die() �޼ҵ� ����
                playerController.Die();
            }// ���� ��츦 ����� if��
        }
    }
}