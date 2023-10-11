# 개인과제 - B04 김강현

- ref Only Up
![캡처](https://github.com/koju2005/3Week/assets/141552941/d6b42513-b00a-4805-8480-1d6472718308)

- # 기본 조작

- 이동 - WASD
- 점프 - Space Bar
- Q key - 세이브포인트 이동
- R key - 시간이 느리게 흘러감


# 게임 내 오브젝트 설명
![화면 캡처 2023-10-11 114955](https://github.com/koju2005/3Week/assets/141552941/15d423a6-6f50-4a2e-95b6-d83a1148f145)

드럼통 - 세이브 포인트

콜리전을 가지고있어 플레이어와 충돌 시 해당 오브젝트의 position값을 플레이어의 SavePoint로 가지게됨.



![화면 캡처 2023-10-11 115009](https://github.com/koju2005/3Week/assets/141552941/8f502749-7aa6-424c-996b-1249e5decbbe)

침대 - 점프패드

침대면 충돌 시 강한 점프

# 주요 기능 구현

- 플레이어 이동 - PlayerInput System

- 움직이는 오브젝트 분리 - Scriptable Object를 이용한 움직임이 가능한 오브젝트들의 수직,수평 운동 분리

- Ground Hit시 SavePoint 초기화로 처음부터 다시 진행 및 사라진 드럼통들이 다시 보이게됨

- 그나마 편한 레벨 디자인을 위한 유니티 커스텀 에디터
![화면 캡처 2023-10-11 123101](https://github.com/koju2005/3Week/assets/141552941/5467da23-e0f9-4819-a42b-488736cb8a46)

 ![화면 캡처 2023-10-11 1148491](https://github.com/koju2005/3Week/assets/141552941/4d759a34-9768-4736-96f0-b71c27206e5b)

 자주 사용할 프리팹이나 해당 레벨 디자인 테마에 맞는 프리팹을 따로 저장 후 배치버튼을 누르게되면 SceneView가 보고있는 정면에 배치되게됨
 
 ![화면 캡처 2023-10-11 120243](https://github.com/koju2005/3Week/assets/141552941/303f74ab-2660-4150-b0de-e0d4e4e7710c)

 ![화면 캡처 2023-10-11 114849](https://github.com/koju2005/3Week/assets/141552941/ac55546e-8381-49d0-9192-4700e424b6d8)

 생성된 오브젝트들은
  ![화면 캡처 2023-10-11 120346](https://github.com/koju2005/3Week/assets/141552941/16cab999-7d5b-4253-8a19-b2ad730bef20)

해당 코드를 이용해 하위 자식으로 생성되게됨
![화면 캡처 2023-10-11 120448](https://github.com/koju2005/3Week/assets/141552941/53bc9e2e-af85-41fc-bb2d-2a17cb71d89c)
