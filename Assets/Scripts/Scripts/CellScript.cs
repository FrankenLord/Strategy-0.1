using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public Texture defaultTexture; // �������� �� ���������
    public Texture newTexture; // ����� ��������

    private Renderer rend;

    void Start()
    {
        // �������� ��������� Renderer � ������
        rend = GetComponent<Renderer>();

        // ������������� �������� �� ���������
        rend.material.mainTexture = defaultTexture;
    }

    void OnMouseDown()
    {
        // ��� ������� �� ������ ������ �������� �� �����
        rend.material.mainTexture = newTexture;
    }
}
