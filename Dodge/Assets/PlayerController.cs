using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; //�̵��� ����� Rigidbody Ÿ���� ���� (������Ʈ)
    public float speed = 10f; //�ӷ� ����
    // �����ڸ� public���� �����ϸ� ����Ƽ ������ �� �ʵ尪�� ����
    // [SerializeField] private Rigidbody playerRigidbody;
    // serialize: ����ȭ // [SerializeField]: private�� �ν����Ϳ��� ���� �����ϰ� ����ȭ�ϴ� ���
    void Start() 
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input Ŭ���� GetKey �޼ҵ� KeyCode ���������
        // Input.GetKey�� Ű������ �ĺ���(�ƽ�Ű�ڵ�)�� KeyCode Ÿ������ �޾Ƽ� bool Ÿ������ ��ȯ
        // bool Input.GetKey(KeyCode key);
        //if (Input.GetKey(KeyCode.UpArrow) == true) // �� ����Ű �Է� ������ z���� �� �߰�
        //{ playerRigidbody.AddForce(0f, 0f, speed); }
        //if (Input.GetKey(KeyCode.DownArrow) == true) // �Ʒ� ����Ű �Է� ������ -z���� �� �߰�
        //{ playerRigidbody.AddForce(0f, 0f, -speed); }
        //if (Input.GetKey(KeyCode.RightArrow) == true) // ���� ����Ű �Է� ������ x���� �� �߰�
        //{ playerRigidbody.AddForce(speed, 0f, 0f); }
        //if (Input.GetKey(KeyCode.LeftArrow) == true) // ���� ����Ű �Է� ������ -x���� �� �߰�
        //{ playerRigidbody.AddForce(-speed, 0f, 0f); }
        //if (Input.GetKey(KeyCode.Space) == true) // ��������
        //{ playerRigidbody.AddForce(0f, speed, 0f); }

        // ���۰� �����ϱ�
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        // ������ ������ �Է°��� ���� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        // �Է°��� �ӷ��� ����� ���� �̵��ӵ� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // Vector3 �ӵ��� (xSpeed, 0, zSeed)�� ����
        playerRigidbody.velocity = newVelocity;
        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
    }
    public void Die()
    {
        gameObject.SetActive(false); //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        //gameObject�� ����Ƽ���� �����س��� GameObjectŸ���� ����(����� �ڵ����� ������Ƽ(�޼ҵ�))
    }
}
