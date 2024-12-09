# Tribler API

Tribler 8+ API for .NET Library

This is API library what handle Tribler 8+ in .NET.

[![Tribler.API](https://img.shields.io/nuget/v/Tribler.API.svg?style=flat)](https://www.nuget.org/packages/Tribler.API/)

## Usage


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

## Links

[Github](https://github.com/MARIUSVAMPIRE/Tribler-API-for-.NET)
