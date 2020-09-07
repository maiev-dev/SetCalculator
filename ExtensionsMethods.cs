using System;

public class ExtensionMethods
{
	public ExtensionMethods()
	{
	}

    public static bool Contains<T>(this List<T> list, T elementToSearch)
    {
        foreach (var element in list)
        {
            if (element == elementToSearch) return true;
        }
        return false;
    }

}
