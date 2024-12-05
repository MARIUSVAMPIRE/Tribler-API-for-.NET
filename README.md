Tribler 8+ API for .NET Library

This is API library that handle Tribler 8+ in .NET.

# Usage


```c#
if (await downloads.Get("", true, true, true))
{
  foreach (Downloads.Container.Information information in downloads.LIST)
  {
    ...
  }
}
```
