using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridManagerScript : MonoBehaviour
{
    public int gridSizeX;
    public int gridSizeY;
    public float cellSize;
    public float offset;

    public GameObject cellPrefab; // Префаб клетки с компонентом Renderer
    private GameObject gridParent;

    [ContextMenu("Generate Grid")]
    public void GenerateGrid()
    {
        // Создаем новый пустой GameObject для хранения клеток
        GameObject gridParent = new GameObject("Grid");
        float a;
        a = cellSize / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                if ((y + 1) % 2 == 0)
                {
                    Vector3 position = new Vector3((float)(x * cellSize * Math.Sqrt(3) + (cellSize * Math.Sqrt(3) / 2)), 0, (float)(y / 2 * 1.5 * cellSize));
                    GameObject cell = Instantiate(cellPrefab, position, Quaternion.identity, gridParent.transform);
                    cell.name = "Cell_" + x + "_" + y;
                }
                else
                {
                    Vector3 position = new Vector3((float)(x * cellSize * Math.Sqrt(3)), 0, (float)(y * cellSize));
                    GameObject cell = Instantiate(cellPrefab, position, Quaternion.identity, gridParent.transform);
                    cell.name = "Cell_" + x + "_" + y;
                }
                //Vector3 position = new Vector3(x * (cellSize + offset), 0, y * (cellSize + offset));

                // Создаем клетку из префаба и делаем ее дочерним объектом созданного GameObject "Grid"
                //GameObject cell = Instantiate(cellPrefab, position, Quaternion.identity, gridParent.transform);
                //cell.name = "Cell_" + x + "_" + y;
                // Дополнительные действия, если необходимо
            }
        }
    }
    [ContextMenu("Clear Grid")]
    public void ClearGrid()
    {
        if (gridParent != null)
        {
            // Удаляем все дочерние объекты (клетки) из родительского объекта (сетки)
            foreach (Transform child in gridParent.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
