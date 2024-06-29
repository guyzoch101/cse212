public class FeatureCollection {
    // Todo Earthquake Problem - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public List<Feature> Features { get; set; } // a Feature list to store all accounted earthquakes
}

public class Feature {
    public Properties Properties { get; set; } // Feature -> Properties
}

public class Properties { // all the needed data are in Properties
    public string Place { get; set; }
    public double Mag { get; set; }
}