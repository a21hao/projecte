using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EventReference buySound;
    [SerializeField] private GameObject wishListGO;
    private List<Vector3> positions;

    public float speed = 3f;

    private Vector3 target;
    private int wayPoint = 0;
    private MovementBehavior _mvb;
    private Wishlist wishList;
    private int iditemToWish;
    private ObjectivesAndStats objAndStats;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        target = positions[0];
        
        _mvb = GetComponent<MovementBehavior>();
        Vector3 dir = target - transform.position;
        //Debug.Log(dir);
        Quaternion rotation = Quaternion.LookRotation(dir);
        wishList = GameObject.Find("GameManager/WishList").GetComponent<Wishlist>();
        iditemToWish = wishList.ItemToWishId();

        
        //Debug.Log(rotation);

        // Aplica la rotación al objeto
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Vector3.Distance(transform.position, target) <= 0.2f)
        {
            GetNextWaypoint();
            
        }
    }

    void GetNextWaypoint()
    {
        if (wayPoint >= positions.Count - 1)
        {
            Destroy(this.gameObject);
            return;
        }

        wayPoint++;
        target = positions[wayPoint];
        Vector3 dir = target - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = rotation;
    }
    void OnTriggerEnter(Collider other)
    {
        /*if(other.TryGetComponent<AAA>(out AAA Vending_)){
            Vending_.Buy();
            AudioManager.instance.PlayOneShot(buySound, this.transform.position);
        }*/
        if (other.TryGetComponent<MachineInventory>(out MachineInventory Vending_))
        {
            Vending_.VenderItem(iditemToWish, 1);
            AudioManager.instance.PlayOneShot(buySound, this.transform.position);
        }
    }

    public void setPositions(List<Vector3> pos)
    {
        positions = pos;
    }
}
