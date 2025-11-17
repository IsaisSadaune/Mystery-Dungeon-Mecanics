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


    /// <summary>
    /// Crée une map par rapport au tableau de Tiles passé en parametre
    /// </summary>
    /// <param name="m"></param>
    public void CreateMap(TilesTypes[,] m)
    {
        for(int i = 0;i<m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                Instantiate(TilePrefab(m[i, j]), new Vector3(j, 0, -i), Quaternion.identity);
            }
        }
    }

    /// <summary>
    /// Crée une map des objets par rapport au tableau d'objets passé en parametre
    /// </summary>
    /// <param name="m"></param>
    public void CreateItemMap(Items[,] m)
    {
        for(int i = 0 ; i<m.GetLength(0) ; i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                if (m[i,j] != null) 
                { 
                    dict[(i,j)] = Instantiate(m[i,j].gameObject, new Vector3(j, 1, -i), Quaternion.identity);
                    Debug.Log("spawn");
                }
            }
        }
    }

    /// <summary>
    /// Supprime un objet du dict d'objets visuels
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    public void DeleteItem(int i, int j)
    {
        Destroy(dict[(i,j)]);
        dict.Remove((i, j));
    }

    /// <summary>
    /// Ajoute un objet dans le dict d'objets visuels
    /// </summary>
    /// <param name="g"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    public void AddItem(GameObject g, int i, int j)
    {
        dict[(i,j)] = Instantiate(g, new Vector3(j,1,-i), Quaternion.identity);
    }


    /// <summary>
    /// Instantie le joueur 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetPlayer(int x, int y)
    {
        player = Instantiate(prefabPlayer, new Vector3(x, 1, -y), Quaternion.identity);
    }

    /// <summary>
    /// Instancie l'ennemi
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetEnemy(int x, int y)
    {
        enemy = Instantiate(prefabEnemy, new Vector3(x, 1, -y), Quaternion.identity);
    }

    /// <summary>
    /// Modifie le placement du joueur
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="direction"></param>
    public void UpdatePlayer(int x, int y, int direction)
    { 
        player.transform.position = new Vector3(y, 1, -x);
        player.transform.rotation = Quaternion.Euler(new Vector3(0, direction, 0));
    }

    public void AddWings() => PlayerWings.SetActive(true); 
    public void RemoveWings() => PlayerWings.SetActive(false); 


    /// <summary>
    /// Renvoie le prefab associé au TileType associé
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
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
