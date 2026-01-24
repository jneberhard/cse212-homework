using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

public class FeatureCollection
{
    public Feature[] Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string place { get; set; }
    public double mag { get; set; }
}