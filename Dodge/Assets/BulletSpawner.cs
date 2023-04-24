using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ź���� ���� ������
    public float spawnRateMin = 0.5f; //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�
    private Transform target; // �߻� ���
    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn; //�ֱ� ���� �������� ���� �ð�
    //�ۺ����� �۾� �� ��������Ʈ�� ��ȯ

    void Start()
    {
        timeAfterSpawn = 0f; // ������ �����ð� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // �����ֱ� ��������

        target = FindObjectOfType<PlayerController>().transform;
        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� �߻������� ����
        // �� �� ����
        //PlayerController playerController = FindObjectOfType<PlayerController>();
        //target = playerController.transform;
        
        // FindObjectOfType() �޼ҵ�� ó������� Ŀ�� �ѵι� ����Ǵ� �޼ҵ忡�� ���
        // FindObjectsOfType() �� �ش�Ÿ�� ������Ʈ�� ��� ã�Ƽ� �迭�� ��ȯ
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime; // timeAfterSpawn ����
        if (timeAfterSpawn >= spawnRate) // �����ð��� �����ֱ⺸�� ũ�ų� ������
        {
            timeAfterSpawn = 0f; // �ð� ����
            GameObject bullet //bulletPrefab�� ��������
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // transform.position ��ġ�� transform.rotation ȸ������ ����
            // Instantiate �ν��Ͻ�ȭ, ó����� ŭ
            bullet.transform.LookAt(target);
            // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            // ���� ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
        }
    }
}