# GardenOfDreamsTestTask
[Core](https://github.com/fan747/GardenOfDreamsTestTask/tree/main/Assets/_Project/Scripts/Core) - сервисы и стейт машина игры

[GameEntryPoint.cs](https://github.com/fan747/GardenOfDreamsTestTask/blob/main/Assets/_Project/Scripts/Core/GameEntryPoint.cs) - старт игры ( создание стейт машины игры )

[States](https://github.com/fan747/GardenOfDreamsTestTask/tree/main/Assets/_Project/Scripts/Core/StateMachine/States) - Два стейта бутстрап - загрузка всего и геймплей - запуск стейт машины геймплей сцены

[Building](https://github.com/fan747/GardenOfDreamsTestTask/tree/main/Assets/_Project/Scripts/Gameplay/Building) - данные о постройке

[BuildingGrid](https://github.com/fan747/GardenOfDreamsTestTask/tree/main/Assets/_Project/Scripts/Gameplay/BuildingGrid) - данные о сетке построек

[StateMachine](https://github.com/fan747/GardenOfDreamsTestTask/tree/main/Assets/_Project/Scripts/Gameplay/StateMachine) - стейт машина сцены. Состояния - бутстрап, плейс, реплей, сохранение

[Gameplay](https://github.com/fan747/GardenOfDreamsTestTask/tree/main/Assets/_Project/Scripts/Gameplay) - остальные скрипты для юнити, PlacementController.cs отвечает за отображения, и работу с данными BuildingGrid, TileMapRenderer красит поля строительства в узор

Переключение режимов работы в [GameplayState.cs](https://github.com/fan747/GardenOfDreamsTestTask/blob/main/Assets/_Project/Scripts/Core/StateMachine/States/GameplayState.cs) через евенты

Добавление предметов в Resources BuildingItemsConfig, можно добавить иконку ( опционально ), префаб, размер, префаб иконки для UI.

Видео - https://disk.yandex.ru/i/E4AcGCNjJ6uodw
