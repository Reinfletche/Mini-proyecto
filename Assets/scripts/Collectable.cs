using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float rotationspeed;

    private void Update()
    {
        //Quaternion
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, rotationspeed * Time.deltaTime, 0f));
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.AddCoins();

        //Debug.Log("Moneda : " + this.gameObject.name);
    }
}
