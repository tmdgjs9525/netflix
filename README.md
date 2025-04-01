# Netflix Clone

OpenSilver/Silverlight 기반 넷플릭스 UI 클론 프로젝트입니다. 여러 플랫폼에서 동작하도록 설계되었으며, MVVM 아키텍처 패턴을 따릅니다.

## 프로젝트 구조

```
netflix_/
│
├── netflix/ - 메인 애플리케이션 프로젝트
│   ├── netflix/ - 핵심 UI 및 논리
│   │   ├── Models/ - 데이터 모델
│   │   ├── ViewModels/ - 뷰 모델
│   │   ├── Views/ - 사용자 인터페이스
│   │   │   ├── Main/ - 메인 화면 구성요소
│   │   │   └── LoginView - 로그인 화면
│   │   └── App.xaml - 애플리케이션 진입점
│   │
│   ├── netflix.Browser/ - 웹 브라우저 지원 프로젝트
│   ├── netflix.Simulator/ - 시뮬레이터 환경
│   └── netflix.MauiHybrid/ - .NET MAUI 하이브리드 지원
│
└── netflix.Core/ - 핵심 비즈니스 로직 및 공통 컴포넌트
    ├── Dialog/ - 다이얼로그 관련 클래스
    ├── Navigate/ - 내비게이션 시스템
    ├── Parameter/ - 매개변수 처리
    ├── Region/ - 영역 관리
    └── ViewModelBase.cs - 기본 뷰모델 클래스

```

## 기술 스택

- **프레임워크**: OpenSilver (Silverlight 호환)
- **UI**: XAML
- **패턴**: MVVM (Model-View-ViewModel)
- **DI 컨테이너**: Microsoft.Extensions.DependencyInjection
- **플랫폼 지원**:
  - 웹 브라우저 (.Browser)
  - 데스크톱 시뮬레이터 (.Simulator)
  - 모바일 앱 (.MauiHybrid)

## 주요 기능

- 사용자 인증 (로그인 화면)
- 넷플릭스 스타일 메인 페이지
- 비디오 프리뷰 및 재생
- 카테고리별 콘텐츠 브라우징
- 반응형 레이아웃

## 설치 및 실행 방법

### 필수 조건

- Visual Studio 2022 이상
- .NET 기반 개발 환경
- OpenSilver 확장

### 개발 환경 설정

1. 저장소 클론:
```
git clone https://github.com/[username]/netflix_.git
```

2. Visual Studio에서 `netflix.sln` 파일 열기

3. 솔루션 빌드:
```
Right-click Solution > Build Solution
```

4. 실행 방법:
   - 브라우저에서 실행: `netflix.Browser` 프로젝트를 시작 프로젝트로 설정
   - 시뮬레이터에서 실행: `netflix.Simulator` 프로젝트를 시작 프로젝트로 설정
   - MAUI 하이브리드 앱으로 실행: `netflix.MauiHybrid` 프로젝트를 시작 프로젝트로 설정

## 아키텍처 설명

### 네비게이션 시스템

프로젝트는 커스텀 네비게이션 시스템을 구현하여 여러 뷰 간의 전환을 관리합니다. `INavigationRegister`와 같은 인터페이스를 통해 뷰와 뷰모델 간의 연결을 등록하고, 애플리케이션의 네비게이션 상태 변경에 따라 적절한 컨텐츠를 표시합니다.

### 의존성 주입

`CommunityToolkit.Mvvm.DependencyInjection`과 `Microsoft.Extensions.DependencyInjection`을 사용하여 서비스 및 뷰모델의 의존성을 관리합니다. `App.xaml.cs`의 `serviceInitialize()` 메서드에서 의존성 주입을 설정합니다.

### 뷰모델 구성

모든 뷰모델은 `ViewModelBase`를 상속받아 공통 기능을 제공받으며, MVVM 패턴에 따라 뷰와 모델 사이의 중재자 역할을 합니다.

## 기여 방법

1. 이 저장소를 포크합니다.
2. 새 기능 브랜치를 생성합니다: `git checkout -b feature/amazing-feature`
3. 변경 사항을 커밋합니다: `git commit -m 'Add some amazing feature'`
4. 브랜치에 푸시합니다: `git push origin feature/amazing-feature`
5. Pull Request를 제출합니다.

## 라이선스

이 프로젝트는 [라이선스 명시 필요] 라이선스 하에 배포됩니다.

## 감사의 말

- OpenSilver 팀
- 넷플릭스 UI 디자인 영감
