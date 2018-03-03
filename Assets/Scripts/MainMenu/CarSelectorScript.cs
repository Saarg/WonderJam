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
	    initCar(0);
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
        initCar(curCarIndex);
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
        initCar(curCarIndex);
    }

    public GameObject GetCurrentCar()
    {
        Destroy(curCar);
        return initCar(curCarIndex);
    }

    private GameObject initCar(int index)
    {
        GameObject car = Instantiate(cars[index], spawnPoint.position, spawnPoint.rotation);
        car.transform.localScale = Vector3.one * 30;
        curCar = car;
        
        return car;
    }


}
