using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public float nodeSize = 0.64f;
    public Vector2 mapSize = new Vector2Int(1, 1);

    private void Awake()
    {
        CraetGrid();

        Object[] elements = Resources.LoadAll("MapElement/Prefabs/");
        elementMap = new GameObject[elements.Length];
        for (int i = 0; i < elements.Length; i++)
        {
            GameObject newElement = elements[i] as GameObject;
            elementMap[i] = newElement;
        }
    }

    // Use this for initialization
    private void Start()
    {
        CreateMap();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void CraetGrid()
    {
        GridX = Mathf.RoundToInt(mapSize.x);
        GridY = Mathf.RoundToInt(mapSize.y);

        Grid = new MapNode[GridX, GridY];

        for (int x = 0; x < GridX; x++)
        {
            for (int y = 0; y < GridY; y++)
            {
                MapNode node = new MapNode()
                {
                    position = new Vector3(nodeSize * (x + 0.5f) - nodeSize * (GridX * 0.5f),
                                           nodeSize * (y + 0.5f) - nodeSize * (GridY * 0.5f),
                                           this.transform.position.z)
                };
                Grid[x, y] = node;
            }
        }
    }

    private void CreateMap()
    {
        for (int i = 0; i < GridY; i += 2)
        {
            int randX = Random.Range(0, GridX);
            Vector3 pos = Grid[randX, i].position;

            int randIndex = Random.Range(0, elementMap.Length);
            GameObject newelement = GameObject.Instantiate(elementMap[randIndex], this.transform);
            newelement.transform.position = pos;
        }
    }

    private void OnDrawGizmos()
    {
        CraetGrid();

        Gizmos.color = Color.gray;
        if (Grid != null)
        {
            foreach (MapNode n in Grid)
            {
                Gizmos.DrawWireCube(n.position, Vector3.one * nodeSize);
            }
        }
    }

    private int GridX;
    private int GridY;
    private MapNode[,] Grid;
    private GameObject[] elementMap;

    public struct MapNode
    {
        public Vector3 position;
    }
}