using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private MapCreator mapCreator;
    private UIManager uiManager;
    void Start()
    {
        mapCreator = FindObjectOfType<MapCreator>();
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateGeoPosition(DataUpdater dataUpdater, double longitude, double latitude, double altitude)
    {
        if (dataUpdater == DataUpdater.UI && mapCreator!=null)
        {
            Debug.Log("UpdateGeoPosition 1");
            mapCreator.SetGeoPosition(longitude, latitude, altitude);
        }
        else if (dataUpdater == DataUpdater.MapCreator && uiManager != null)
        {
            Debug.Log("UpdateGeoPosition 2");
            uiManager.SetGeoValues(longitude, latitude, altitude);
        }

    }
    

    public enum DataUpdater
    {
        UI,
        MapCreator
    }

   

}
