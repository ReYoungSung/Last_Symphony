[한국어](README.md) | **English**

# Last Symphony

A hand-gesture-based media art game about visualizing music. Created for an HCI (Human–Computer Interaction) course, it takes inspiration from conducting Beethoven's final symphony.

## Background

The project explored ways for people with hearing impairments to experience music visually. It connects Leap Motion hand gestures to visual effects, with an intention to expand the visual expression through future collaboration with VFX designers.

## Team

이영성 (Youngsung Ree), 김현진, 김윤섭

## Development environment

| Item | Value |
| --- | --- |
| Unity Editor | **2021.3.21f1** |
| Unity project folder | `GameProjectFile/` |
| Default branch | `main` |

The Unity version is taken from [ProjectVersion.txt](GameProjectFile/ProjectSettings/ProjectVersion.txt).

- Leap Motion hardware and device software compatible with the Unity plugin
- Two monitors for the multi-display exhibition setup

## Getting started

```bash
git clone --branch main https://github.com/ReYoungSung/Last_Symphony.git
```

1. Install the Editor version above through Unity Hub.
2. Add the repository's `GameProjectFile` folder as a project. The repository root and Unity project folder are different.
3. Complete the initial import and Package Manager dependency restoration.
4. Open a scene as described below and enter Play mode.

`Assets/Scenes/` contains `SampleScene.unity`, `Sound Visulization.unity`, and `Test.unity`. Open the desired scene directly. Since `EditorBuildSettings.asset` has an empty scene list, add the required scenes in order to Build Settings before creating a build.

See [EditorBuildSettings.asset](GameProjectFile/ProjectSettings/EditorBuildSettings.asset) for build configuration and [manifest.json](GameProjectFile/Packages/manifest.json) for dependencies. The `Assets/` paths below are relative to the Unity project folder.

## Main folders

| Path | Contents |
| --- | --- |
| [Assets/Scenes/](GameProjectFile/Assets/Scenes/) | Music visualization and experimental scenes |
| [Assets/Scripts/](GameProjectFile/Assets/Scripts/) | Gestures, audio visualization, and multi-display logic |

## Runtime checks

- Verify that Leap Motion detects your hands before checking Unity's hand-tracking input.
- `MultiDisplay.cs` activates connected secondary displays. For an exhibition, check both monitor connections and the scene cameras' target displays.
- `SceneChanger.cs` contains a transition to `LoadingScene`. Verify that the target scene exists and is included in the build before using it.

## Usage

### Preparation

1. Connect Leap Motion and verify tracking of both hands in the device software.
2. If using two monitors, check the operating system's extended-display configuration and each Unity camera's target display.
3. Open the desired scene and enter Play mode. Keep your hands within the sensor's tracking range and follow the gesture prompts.
4. Perform each gesture while the corresponding instrument prompt is displayed. On success, a Clear indicator appears and the instrument's volume and visual effects change.

### Hand gestures

The following rules apply to scenes using `HandMotionManager`. Target palm directions and height thresholds depend on the scene's detector settings.

| Section | Gesture |
| --- | --- |
| Start / piano | Hold a thumb–index pinch with both hands and raise them to begin |
| Cello | Extend only the index finger on each hand and make circular movements |
| Timpani | Make fists with both hands and move them up and down |
| Violin | Align the left palm with the indicated direction while holding a right-hand pinch and moving it side to side |
| Chimes / cymbals | Extend all fingers on both hands and hold the prompted pose to fill the gauge |

If a gesture is not recognized, check for occluded fingers, tracking of both hands, and whether the instrument's prompt is active. Do not assume a fixed palm direction; compare the on-screen instructions with the scene's Palm Direction Detector settings.

### Ending and known transition limitations

Exit Play mode to end the experience in the Editor. The build scene list is currently empty, and menu code references `LoadingScene` and `ConductingScene`. Do not assume the menu-to-ending flow works until the actual experience scenes, their names, menu connections, and build entries are aligned.

Behavior references: [HandMotionManager.cs](GameProjectFile/Assets/Scripts/HandMotionManager.cs) · [HandGestureTracking.cs](GameProjectFile/Assets/Scripts/HandGestureTracking.cs)
