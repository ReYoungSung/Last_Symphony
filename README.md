# Last Symphony

음악의 시각화를 주제로 제작한 핸드 제스처 기반 미디어 아트 게임입니다. HCI(인간과 컴퓨터 상호작용) 수업 프로젝트로, 베토벤의 마지막 교향곡 지휘를 모티브로 삼았습니다.

## 프로젝트 배경

청각장애인을 대상으로 음악을 시각적으로 경험하는 방식을 탐구했습니다. Leap Motion을 이용한 손동작 입력과 시각 효과를 연결했으며, 향후 VFX 디자이너와의 협업을 통해 표현을 확장하고자 했습니다.

## 팀

이영성, 김현진, 김윤섭

## 개발 환경

| 항목 | 값 |
| --- | --- |
| Unity Editor | **2021.3.21f1** |
| Unity 프로젝트 폴더 | `GameProjectFile/` |
| 기본 브랜치 | `main` |

Unity 버전은 [ProjectVersion.txt](GameProjectFile/ProjectSettings/ProjectVersion.txt)에 기록된 값을 기준으로 합니다.

- Leap Motion 장비와 해당 Unity 플러그인에 맞는 장치 소프트웨어
- 모니터 2대: 멀티 디스플레이 전시 구성용

## 시작하기

```bash
git clone --branch main https://github.com/ReYoungSung/Last_Symphony.git
```

1. Unity Hub에 위 버전의 Editor를 설치합니다.
2. 저장소 안의 `GameProjectFile` 폴더를 프로젝트로 추가합니다. 저장소 최상위 폴더와 Unity 프로젝트 폴더는 서로 다릅니다.
3. 최초 임포트와 Package Manager의 패키지 복원을 완료합니다.
4. 아래 씬 안내에 따라 확인할 씬을 열고 Play를 실행합니다.

`Assets/Scenes/`에 `SampleScene.unity`, `Sound Visulization.unity`, `Test.unity`가 있습니다. 확인할 씬을 직접 열어 실행합니다. `EditorBuildSettings.asset`의 씬 목록이 비어 있으므로 실행 파일을 만들기 전에 사용할 씬과 순서를 Build Settings에 등록해야 합니다.

빌드 구성은 [EditorBuildSettings.asset](GameProjectFile/ProjectSettings/EditorBuildSettings.asset), 패키지 목록은 [manifest.json](GameProjectFile/Packages/manifest.json)에서 확인할 수 있습니다. 아래 `Assets/` 경로는 Unity 프로젝트 폴더 기준입니다.

## 주요 폴더

| 경로 | 내용 |
| --- | --- |
| [Assets/Scenes/](GameProjectFile/Assets/Scenes/) | 음악 시각화 및 실험 씬 |
| [Assets/Scripts/](GameProjectFile/Assets/Scripts/) | 손동작·오디오 시각화·멀티 디스플레이 로직 |

## 실행 시 확인할 점

- Leap Motion에서 손이 인식되는지 확인한 뒤 Unity의 손 추적 입력을 확인합니다.
- `MultiDisplay.cs`는 연결된 보조 디스플레이를 활성화합니다. 실제 전시는 모니터 연결과 씬 카메라의 출력 대상 설정을 함께 확인합니다.
- `SceneChanger.cs`에는 `LoadingScene`으로 이동하는 코드가 있습니다. 이 동작을 사용할 때는 대상 씬의 존재와 빌드 등록 상태를 확인해야 합니다.
