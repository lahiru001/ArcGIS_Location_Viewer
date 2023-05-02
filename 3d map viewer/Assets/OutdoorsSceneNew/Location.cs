using System.Collections.Generic;

public class Location {
    public double latitude;
    public double longitude;
    public string locationName;

    public Location(double lat, double lon, string name) {
        latitude = lat;
        longitude = lon;
        locationName = name;
    }
    
}
