using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NController : MonoBehaviour
{
    TPece ParentTile;
    RaycastHit hit;
    bool chekedSurroundings;
    bool nothingUnder;
    Rigidbody rigidref;

    // Start is called before the first frame update
    void Start()
    {
        ParentTile = transform.parent.GetComponent<TPece>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ParentTile != null && ParentTile.isstopped && !chekedSurroundings)
        {
            Invoke("checkunder", .2f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.down);
    }

    void checkunder()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            rigidref = GetComponent<Rigidbody>();
            transform.parent = null;
            print(hit.transform);
            if (hit.transform.parent == transform.parent || hit.transform.tag == "Node" || hit.transform.tag == "Floor")
            {
                Debug.Log("Something");
                if(GetComponent<Rigidbody>() != null)
                {
                    rigidref.isKinematic = false;
                    rigidref.useGravity = true;
                }
                Destroy(this);
            }
            else if (hit.transform.tag == "Player")
            {

            }
            else
            {
                rigidref.constraints = RigidbodyConstraints.FreezeAll;
                Debug.Log("nothing");
            }
        }
        chekedSurroundings = true;
    }
}
