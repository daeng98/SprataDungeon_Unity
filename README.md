### 스파르타 던전 - Unity  버전 (인벤토리)
이전에 했던 c# 구현 내용을 유니티로 옮기는 내용입니다.
배웠던 내용이 실제로 유니티에서 어떻게 적용되는지 직접 구현하며 연습해봅시다.


### 구현 사항
- 1. 메인 화면 구성   
- 2. Status 보기
- 3. Inventory 보기
- + 캐릭터 생성 화면
 

### 캐릭터 생성 화면
시작 시 캐릭터의 이름을 정하고 캐릭터를 생성합니다.
![image](https://github.com/user-attachments/assets/5080e878-496b-49bf-af04-18ac518f9fc8)


### 메인 화면
간단한 캐릭터의 정보와 상태창, 인벤토리 버튼이 있습니다.
![image](https://github.com/user-attachments/assets/0e636a25-0147-4c7d-8275-0a9ea23db165)

던전 전투에 대한 부분을 만들지 않았기 때문에 간단하게 시간마다 골드와 경험치를 획득하게 만들어두었습니다.
레벨에 따라 칭호와 텍스트가 바뀌게 됩니다.
![image](https://github.com/user-attachments/assets/42859454-f34e-46e7-b012-973831000e3d)


### 상태창
상태창 버튼을 눌르면 ui가 활성화 됩니다.
레벨 업 시 스탯이 증가하게 만들었습니다.
![image](https://github.com/user-attachments/assets/48ff16f2-eb17-4dbc-b28d-53790a0d177d)

아이템 장착시 스탯도 같이 표기해줍니다.
![image](https://github.com/user-attachments/assets/c8ae81d2-e246-4f3b-8f52-cb58cb2d254f)


### 인벤토리
인벤토리 버튼을 눌르면 ui가 활성화 됩니다.
게임매니저에 등록해둔 아이템 데이터가 게임 시작시 인벤토리에 바로 추가되게 해두었습니다.
![image](https://github.com/user-attachments/assets/9a1757a0-8afa-44fd-ae8b-9a296cf740fc)

아이템에 마우스를 올리면 간단한 툴팁이 나오고 클릭을 통해 장착을 할 수 있습니다.
![INVEN-Clipchamp로-제작](https://github.com/user-attachments/assets/382461ae-7b31-4226-b380-57e64ffacac0)
