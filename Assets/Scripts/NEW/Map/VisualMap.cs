using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VisualMap : MonoBehaviour
{
    //VIEW
    [SerializeField] private CameraFollower cm;


    [SerializeField] private Transform parentItems;
    [SerializeField] private Transform parentTiles;
    [SerializeField] private Transform parentEntities;

    [SerializeField] private GameObject prefabGround;
    [SerializeField] private GameObject prefabWall;

    private Dictionary<(int, int), GameObject> dictItems = new();


    public void CreateMap(new_Tile[,] map)
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                SetTile(x, y, map[y, x]._tt);
                SetItem(x, y, map[y, x].item);
            }
        }
    }
    private void SetTile(int x, int y, TilesTypes tt) => Instantiate(TilePrefab(tt), new Vector3(x, 0, y), Quaternion.identity, parentTiles);
    private GameObject SpawnItem(int x, int y, GameObject g) => Instantiate(g, new Vector3(x, 1, y), Quaternion.identity, parentItems);
    
    private void SetItem(int x, int y, Items i)
    {
        if (i != null)
            dictItems[(x, y)] = SpawnItem(x, y, i.gameObject);
    }
    
    
    /// <summary>
    /// OBSOLETE !!!!!! UTILISER CREATEMAP  
    /// Crée une map par rapport au tableau de Tiles passé en parametre
    /// </summary>
    /// <param name="m"></param>
    public void CreateMapTiles(TilesTypes[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                Instantiate(TilePrefab(m[i, j]), new Vector3(j, 0, -i), Quaternion.identity);
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
        Destroy(dictItems[(i, j)]);
        dictItems.Remove((i, j));
    }

    /// <summary>
    /// Instantie le joueur 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Player SetPlayer(Player p)
    {
        Player player = Instantiate(p, new Vector3(p.PosX, 1, p.PosY), Quaternion.identity, parentEntities);
        cm.SetFollower(player.gameObject);
        return player;
    }

    /// <summary>
    /// Instancie l'ennemi
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Entity SetEnemy(Entity e)
    {
        Entity enemy = Instantiate(e, new Vector3(e.PosX, 1, e.PosY), Quaternion.identity, parentEntities);
        return enemy;
    }


    /// <summary>
    /// Modifie le placement du joueur
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="direction"></param>
    public void UpdatePlayer(Player p)
    {
        //Debug.Log(p);
        //p.transform.position = new Vector3(p.PosX, 0.5f, p.PosY);
        MovePlayer(p);
        p.transform.rotation = Quaternion.Euler(new Vector3(0, GetDirection(p), 0));
        cm.UpdateFollower();
    }

    public void MovePlayer(Player p)
    {
        p.transform.DOMove(new Vector3(p.PosX, 0.5f, p.PosY), 0.5f)
            .OnComplete( () => Game_Manager.Instance.EndMovement());
    }


    public void UpdateItem(Items i, int x, int y)
    {
        if(i == null && dictItems.ContainsKey((x,y)))
        {
            DeleteItem(x, y);
        }
        if(i != null && !dictItems.ContainsKey((x,y)))
        {
            SetItem(x, y, i);
        }
    }

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
            _ => null,
        };
    }

    private float GetDirection(Player p)
    {
        return p.dir switch
        {
            Direction.South => 180f,
            Direction.West => 270,
            Direction.North => 0,
            Direction.East => 90,
            _ => 0
        };
    }
}
