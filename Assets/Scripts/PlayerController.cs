using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rg;
    public float speed;
    public GameObject playerExplosion;   
    
    bool isFrozen;
     // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        this.gameObject.GetComponent<Renderer>().enabled=true;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isFrozen){
            float x=Input.GetAxis("Horizontal");
            float z=Input.GetAxis("Vertical");

            Vector3 movement=new Vector3(x, 0.0f, z);
            rg.AddForce(movement*speed);
        }
    }
    public void FreezePlayer(bool value){
        isFrozen=value;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy")){
            StartCoroutine(Restart());
            //SceneManager.LoadScene(0);
        }
    }
    IEnumerator Restart()
    {
        this.gameObject.GetComponent<Renderer>().enabled=false;
        Instantiate(playerExplosion,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
