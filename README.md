## This repository does not include the full features of the native library. I only included what I am using. You can extend it by following these instructions
## iOS only support for real device
[![NuGet Badge](https://buildstats.info/nuget/Omnicasa.Mobile.Maui.BlinkID.iOS)](https://www.nuget.org/packages/Omnicasa.Mobile.Maui.BlinkID.iOS/)

## Updating native binding libraries

### Android

1. Download latest AAR from [Android SDK repository](https://github.com/BlinkID/blinkid-android/blob/master/LibBlinkID.aar)
2. Replace `Binding/Android/Jars/LibBlindID.aar` with latest AAR
3. Open `Binding/Forms/BlinkID.Forms/BlinkID.Forms.sln` solution
4. If needed, update `Transforms/Metadata.xml` in `AndroidBinding` project.
5. Right-click the `AndroidBinding` project, select `Options`, under `NuGet Package` section select `Metadata`
6. Update `Version` on tab `General`
7. Update `Release notes` on tab `Details`
8. Rebuild the `AndroidBinding` project

### iOS

1. Download latest [MicroBlink.bundle](https://github.com/BlinkID/blinkid-ios/tree/master/MicroBlink.bundle) and [MicroBlink.framework](https://github.com/BlinkID/blinkid-ios/tree/master/MicroBlink.framework) from [iOS SDK repository](https://github.com/BlinkID/blinkid-ios)
2. Replace `Binding/iOS/MicroBlink.bundle` and `Binding/iOS/MicroBlink.framework` with latest versions
3. Generate new `ApiDefinitions.cs` and `StructsAndEnums.cs` with latest version of [Objective Sharpie](https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/binding/objective-sharpie/get-started), but **DO NOT OVERWRITE existing `ApiDefiniton.cs` and `Structs.cs`**
    - you can generate new `ApiDefinitions.cs` and `StructsAndEnums.cs` with following command (replace `iphoneos11.4` with latest SDK you have on your Mac):

    ```
    cd Binding/iOS
    sharpie bind -sdk iphoneos11.4 MicroBlink.framework/Headers/MicroBlink.h -scope MicroBlink.framework/Headers -namespace Microblink -c -F .
    ```
4. Manually merge new structures from generated `StructsAndEnums.cs` into existing `Structs.cs` while fixing compile errors
    - `sharpie` generates enums with underlying types such as `nuint` or `nint` which are not supported by latest version of C# - you must replace those with `uint` or `int` types.
5. Manually merge new API classes from generated `ApiDefinitions.cs` into existing `ApiDefinition.cs`
    - note that diff between those two files may be quite large, as `ApiDefinition.cs` has been manually edited to ensure correct compilation and correct exposure of all native SDK features. Focus only on adding new recognizers and parsers. Usually it shuold not be necessary to add other classes.
6. Open `Binding/Forms/BlinkID.Forms/BlinkID.Forms.sln` solution
7. From `iOSBinding` project remove `MicroBlink.bundle` and re-add it back
    - this will ensure that all new resources from new bundle are correctly added to the project
    - also make sure that all resources within added `MicroBlink.bundle` have `BuildAction` set to `BundleResource`
8. Right-click the `iOSBinding` project, select `Options`, under `NuGet Package` section select `Metadata`
9. Update `Version` on tab `General`
10. Update `Release notes` on tab `Details`
11. Rebuild the `iOSBinding` project and fix any compile errors that may have been introduced in steps 4. and 5.
