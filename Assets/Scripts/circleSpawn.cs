using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleSpawn : MonoBehaviour
{
    [SerializeField] GameObject Circles;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCircles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCircles()
    {
        int randnum = Random.Range(5, 10);
        for(int i=0;i<randnum;i++)
        {
            Vector3 pos=new Vector3(Random.Range(-8,5),Random.Range(-4,2),0);
            Instantiate(Circles, pos, Quaternion.identity);
        }
    }
}
