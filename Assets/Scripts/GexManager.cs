using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
	public GameObject objectPrefab;
	 
	public int xSize, ySize;
    private Vector3[] vertices;
	private Vector3[] vertices2;
	private Mesh mesh;

	[ContextMenu("Generate Grid")]
	private void Generate()
    {
		while (transform.childCount > 0)
		{
			DestroyImmediate(transform.GetChild(0).gameObject);
		}
		vertices = new Vector3[(xSize + 1) * (ySize + 1)];
		vertices2 = new Vector3[(xSize + 1) * (ySize + 1)];
		for (int i = 0, y = 0; y <= ySize; y += 2)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x * 0.866025404f , 0, y * 3f / 4f);
                if (objectPrefab != null)
                {
                    //Instantiate(objectPrefab, vertices[i], Quaternion.identity, transform);
                    Quaternion rotation = Quaternion.Euler(90, 0, 0);
                    GameObject instantiatedObject = Instantiate(objectPrefab, vertices[i], rotation, transform);
                    instantiatedObject.transform.localScale = new Vector3(50f, 50f, 50f); // Изменяем масштаб объекта
                }
            }
        }
		for (int i = 0, y = 1; y <= ySize; y += 2)
		{
			for (int x = 0; x <= xSize+1; x++, i++)
			{
				vertices2[i] = new Vector3((x-0.5f) * 0.866025404f, 0, y * 3f / 4f);
				if (objectPrefab != null)
				{
					//Instantiate(objectPrefab, vertices[i], Quaternion.identity, transform);
					Quaternion rotation = Quaternion.Euler(90, 0, 0);
					GameObject instantiatedObject = Instantiate(objectPrefab, vertices2[i], rotation, transform);
					instantiatedObject.transform.localScale = new Vector3(50f, 50f, 50f); // Изменяем масштаб объекта
				}
			}
		}
	}
    [ContextMenu("Clear Gizmos")]
	private void ClearGizmos()
	{
		vertices = null;
	}

	private void OnDrawGizmos()
	{
		if (vertices == null)
		{
			return;
		}
		Gizmos.color = Color.black;
		for (int i = 0; i < vertices.Length; i++)
		{
			Gizmos.DrawSphere(vertices[i], 0.1f);
		}
		if (vertices2 == null)
		{
			return;
		}
		Gizmos.color = Color.black;
		for (int i = 0; i < vertices2.Length; i++)
		{
			Gizmos.DrawSphere(vertices2[i], 0.1f);
		}
	}
}
