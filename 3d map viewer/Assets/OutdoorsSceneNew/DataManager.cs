using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public List<Location> locations = new List<Location>() //Predefined locations for combobox
    {   
        new Location(-70.985786d, 42.536457,"Peabody, MA, USA"),
        new Location(-72.664658d, 42.328674,"Northampton, MA, USA"),
        new Location(-71.217133d, 42.341042,"Newton, MA, USA"),
    };

}
