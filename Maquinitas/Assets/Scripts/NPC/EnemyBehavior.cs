using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EventReference buySound;
    //[SerializeField] private GameObject wishListGO;
    private List<Vector3> positions;

    [SerializeField]
    private ParticleSystem SiItem;

    [SerializeField]
    private ParticleSystem NoItem;
    public float speed = 3f;
    private float lastSpeed;

    [SerializeField]
    private int itemsWantToBuyCat1;
    [SerializeField]
    private int itemsWantToBuyCat2;
    [SerializeField]
    private int itemsWantToBuyCat3;

    private List<int> idsItemWantToBuy;
    private List<bool> objectsSolded;

    private Vector3 target;
    private int wayPoint = 0;
    private Wishlist wishList;
    private int iditemToWish;
    private int itemsWantToBuy = 1;
    private int itemsSolded = 0;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        idsItemWantToBuy = new List<int>();
        objectsSolded = new List<bool>();
        if (ObjectivesAndStats.Instance.categoriaActual == 1) itemsWantToBuy = itemsWantToBuyCat1;
        if (ObjectivesAndStats.Instance.categoriaActual == 2) itemsWantToBuy = itemsWantToBuyCat2;
        if (ObjectivesAndStats.Instance.categoriaActual == 3) itemsWantToBuy = itemsWantToBuyCat3;
        target = positions[0];
        lastSpeed = speed;
        //_mvb = GetComponent<MovementBehavior>();
        Vector3 dir = target - transform.position;
        //Debug.Log(dir);
        Quaternion rotation = Quaternion.LookRotation(dir);
        wishList = GameObject.Find("GameManager/WishList").GetComponent<Wishlist>();
        //Debug.Log(wishList.ItemToWishId(ObjectivesAndStats.Instance.categoriaActual))
        //iditemToWish = wishList.ItemToWishId();
        for(int i = 0; i < itemsWantToBuy; i++)
        {
            idsItemWantToBuy.Add(wishList.ItemToWishId(ObjectivesAndStats.Instance.categoriaActual));
            objectsSolded.Add(false);
        }

        //Debug.Log(rotation);

        // Aplica la rotaci�n al objeto
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
            //Vending_.VenderItem(1, 1);
            //AudioManager.instance.PlayOneShot(buySound, this.transform.position);

            if (itemsSolded < itemsWantToBuy)
            {
                lastSpeed = speed;
                bool hadSoldAnItem = false;
                for (int i = 0; i < itemsWantToBuy; i++)
                {
                    if(!objectsSolded[i])
                    {
                        int itemsSoldedBeforeTryBuy = itemsSolded;
                        itemsSolded += Vending_.VenderItem(idsItemWantToBuy[i], 1);
                        if (itemsSolded > itemsSoldedBeforeTryBuy)
                        {
                            objectsSolded[i] = true;
                            hadSoldAnItem = true;
                        }
                    }
                    
                }         
                if (hadSoldAnItem)
                {
                    speed = 0f;
                    Vector3 dirMachine = Vending_.gameObject.transform.position - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(dirMachine);
                    transform.rotation = rotation;
                    StartCoroutine(WaitBuying(lastSpeed));
                    Instantiate(SiItem, this.transform.position, this.transform.rotation);
                    AudioManager.instance.PlayOneShot(buySound, this.transform.position);
                }
                else
                {
                    Instantiate(NoItem, this.transform.position, this.transform.rotation);
                }
            }
        }
    }


    public void setPositions(List<Vector3> pos)
    {
        positions = pos;
    }

    private IEnumerator WaitBuying(float speedd)
    {
        yield return new WaitForSeconds(1f);
        speed = speedd;
        Vector3 dir = target - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = rotation;
    }
}
