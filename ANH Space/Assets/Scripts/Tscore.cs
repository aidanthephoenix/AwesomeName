using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tscore : MonoBehaviour
{
    public int AmountToScore;
    public LayerMask TileLayer;
    public ScoreManager Smanager;
    public RaycastHit[] tt;

    // Start is called before the first frame update
    void Start()
    {
        Smanager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        tt = Physics.RaycastAll(transform.position, transform.forward, 10, TileLayer);
        if(tt.Length == AmountToScore)
        {
            Debug.Log("gottem");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
