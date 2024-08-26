# Google ARCore Binding for .NET 8 (and Maui)

Augmented Reality is more than a live overlay over a camera preview. It's a real time 3D depth analysis of a scene.

[Google's ARCore](https://developers.google.com/ar/) is a closed source SDK from Google which manages and processes the cameras, outputs 3D points, and can anchor your 3D objects as overlays.

This nuget is a drop-in replacment for the legacy [Xamarin component](https://github.com/xamarin/XamarinComponents/blob/main/Android/ARCore/)

## Using

Reference the Nuget and use it:  
[![NuGet](https://img.shields.io/nuget/v/Vapolia.Google.ARCore.svg?style=for-the-badge)](https://www.nuget.org/packages/Vapolia.Google.ARCore/)  
[![NuGet](https://img.shields.io/nuget/vpre/Vapolia.Google.ARCore.svg?style=for-the-badge)](https://www.nuget.org/packages/Vapolia.Google.ARCore/)  
![Nuget](https://img.shields.io/nuget/dt/Vapolia.Google.ARCore)


## Building

### Prerequisites

Install [.NET 8](https://dotnet.microsoft.com/download) and the lightweight [Cake .NET Tool](http://cakebuild.net):

```sh
dotnet tool install -g cake.tool
```

### Building the ARCore library

First download the external dependencies once from a command line:

```powershell
dotnet cake --target=externals
```

Then either use an IDE directly, or from the command line:

```powershell
dotnet cake
```

## Running an ARCore project

### On a device

Use one of the [supported device](https://developers.google.com/ar/discover/#supported_devices)

### On an emulator

First install the special APK "Google AR for simulator" in your simulator:
* Download that APK from the release section of the official GitHub of [ARCore Android SDK](https://github.com/google-ar/arcore-android-sdk)
* drag drop that APK in the simulator's window

Then run your project as usual.

## FAQ

Why cake ?  
To automate the download of the .AAR files
