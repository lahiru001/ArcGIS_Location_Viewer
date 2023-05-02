using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private MapCreator mapCreator;
    private UIManager uiManager;
    [SerializeField] private SunController sunController;
    void Start()
    {
        mapCreator = FindObjectOfType<MapCreator>();
        uiManager = FindObjectOfType<UIManager>();
    }

    

    public void UpdateGeoPosition(DataUpdater dataUpdater, double longitude, double latitude, double altitude)
    {
        if (dataUpdater == DataUpdater.UI && mapCreator!=null)
        {//If geo position updates come from UIManager class (user input), update geo position values of MapCreator Class
            Debug.Log("UpdateGeoPosition 1");
            mapCreator.SetGeoPosition(longitude, latitude, altitude);
        }
        else if (dataUpdater == DataUpdater.MapCreator && uiManager != null)
        {//If geo position updates come from MapCreator Class (user input), update geo position values of UIManager class
            Debug.Log("UpdateGeoPosition 2");
            uiManager.SetGeoValues(longitude, latitude, altitude);
        }

    }
    

    public enum DataUpdater//Type of data supplier
    {
        UI,
        MapCreator
    }

    public void SunTransform(float time)//Do sun transform
    {
        sunController.MoveTheSunAccordingToTime(time);
    }
   

}
