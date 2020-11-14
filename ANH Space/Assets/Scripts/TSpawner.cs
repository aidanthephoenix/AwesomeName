using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSpawner : MonoBehaviour
{
    public List<GameObject> TilesPossible = new List<GameObject>();
    public GameObject ActiveTile;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Spawn()
    {
            GameObject gg = Instantiate(TilesPossible[Random.Range(0, TilesPossible.Count)], transform.position, Quaternion.identity);
            ActiveTile = gg;
    }
}
