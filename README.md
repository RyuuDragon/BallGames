# 🎱 BallGames — Сборник игр с мячами на Windows Forms

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)]()
[![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![WinForms](https://img.shields.io/badge/WinForms-5C2D91?style=for-the-badge&logo=.net&logoColor=white)]()
[![ООП](https://img.shields.io/badge/ООП-наследование-blue?style=for-the-badge)]()

> Сборник из 7 игр с мячами, реализованных на C# и Windows Forms. В решении — общая библиотека с физикой движения мячей, отскоками и гравитацией, а также отдельные игры, построенные на её основе. Отрисовка в некоторых играх переделана на событие `Paint` для устранения мерцания.

---

## 🎮 Какие игры в сборнике

| Игра | Механика |
|---|---|
| 🎱 **BilliardBalls** | Бильярдные шары с отскоками от стен, подсчёт ударов по каждой стороне |
| 🔴🔵 **Diffusion** | Красно-синие шары. Цель — дождаться равномерного распределения по половинам экрана |
| 🐦 **AngryBirds** | Птица летит в свинью: прицеливание кликом, физика с гравитацией и отскоками |
| 🍎 **FruitNinja** | Разрезание фруктов свайпом мыши. Бомбы, бананы с замедлением, половинки фруктов |
| 🎆 **Firework** | Фейерверк: запуск ракеты по клику, взрыв на множество цветных шаров |
| 🎯 **BallCatcher** | Ловля шаров кликом мыши. Случайное количество (5–25), счёт по пойманным |
| 🔵 **BallGame** | Случайно летящие шары. Кнопка «Стоп» — счёт по оставшимся на форме |

---

## 🧱 Архитектура решения

<img width="501" height="994" alt="image" src="https://github.com/user-attachments/assets/668c9516-49a1-43b8-8af4-7670a73e92c1" />

```

BallGames/
├── BallGames.Common/               # Общая библиотека классов
│   ├── Ball.cs                     # Базовый класс: таймер, движение, отрисовка, границы
│   ├── RandomSizeAndPointBall.cs   # Наследник: случайный размер и стартовая позиция
│   ├── RandomMoveBall.cs           # Наследник: случайный вектор скорости
│   ├── BilliardBall.cs             # Наследник: отскоки от стен + событие Hit
│   ├── HitEventArgs.cs             # Аргументы события удара о стену (сторона)
├── BilliardBallsWinFormsApp/       # Бильярдные шары
├── DiffusionWinFormsApp/           # Диффузия
├── AngryBirdsWinFormsApp/          # Angry Birds (Bird.cs, Pig.cs)
├── FruitNinjaWinFormsApp/          # Fruit Ninja (FruitBall.cs, BombBall.cs, BananBall.cs, CutBall.cs)
├── FireworkWinFormsApp/            # Фейерверк (RocketBall.cs, FireworkBall.cs)
├── BallCatcher/                    # Ловля шаров кликом
└── BallGameWinFormsApp/            # Случайные шары + кнопка «Стоп»

```

### Иерархия наследования в BallGames.Common

```

Ball (база: таймер, Move, Draw, проверка границ)
└── RandomSizeAndPointBall (случайный радиус и позиция)
├── RandomMoveBall (случайный вектор vx, vy)
│     ├── BilliardBall (отскоки + событие Hit)
│     ├── Bird (Angry Birds: гравитация, прицеливание, столкновение с Pig)
|     └── FruitBall
|            ├── BananBall
|            ├── BombBall
|            ├── CutBall
└── Pig (статичная цель для Angry Birds)

```

Все игры используют эту библиотеку. Чтобы добавить новую игру, достаточно создать новый класс-наследник и форму — физика уже готова.

### Переход на событие Paint

Изначально шары отрисовывались через `CreateGraphics()` прямо в методе `Move()`. Это вызывало мерцание и не использовало стандартный цикл перерисовки Windows Forms. В проектах BilliardBall, Diffusion, AngryBirds, FruitNinja и Firework отрисовка была переделана на **событие `Paint`**:

```csharp
// Было (внутри Ball.Move):
private void Show()
{
    var graphics = _form.CreateGraphics();
    graphics.FillEllipse(brush, rectangle);
}

// Стало (форма подписывается на Paint):
private void MainForm_Paint(object sender, PaintEventArgs e)
{
    foreach (var ball in _balls)
    {
        ball.Draw(e.Graphics);  // рисуем через Graphics из PaintEventArgs
    }
}
```

буферизации и устранения мерцания в конструкторе формы добавлено:

```csharp
SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
UpdateStyles();
```

А перерисовка запускается вызовом Invalidate() в таймере — Windows сама вызывает Paint в нужный момент.

---

🔑 Ключевые фрагменты кода

Базовый класс Ball

```csharp
public class Ball
{
    protected readonly Form _form;
    protected float centerX = 100, centerY = 100;
    protected int radius = 35;
    protected float vx = 10, vy = 15;
    private readonly Timer _timer;

    public Ball(Form form)
    {
        _form = form;
        _timer = new Timer { Interval = 10 };
        _timer.Tick += Timer_Tick;
    }

    public virtual void Move()
    {
        Clear();
        Go();
        Show();
    }

    protected virtual void Go()
    {
        centerX += vx;
        centerY += vy;
    }

    public bool IsVisible(int pointX, int pointY)
    {
        return Math.Pow(centerX - pointX, 2) + Math.Pow(centerY - pointY, 2) <= Math.Pow(radius, 2);
    }

    public bool OnForm()
    {
        return !IsLeft() && !IsRight() && !IsTop() && !IsBottom();
    }

    public bool IsLeft()   => centerX <= radius;
    public bool IsRight()  => centerX >= _form.ClientSize.Width - radius;
    public bool IsTop()    => centerY <= radius;
    public bool IsBottom() => centerY >= _form.ClientSize.Height - radius;

    public void Start() => _timer.Start();
    public void Stop()  => _timer.Stop();
    public bool IsNotStop() => _timer.Enabled;

    // Публичный метод для отрисовки через Paint
    public void Draw(Graphics graphics)
    {
        var rectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
        graphics.FillEllipse(brush, rectangle);
    }
}
```

Отскоки в BilliardBall

```csharp
protected override void Go()
{
    base.Go();
    
    if (IsLeft())
    {
        centerX = radius;
        vx = -vx;
        Hit?.Invoke(this, new HitEventArgs(Side.Left));
    }
    if (IsRight())
    {
        centerX = _form.ClientSize.Width - radius;
        vx = -vx;
        Hit?.Invoke(this, new HitEventArgs(Side.Right));
    }
    if (IsTop())
    {
        centerY = radius;
        vy = -vy;
        Hit?.Invoke(this, new HitEventArgs(Side.Top));
    }
    if (IsBottom())
    {
        centerY = _form.ClientSize.Height - radius;
        vy = -vy;
        Hit?.Invoke(this, new HitEventArgs(Side.Bottom));
    }
}
```

Гравитация в Angry Birds (Bird.Go)

```csharp
protected override void Go()
{
    base.Go();

    if (!IsHit && CheckCollisionWith())
    {
        vx = -Math.Abs(vx) * DecreaseSpeed;
        IsHit = true;
    }

    if (IsBottom())
    {
        vy = -Math.Abs(vy) * DecreaseSpeed;

        if (Math.Abs(vy) < StopThreshold && Math.Abs(vx) < StopThreshold)
        {
            vx = 0;
            vy = 0;
            IsStopped = true;
            _timer.Stop();
            return;
        }

        if (Math.Abs(vx) < StopThreshold * 2)
            vx = 0;
        else
            vx *= DecreaseSpeed;
    }

    vy += G;
}

private bool CheckCollisionWith()
{
    double dx = centerX - Pig.CenterX;
    double dy = centerY - Pig.CenterY;
    double distance = Math.Sqrt(dx * dx + dy * dy);
    return distance <= radius + Pig.Radius;
}
```

Разрезание фруктов в Fruit Ninja

```csharp
private void ProcessCuttingBalls(int pointX, int pointY)
{
    for (int i = _fruitBalls.Count - 1; i >= 0; i--)
    {
        var fruit = _fruitBalls[i];
        if (fruit.IsVisible(pointX, pointY))
        {
            var firstHalf  = new CutBall(this, pointX, pointY, fruit.GetRadius(), fruit.GetColor(),  2);
            var secondHalf = new CutBall(this, pointX, pointY, fruit.GetRadius(), fruit.GetColor(), -2);
            _cutBalls.AddRange(firstHalf, secondHalf);

            result++;
            resultLabel.Text = $"Результат: {result}";

            _fruitBalls.RemoveAt(i);
        }
    }

    f


for (int i = _bombBalls.Count - 1; i >= 0; i--)
    {
        if (_bombBalls[i].IsVisible(pointX, pointY))
        {
            RestartGame();
            break;
        }
    }

    for (int i = _bananBalls.Count - 1; i >= 0; i--)
    {
        var banan = _bananBalls[i];
        if (banan.IsVisible(pointX, pointY))
        {
            SlowDownSpeed();
            _slowSpeedDownTimer.Start();

            var firstHalf  = new CutBall(this, pointX, pointY, banan.GetRadius(), banan.GetColor(),  2);
            var secondHalf = new CutBall(this, pointX, pointY, banan.GetRadius(), banan.GetColor(), -2);
            _cutBalls.AddRange(firstHalf, secondHalf);

            result++;
            resultLabel.Text = $"Результат: {result}";

            _bananBalls.RemoveAt(i);
        }
    }
}
```

---

🚀 Как запустить

Что нужно: .NET SDK 10.0 или свежее.

```bash
git clone https://github.com/RyuuDragon/BallGames.git
cd BallGames/НазваниеПапкиСИгрой
dotnet run
```

Или откройте BallGames.sln в Visual Studio, выберите нужный проект как запускаемый и нажмите F5.

---

🖼️ Как это выглядит

Сделайте скриншоты каждой игры и замените заглушки

| Billiard | Diffusion | Angry Birds |
|---|---|---|
| <img width="826" height="538" alt="Billiard" src="https://github.com/user-attachments/assets/f5b56864-aabe-46ee-87eb-df4a06c29315" /> | <img width="830" height="544" alt="Diffusion" src="https://github.com/user-attachments/assets/3362f01a-9043-4bad-a6cc-f919057e1a4e" /> | <img width="824" height="636" alt="AngryBirds" src="https://github.com/user-attachments/assets/f1179d8d-5f0b-4e81-b044-9cdb93e5074b" /> |

| Fruit Ninja | Firework | BallCatcher |
|---|---|---|
| <img width="794" height="748" alt="FruitNinja" src="https://github.com/user-attachments/assets/ee61d6f9-258b-4990-a0eb-e0730ff34091" /> | <img width="798" height="446" alt="Firework" src="https://github.com/user-attachments/assets/a3785272-d9ac-4cdb-aaac-527118e69a32" /> | <img width="974" height="640" alt="Catcher" src="https://github.com/user-attachments/assets/086f47ef-f4db-4fec-877e-829c320702c2" /> |

---

🛠️ Технологии и чему я научился

Стек

Категория Что использовал
Язык C#
Платформа .NET 10.0
Интерфейс Windows Forms (WinForms)
Графика Graphics, FillEllipse, DrawLine, двойная буферизация, событие Paint
Среда разработки Visual Studio
Контроль версий Git, GitHub

Что применял в коде

· ООП и наследование — иерархия из 5 классов: Ball → RandomSizeAndPointBall → RandomMoveBall → BilliardBall / Bird / Pig. Каждая игра расширяет базовые классы под свою механику.
· Полиморфизм — ключевой принцип, на котором держится всё решение:
    - Переопределение методов
    - Единый интерфейс для всех шаров: методы `Start()`, `Stop()`, `IsVisible()`, `OnForm()`, `IsNotStop()` работают одинаково для любого наследника. Это позволяет форме управлять списком `List<Ball>` (или `List<RandomMoveBall>`), не различая конкретные типы шаров.
· События C# — event EventHandler<HitEventArgs> Hit для оповещения формы об ударе шара о стену.
· Таймеры — System.Windows.Forms.Timer для игрового цикла (10 мс), спавна объектов (500 мс – 20 с), эффекта замедления.
· Отрисовка через Paint — вся графика вынесена в обработчик OnPaint / Paint. Двойная буферизация через SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true) и Invalidate() для перерисовки.
· Физика движения — векторы скорости vx/vy, гравитация G, затухание при отскоках, формула столкновения через расстояние между центрами.
· Рисование через Graphics — FillEllipse для шаров, DrawLine для следа разреза в Fruit Ninja.
· Линейный поиск и перебор — проверка попадания клика через IsVisible(), поиск упавших шаров через OnForm(), фильтрация по половинам экрана в Diffusion.
· Работа с коллекциями — List<T>, удаление в обратном цикле for (int i = list.Count - 1; i >= 0; i--), AddRange().

---
