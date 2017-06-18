# ИАДиП 2017 Архиреев Солдаткин
Первым шагом при проведении исследования является загрузка исходных данных. Для этого в главном меню необходимо выбрать "Загрузить". Главное меню представлено на рисунке ниже:

![Image mainmenu](screenshots/mainmenu.png)

После этого необходимо выбрать файл с исходными данными:

![Image load](screenshots/load.png)

После того как файл был выбран, необходимо нажать "Кластеризация" в главном меню. После завершения процесса кластеризации можно посмотреть её результаты. Кнопка "Все данные" показывает разделение объектов по кластерам и центры кластеров.

![Image tableAll](screenshots/tableAll.png)

Кнопка "Сводка" показывает данные по каждому из кластеров и таблицу с лингвистическими оценками.

![Image summary](screenshots/summary.png)

Функция "Граф" позволяет визуально оценить результаты кластеризации. При построении графа есть возможность изменять отображаемые значения по осям.

![Image graph](screenshots/graph.png)

Для выполнения оценки апартамента необходимо нажать "Оценить". После этого необходимо ввести стоимость в появившемся окне.

![Image enter](screenshots/enter.png)

После этого необходимо нажать "Найти". В результате будет выведена информация по подобранному кластеру, который оказался ближе всего к заданной цене. В окне содержится информация о центре кластера, а также точечные и интервальные оценки параметров апартамента.

![Image result](screenshots/result.png)

# Ограничения:
## Формат файла загрузки
Загрузке подлежат файлы .tsv
Пример входного файла: https://github.com/RikkiRu/iadip_apartments_kmeans/blob/master/iadip/iadip/SourceFile.tsv
## Файл локализации
Программа требует файл Localization.txt рядом с исполняемым файлом .exe

Файл локализации: https://github.com/RikkiRu/iadip_apartments_kmeans/blob/master/iadip/iadip/bin/Debug/Localiztion.txt

Локализация представляет собой строки типа <ключ>_<значение> - символ '_' разделитель

Номер параметра объекта должен соответствовать столбу в загружаемом файле

В приведенном примере локализации введены параметры
* paramname.1_P1 Цена
* paramname.2_P2 Площадь
* paramname.3_P3 Комнаты
* paramname.4_P4 Ванные
Первый параметр в программе используется для поиска ближайшего кластера

Лингвистическая оценка настраивается строками вида (для параметра номер 1)
param.lingv.1.split.1_0.3
param.lingv.1.split.2_0.7
param.lingv.1.word.1_Дёшево
param.lingv.1.word.2_Нормально
param.lingv.1.word.3_Дорого

* Если значение попало в меньшую треть, выдаётся word.1
* Если в большую word.3
* Иначе word.2

Параметр param.kmeans.elemsPerCluster отвечает за **ориентировочное** число элеменов в 1 кластере. На его основе выбирается число кластеров.