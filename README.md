
# 🎬 Netflix UI Clone with OpenSilver

이 프로젝트는 **OpenSilver**를 사용하여 Netflix 스타일의 사용자 인터페이스를 웹 환경에서 구현한 클론 프로젝트입니다. WPF 개발자가 손쉽게 웹 프론트엔드를 만들 수 있도록 설계되었으며, MVVM 아키텍처를 기반으로 구성되어 있습니다.

---

## 🧩 프로젝트 구성

```
netflix/
├── netflix/                    # 메인 OpenSilver 프로젝트
│   ├── Views/                  # MainPage.xaml 기반의 UI
│   ├── ViewModels/             # MainPageViewModel.cs (MVVM 구조)
│   ├── Converter/              # IValueConverter 관련 변환기
│   ├── Helper/                 # 헬퍼 클래스 및 유틸리티
│   ├── Assets/                 # 이미지 및 정적 리소스
│   ├── App.xaml                # 전역 리소스 및 진입점
│   ├── Colors.xaml, Geometries.xaml # 스타일 리소스
├── netflix.Browser/            # WebAssembly 기반 실행 대상
├── netflix.Simulator/          # 데스크톱 실행용 시뮬레이터
├── netflix.MauiHybrid/         # .NET MAUI 하이브리드 앱 버전
├── netflix.Core/               
├── netflix.Login/             
├── netflix.Main/
├── netflix.Setting/                 
├── netflix.Data/              
├── netflix.ViewManager/        # 뷰 매니저 로직
├── netflix.Support/            # 공통 컨트롤 및 유틸리티 및 확장 기능          
├── NuGet.Config                # NuGet 구성
└── netflix.sln                 # Visual Studio 솔루션 파일
```

---

## ✨ 주요 기능

- **OpenSilver 기반 UI 구성**  
  - WPF와 동일한 XAML 문법으로 웹 앱 개발 가능  

- **MVVM 아키텍처 적용**  
  - ViewModel을 통해 로직 분리 및 테스트 용이

- **멀티 타겟 실행**  
  - 브라우저(WebAssembly), 데스크톱(Simulator), MAUI 하이브리드 지원

---

## ▶ 실행 방법

1. **사전 요구 사항**
   - [.NET 9 SDK 이상](https://dotnet.microsoft.com/)  
   - Visual Studio 2022 + OpenSilver 확장 설치

2. **실행 절차**
   ```bash
   git clone https://github.com/tmdgjs9525/netflix.git
   cd netflix
   ```

3. Visual Studio로 `netflix.sln` 열기

4. `netflix.Browser` 또는 `netflix.Simulator`를 시작 프로젝트로 설정 후 실행 (`Ctrl + F5`)

---

## 📷 미리보기
https://opensilverflix.netlify.app/
