Tribler 8+ API for .NET Library

This is API library that handle Tribler 8+ in .NET.

# Usage


```c#
using Tribler.API;

Downloads downloads = new(new Settings());  //Load Tribler Config
if (await downloads.Get("", true, true, true))  //Get Download List
{
  foreach (Downloads.Container.Information information in downloads.LIST)
  {
    // Do Something
  }
}
```
