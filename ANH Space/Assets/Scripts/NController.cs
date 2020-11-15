using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NController : MonoBehaviour
{
    TPece ParentTile;
    RaycastHit hit;
    bool chekedsurroundings;

    // Start is called before the first frame update
    void Start()
    {
        ParentTile = transform.parent.GetComponent<TPece>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ParentTile.isstopped && !chekedsurroundings)
        {

        }
    }


}
