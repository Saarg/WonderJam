using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectorScript : MonoBehaviour
{

    public GameObject[] cars;
    public GameObject curCar;
    private int curCarIndex;
    public Transform spawnPoint;

	// Use this for initialization
	void Start ()
	{
	    curCar = Instantiate(cars[0], spawnPoint.position, spawnPoint.rotation);
	    curCar.transform.localScale = Vector3.one*30;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetNextCar()
    {
        curCarIndex++;
        if (curCarIndex == cars.Length)
        {
            curCarIndex = 0;
        }
        Destroy(curCar);
        curCar = Instantiate(cars[curCarIndex], spawnPoint.position, spawnPoint.rotation);
    }

    public void SetPreviousCar()
    {
        curCarIndex--;
        if (curCarIndex == -1)
        {
            curCarIndex = cars.Length-1;
        }
        Debug.Log("cur car : " + curCarIndex);
        Destroy(curCar);
        curCar = Instantiate(cars[curCarIndex], spawnPoint.position, spawnPoint.rotation);
    }

    public GameObject GetCurrentCar()
    {
        Destroy(curCar);
        GameObject car = Instantiate(cars[0], spawnPoint.position, spawnPoint.rotation);
        curCar = car;
        return car;
    }


}
