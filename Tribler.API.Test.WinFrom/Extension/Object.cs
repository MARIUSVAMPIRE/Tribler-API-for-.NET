namespace Tribler.API.Test.WinFrom;

public static class ObjectExtension
{
    public static object GetPropertyValue(this object objectValue, string property)
    {
        return objectValue.GetType().GetProperty(property).GetValue(objectValue);
    }
}
