using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using NaughtyAttributes;

public class TPece : MonoBehaviour
{
    public KeyCode TestPress;
    public KeyCode TestPress2;
    public KeyCode TestPress3;

    Transform PosRef;
    Rigidbody Rigg;
    public bool isstopped;
    TSpawner SpawnRef;
    public float fallspeed;
    public float resetpoint;
    [Space]
    public float widthRight;
    public float widthLeft;
    public float heighttop;
    public float heightbottom;
    public float checkDistRight;
    public float checkDistLeft;
    public float checkDistDown;
    [Space]
    public List<GameObject> children = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PosRef = GetComponent<Transform>();
        Rigg = GetComponent<Rigidbody>();
        SpawnRef = FindObjectOfType<TSpawner>();
        
        if(Rigg.velocity == Vector3.zero)
        {
            Rigg.velocity = -Vector3.up;
        }

        Rigg.AddRelativeForce(new Vector3(0, -fallspeed, 0), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x != resetpoint)
        {
            transform.position = new Vector3(resetpoint, transform.position.y, transform.position.z);
        }

        if(Mathf.Round(transform.eulerAngles.z) == 0)
        {

            checkDistRight = widthRight;
            checkDistLeft = widthLeft;       
        }
        else if (Mathf.Round(transform.eulerAngles.z) == 270)
        {
            checkDistRight = heighttop;
            checkDistLeft = heightbottom;
        }
        else if (Mathf.Round(transform.eulerAngles.z) == 180)
        {
            checkDistRight = widthLeft;
            checkDistLeft = widthRight;
        }
        else if (Mathf.Round(transform.eulerAngles.z) == 90)
        {
            checkDistRight = heightbottom;
            checkDistLeft = heighttop;
        }
       
        if(transform.localRotation.z >= 360)
        {
            PosRef.eulerAngles = new Vector3(0, 0, PosRef.eulerAngles.z - 360);
        }
        else if(transform.localRotation.z <= -360)
        {
            PosRef.eulerAngles = new Vector3(0, 0, PosRef.eulerAngles.z + 360);
        }

        if ( Rigg != null && Rigg.velocity.magnitude <= .1 && isstopped == false)
        {
            //Rigg.useGravity = true;
            //Rigg.collisionDetectionMode = CollisionDetectionMode.Discrete;
            Destroy(Rigg);
            isstopped = true;

            for (int i = 0; i < children.Count; i++)
            {
                Rigidbody rr = children[i].AddComponent<Rigidbody>();
                rr.isKinematic = true;
                rr.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                                 RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }
            if(SpawnRef != null)
            {
                SpawnRef.Spawn();
            }
        }
    }

    [Button("RotateClockwise")]
    public void RotateClockwise()
    {     
        if(isstopped == false)
        {
            PosRef.eulerAngles = new Vector3(0, 0, PosRef.eulerAngles.z + 90);
        }
    }

    [Button("RotateCounterclockwise")]
    public void RotateCounterclockwise()
    {
        if (isstopped == false)
        {
            PosRef.eulerAngles = new Vector3(0, 0, PosRef.eulerAngles.z - 90);
        }
    }

    [Button("MoveRight")]
    public void MoveRight()
    {
        if (isstopped == false)
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position + (Vector3.right * checkDistRight), Vector3.right,Color.red,10f);
            if(Physics.Raycast(transform.position + (Vector3.right * checkDistRight), Vector3.right, out hit, 1))
            {
                Debug.Log("Hit something");
            }
            else
            {
                resetpoint ++;
                PosRef.position = new Vector3(PosRef.position.x + 1, PosRef.position.y, PosRef.position.z);
            }
        }
    }

    [Button("MoveLeft")]
    public void MoveLeft()
    {
        if (isstopped == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position - (Vector3.right * checkDistLeft), -Vector3.right, out hit, 1))
            {
                Debug.Log("Hit something");
            }
            else
            {
                resetpoint--;
                PosRef.position = new Vector3(PosRef.position.x - 1, PosRef.position.y, PosRef.position.z);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.right));
    }
}
