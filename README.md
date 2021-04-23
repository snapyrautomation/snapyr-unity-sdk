# snapyr-sdk-unity

## Build instructions
The Unity SDK is distributed as a basic Unity asset package.

To create the package:
1. If not already done, open Unity Hub, go to Projects, click "Add", and select the directory containing this repository.
1. From Unity Hub, open the newly-added `snapyr-sdk-unity` project.
1. Get the current version of the Snapyr SDK for Android, `snapyr-release.aar`, and place it under `Snapyr/Plugins/Android/snapyr-android-sdk` using the Unity Editor. Unity will automatically create a `snapyr-release.aar.meta` file configured to export this library only when building with Android as the target.
    * The Snapyr SDK for Android can be found at [https://github.com/snapyrautomation/snapyr-android-sdk](https://github.com/snapyrautomation/snapyr-android-sdk)
1. In Unity Editor, go to Assets => Export Package...
1. Click "None" to clear the selection, then check the top-level `Snapyr` directory. This will ensure that only the files needed for the SDK integration are included in the package.
1. Click "Export..." and save the package as `snapyr-sdk.unitypackage`.
