using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EventReference buy;

    public float speed = 3f;

    private Transform target;
    private int wayPoint = 1;
    private MovementBehavior _mvb;

    private List<int> WishList = new List<int>();
    

    /*
     * wishlist
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        AddWishlistItem();
        Debug.Log(WishList[0]);


        target = PathBehavior.Waypoints[2];
        _mvb = GetComponent<MovementBehavior>();
        Vector3 dir = target.position - transform.position;
        //Debug.Log(dir);
        Quaternion rotation = Quaternion.LookRotation(dir);
        
        //Debug.Log(rotation);

        // Aplica la rotación al objeto
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
            
        }
    }

    void GetNextWaypoint()
    {
        if (wayPoint >= PathBehavior.Waypoints.Length - 1)
        {
            Destroy(this.gameObject);
            return;
        }

        wayPoint++;
        target = PathBehavior.Waypoints[wayPoint];
        Vector3 dir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
    }
    void OnTriggerEnter(Collider other)
    {

        if(other.TryGetComponent<AAA>(out AAA Vending_)){
            if (WishList[0] == Vending_.getItemID())
            {
                Vending_.Buy();
                AudioManager.instance.PlayOneShot(buy, this.transform.position);
                Debug.Log("TE HAS SALTADO EL AUDIO");
            }
            else
            {
                Debug.Log("CYKA BLYAAAAAAAAAAAAAAAAT");
            }
        }
    }

    void AddWishlistItem()
    {
        WishList.Add(Random.Range(1, 4));
    }
}
