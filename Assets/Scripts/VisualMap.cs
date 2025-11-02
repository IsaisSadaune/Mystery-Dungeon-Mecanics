using System.Collections.Generic;
using UnityEngine;

public class VisualMap : MonoBehaviour
{
    //VIEW

    [SerializeField] private GameObject prefabGround;
    [SerializeField] private GameObject prefabWall;
    [SerializeField] private GameObject prefabWater;

    [SerializeField] private GameObject prefabPlayer;
    [SerializeField] private GameObject prefabEnemy;

    GameObject player;
    GameObject enemy;
    private GameObject PlayerWings => player.transform.GetChild(0).gameObject;

    private Dictionary<(int, int), GameObject> dict = new();


    public void CreateMap(TilesTypes[,] m)
    {
        for(int i = 0;i<m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                Instantiate(TilePrefab(m[i, j]), new Vector3(j, 0, i), Quaternion.identity);
            }
        }
    }
    public void CreateItemMap(Items[,] m)
    {
        for(int i = 0;i<m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                if (m[i,j] != null) { 
                    dict[(i,j)] = Instantiate(m[i,j].model, new Vector3(j, 1, i), Quaternion.identity);
                    Debug.Log("spawn");
                }
            }
        }
    }

    public void DeleteItem(int x, int y)
    {
        Destroy(dict[(x,y)]);
        dict.Remove((x, y));
    }

    public void SetPlayer(int x, int y)
    {
        player = Instantiate(prefabPlayer, new Vector3(x, 1, y), Quaternion.identity);
    }

    public void SetEnemy(int x, int y)
    {
        enemy = Instantiate(prefabEnemy, new Vector3(x, 1, y), Quaternion.identity);
    }

    public void UpdatePlayer(int x, int y, int direction)
    { 
        player.transform.position = new Vector3(x, 1, y);
        player.transform.rotation = Quaternion.Euler(new Vector3(0, direction, 0));
    }

    public void AddWings() => PlayerWings.SetActive(true); 
    public void RemoveWings() => PlayerWings.SetActive(false); 


    private GameObject TilePrefab(TilesTypes t)
    {
        return t switch
        {
            TilesTypes.Ground => prefabGround,
            TilesTypes.Wall => prefabWall,
            TilesTypes.Water => prefabWater,
            _ => null,
        };
    }
}
