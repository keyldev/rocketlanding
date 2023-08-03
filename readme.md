<p align="center">
<image src="https://img.shields.io/badge/version-1.0_final-blue"/>
</p>

# [RU](#rus-проект-«управляемая-посадка-ракеты-на-луну») | [EN](#en-project-guided-rocket-landing-on-the-moon)

## [RUS] Проект: «Управляемая посадка ракеты на Луну» 🚀

### Цель: «Управляемая посадка ракеты на Луну»

Физическая модель:

Нам необходимо учесть силу тяжести и силу реактивной тяги. Также, переменный характер величины расхода топлива. Исходными данными задачи являются: масса топлива, масса оболочки ракеты, ускорение свободного падения, скорость истечения струи (выброса топлива), начальная высота, разрешенная посадочная скорость, максимальный массовый расход топлива.

    aMesh = fuelSpeed * (trust / (rocketMass + fuel));

Программа реализована с использованием языка программирования C# и WPF. При проектировании программы использовался паттерн MVVM это позволило заложить фундамент для масштабируемости приложения. MVVM работает при помощи интерфейса INotifyPropertyChanged, который позволяет отслеживать изменение свойства у модели, и в «реалтайм» выводит это значение на экран, таким образом реализовано считывание данных с полей, а также вывода результата на экран, в программе также реализован таймер. Программа работает на версии .Net Framework 4.7.2.
<p align="center">
    <image src="img/img_1.png" width="720"/>
</p>
Приложение состоит из нескольких частей, а именно:

1.	Панель управления. В ней вводятся исходные данные, запускается программа (путем нажатия на кнопку «Старт»), остановка программы («Стоп»), а также вывод графиков (рисунок 2) (т.к. графики выводят информацию в режиме реального времени при работе программы, их просмотр является не очень удобным).
<p align="center">
    <image src="img/img_2.png" width="720"/>
</p>

2.	Графики. Графики, выводятся в реальном времени.
<p align="center">
    <image src="img/img_3.png" width="720"/>
</p>

3.	Вывод данных. В данной области, показываются вся информация, выводимая ракетой. Также есть область «игры», где происходит простенькая 2D анимация посадки ракеты. В случае успешной посадки, пользователю будет выведено соответствующее окно.

4.	Область логов. Техническая часть приложения.

5.	Область управления. Управление производится путем перемещения слайдера или при помощи стрелок клавиатуры, где стрелки вверх, вниз – отвечают за расход топлива, стрелки влево-вправо отвечают за время работы программы.

## [EN] Project: "Guided rocket landing on the Moon" 🚀
### Goal: "Guided rocket landing on the Moon"

Physical model:

We need to take into account gravity and jet propulsion. Also, the variable nature of the fuel consumption value. The initial data of the task are: the mass of fuel, the mass of the rocket shell, the acceleration of free fall, the velocity of the jet (fuel ejection), the initial altitude, the permitted landing speed, the maximum mass fuel consumption.

    aMesh = fuelSpeed * (trust / (rocketMass + fuel));

The program is implemented using the C# and WPF programming languages. When designing the program, the MVVM pattern was used, which allowed laying the foundation for the scalability of the application. MVVM works using the INotifyPropertyChanged interface, which allows you to track a property change in the model, and displays this value on the screen in "realtime", thus reading data from fields is implemented, as well as displaying the result on the screen, the program also implements a timer. The program works on the version .Net Framework 4.7.2.
<p align="center">
    <image src="img/img_1.png" width="720"/>
</p>
The application consists of several parts, namely:

1. Control panel. The initial data is entered in it, the program is started (by pressing the "Start" button), the program is stopped ("Stop"), as well as the output of graphs (Figure 2) (because graphs display information in real time when the program is running, viewing them is not very convenient).
<p align="center">
    <image src="img/img_2.png" width="720"/>
</p>

2. Charts. Graphs are displayed in real time.
<p align="center">
 <image src="img/img_3.png" width="720"/>
</p>

3. Data output. In this area, all the information displayed by the rocket is shown. There is also a "game" area where a simple 2D animation of a rocket landing takes place. In case of successful landing, the corresponding window will be displayed to the user.

4. The area of logs. The technical part of the application.

5. Control area. The control is performed by moving the slider or using the keyboard arrows, where the up and down arrows are responsible for fuel consumption, the left and right arrows are responsible for the running time of the program.
