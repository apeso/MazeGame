using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject gm;
    public int coinValue;
    void Start()
    {
        if (gm==null){
            gm=GameObject.FindWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player"){
            gm.GetComponent<GameManager>().CollectCoin(coinValue);
            Destroy(this.gameObject);
        }
    }
}
