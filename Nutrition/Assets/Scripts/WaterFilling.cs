﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFilling : MonoBehaviour {

    private int count;

    public GameObject noodles;
    public Renderer rend;

    public GameObject cookednoodles;
    public GameObject water;
    public GameObject finishednoodles;
    
    // Use this for initialization
	void Start ()
    {
        count = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        transform.localScale = new Vector3(2, 0.1f, 2);
        transform.localPosition = new Vector3(-0.7f, -0.7f, 2.2f);
        noodles.SetActive(false);
        finishednoodles.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            if (count == 0)
            {
                rend.enabled = true;
                count += 1;
            }

            else if (count < 4)
            {
                transform.localScale = new Vector3(2, transform.localScale.y + 0.1f, 2);
                transform.localPosition = new Vector3(-0.7f, transform.localPosition.y + 0.1f, 2.2f);
                count += 1;
            }

            else
            {
                GameObject.FindGameObjectWithTag("Faucet").GetComponent<WaterSpawn>().enabled = false;
            }

        }

        if (other.gameObject.tag == "Noodles" && count >= 4)
        {
            Destroy(other.gameObject);
            noodles.SetActive(true);
        }

        if(other.gameObject.tag == "Boiled Noodles")
        {
            if(gameObject.tag == "Strainer")
            {
                Destroy(water);
                Destroy(other.gameObject);
                finishednoodles.SetActive(true);
            }
        }
    }
}
