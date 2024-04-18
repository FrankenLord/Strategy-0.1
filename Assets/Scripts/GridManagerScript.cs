using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 position = new Vector3(x * (cellSize + offset), 0, y * (cellSize + offset));

                // Создаем клетку из префаба и делаем ее дочерним объектом созданного GameObject "Grid"
                GameObject cell = Instantiate(cellPrefab, position, Quaternion.identity, gridParent.transform);
                cell.name = "Cell_" + x + "_" + y;
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
