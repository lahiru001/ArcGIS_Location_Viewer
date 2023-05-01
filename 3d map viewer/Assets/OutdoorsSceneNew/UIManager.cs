using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.FilePathAttribute;
using System.Collections.Generic;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    //public MapCreator mapCreator;
   // public GameObject popMenu;
    [SerializeField] private Button menuButton;
    //[SerializeField] private Dropdown locationDropdown;
    [SerializeField] private TMP_InputField latitudeInput;
    [SerializeField] private TMP_InputField longitudeInput;
    [SerializeField] private TMP_InputField altitudeInput;
    [SerializeField] private TMP_Dropdown dropdown;

    private bool isPopMenuOpen;
    private MapController mapController;
    private List<Location> locations;
    private void Start()
    {
        mapController = FindObjectOfType<MapController>();
        
        longitudeInput.text = "-74.054921";
        latitudeInput.text = "40.691242";
        altitudeInput.text = "120";
        locations = FindObjectOfType<DataManager>().locations;
        DropDownInitializer();
        //isPopMenuOpen = false;

        // locationDropdown.ClearOptions();
        // locationDropdown.AddOptions(mapCreator.locations.ConvertAll(loc => loc.locationName));
    }

    void DropDownInitializer()
    {
        dropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        //Dropdown.OptionData[] options = new Dropdown.OptionData[locations.Length];
        foreach (Location location in locations)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(location.locationName);
            options.Add(option);
        }

        dropdown.AddOptions(options);
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index)
    {
        Location selectedLocation = locations[index];
        double longitude = selectedLocation.longitude;
        double latitude = selectedLocation.latitude;

        // Do something with the longitude and altitude values
        mapController.UpdateGeoPosition(MapController.DataUpdater.UI, longitude, latitude, double.Parse(altitudeInput.text));
    }

    /* public void OnLocationDropdownValueChanged()
     {
         int index = locationDropdown.value;
         Location selectedLocation = mapCreator.locations[index];

         mapCreator.UpdateLocation(selectedLocation.latitude, selectedLocation.longitude);
         altitudeInput.text = selectedLocation.altitude.ToString();
         latitudeInput.text = selectedLocation.latitude.ToString();
         longitudeInput.text = selectedLocation.longitude.ToString();
     }
    */

    /*public void OnMenuButtonClick()
    {
        isPopMenuOpen = !isPopMenuOpen;

        popMenu.SetActive(isPopMenuOpen);
        menuButton.interactable = !isPopMenuOpen;
    }*/





    public void ReadValuesFromInput()
    {   //Read input and call UpdateLatitude function;

        mapController.UpdateGeoPosition(MapController.DataUpdater.UI, double.Parse(longitudeInput.text), double.Parse(latitudeInput.text), double.Parse(altitudeInput.text));
    }

    public void SetGeoValues(double longitude, double latitude, double altitude)
    {
        longitudeInput.text = longitude.ToString();
        latitudeInput.text = latitude.ToString();
        altitudeInput.text = altitude.ToString();
    }



}
