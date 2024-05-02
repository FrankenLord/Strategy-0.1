using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public Texture defaultTexture; // Текстура по умолчанию
    public Texture newTexture; // Новая текстура

    private Renderer rend;

    void Start()
    {
        // Получаем компонент Renderer у клетки
        rend = GetComponent<Renderer>();

        // Устанавливаем текстуру по умолчанию
        rend.material.mainTexture = defaultTexture;
    }

    void OnMouseDown()
    {
        // При нажатии на клетку меняем текстуру на новую
        rend.material.mainTexture = newTexture;
    }
}
