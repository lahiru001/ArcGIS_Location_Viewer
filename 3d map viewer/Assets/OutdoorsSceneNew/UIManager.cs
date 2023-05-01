using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    //public MapCreator mapCreator;
   // public GameObject popMenu;
    [SerializeField] private Button menuButton;
    //[SerializeField] private Dropdown locationDropdown;
    [SerializeField] private TMP_InputField latitudeInput;
    [SerializeField] private TMP_InputField longitudeInput;
    [SerializeField] private TMP_InputField altitudeInput;

    private bool isPopMenuOpen;
    private MapController mapController;
    private void Start()
    {
        mapController = FindObjectOfType<MapController>();
        longitudeInput.text = "-74.054921";
        latitudeInput.text = "40.691242";
        altitudeInput.text = "120";
        //isPopMenuOpen = false;

        // locationDropdown.ClearOptions();
        //   locationDropdown.AddOptions(mapCreator.locations.ConvertAll(loc => loc.locationName));
    }

    /*public void OnMenuButtonClick()
    {
        isPopMenuOpen = !isPopMenuOpen;

        popMenu.SetActive(isPopMenuOpen);
        menuButton.interactable = !isPopMenuOpen;
    }*/

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
