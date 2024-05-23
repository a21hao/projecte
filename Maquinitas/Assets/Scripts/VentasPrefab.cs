using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VentasPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeOfAnimation;
    [SerializeField]
    private float timeOfDesapear;
    [SerializeField]
    private TextMeshProUGUI textVenta;
    [SerializeField]
    private TextMeshProUGUI textCantidad;
    [SerializeField]
    private Image imageVenta;
    private float timeToisDesapearing;
    private float timeOfDesapearing;
    private Vector3 dir;
    private float time;
    private float counterDesapearing;
    
    void Start()
    {
        gameObject.transform.eulerAngles = new Vector3(341.136078f, 146.30838f, -4.51116648e-07f);
        dir = transform.up;
        timeToisDesapearing = timeOfAnimation - timeOfDesapear;
        counterDesapearing = 0;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (speed * Time.deltaTime) * dir;
        time += Time.deltaTime;
        if(time >= timeToisDesapearing)
        {
            counterDesapearing += Time.deltaTime;
            textVenta.color = new Color(textVenta.color.r, textVenta.color.g, textVenta.color.b, 1 - counterDesapearing / timeOfDesapear);
            imageVenta.color = new Color(imageVenta.color.r, imageVenta.color.g, imageVenta.color.b, 1 - counterDesapearing / timeOfDesapear);
            //Debug.Log(counterDesapearing / timeOfDesapear);
        }
        if(time >= timeOfAnimation)
        {
            Destroy(gameObject);
            
        }
        Debug.Log("text " + textVenta.color.a);
        Debug.Log("image " + textVenta.color.a);
    }

    public void SetTextVenta(string text)
    {
        textVenta.text = text;
    }

    public void SetImageVenta(Sprite imageSprite)
    {
        imageVenta.sprite = imageSprite;
    }

    public void SetCantidadVenta(int cantidad)
    {
        textCantidad.text = cantidad.ToString();
    }
}
