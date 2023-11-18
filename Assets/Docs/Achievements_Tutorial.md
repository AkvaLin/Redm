# Туториал по Достижениям

## Использование достижений

### Условие

На сцене должен быть `AchievmentsManager`. Если он не появляется в `DontDestroyOnLoad`, то:

* Добавляем на сцену объект с компонентом `AchievmentsManager`, для удобства - с таким же именем.

### Изменение прогресса

1. У `AchievementsManager.Instance` достаем достижение с помощью `GetAchievementOrNull(id)`, где `id` берем из `AchievementsManager.ID` и кастим в `int`:

```csharp
var achievement = AchievementsManager.Instance
    .GetAchievementOrNull((int) AchievementsManager.ID.EXAMPLE);
```

2. У достижения получаем прогресс и кастим в нужный вид прогресса (вид можно узнать, зайдя туда где объявляются достижения - конструктор `AchievementsManager`'a):

```csharp
var progress = (BaseAchievementProgress) achievement.progress;
```

3. Изменяем прогресс, используя соответствующий метод:

```csharp
progress.SetProgress(10); // У BaseAchievementProgress
progress.SetProgress(true); // У FlagAchievementProgress
```

4. Если изменить надо относительно старого прогресса, то используем метод `GetProgress()`

```csharp
progress.SetProgress(progress.GetProgress() + 20);
```


## Добавление достижений

В `AchievementsManager` находим конструктор и инициализацию в нём листа с достижениями:

```csharp
public AchievementsManager()
{
    var achievementsList = new List<Achievement>
    {
        new Achievement(
            (int) ID.TEST_ACHIEVEMENT,  // ID Достижения, добавляем своё в enum ID
            "Test Title",               // Название достижения 
            "Test Description",         // Описание достижения
            // Прогресс, пока есть Base- и Flag- для int и bool
            new BaseAchievementProgress(100), 
            this                        // this, менеджер к которому привязываем достижение
        ),
        ...
```

1. Добавляем свой ID достижения в `enum ID` в этом же классе (короткое название капсом).

2. Добавляем своё достижение в этот список, заполняя поля аналогично примеру выше.
