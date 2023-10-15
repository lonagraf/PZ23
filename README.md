# Спецификация требований 
<h2>1. Функциональные требования</h2>
<h3>1.1. Возможность добавления заявок в базу данных с указанием следующих параметров: </h3>
<li>Номер заявки</li>
<li>Дата добавления</li>
<li>Оборудование, которое требует ремонта</li>
<li>Тип неисправности</li>
<li>Описание проблемы</li>
<li>Клиент, который подал заявку</li>
<li>Статус заявки (в ожидании, в работе, выполнено)</li>
<h3>1.2. Возможность редактирования заявок: </h3>
<li>Изменение этапа выполнения (выполнено, в работе, не выполнено)</li>
<li>Изменение описания проблемы</li>
<li>Изменение ответственного за выполнение работ</li>
<h3>1.3. Возможность отслеживания статуса заявки: </h3>
<li>Отображение списка заявок</li>
<li>Получение уведомлений о смене статуса заявки</li>
<li>Поиск заявки по номеру и параметрам</li>
<h3>1.4 Возможность назначения ответственных за выполнение работ: </h3>
<li>Добавление исполнителя к заявке</li>
<li>Отслеживание состояния работы и получение уведомлений о ее завершении</li>
<li>Исполнитель может добавлять комментарии на форме заявки</li>
<h3>1.5 Расчет статистики работ отдела обслуживания: </h3>
<li>Количество выполненных заявок</li>
<li>Среднее время выполнения заявки</li>
<li>Статистика по типам неисправностей</li>
<h3>1.6 Возможность регистрации заявки: </h3>
<li>Присвоение уникального идентификатора заявке</li>
<li>Сохранение информации о заявке</li>
<li>Приоритет заявки</li>
<h3>1.7 Возможность обработки заявки: </h3>
<li>Уточнение деталей проблемы у клиента</li>
<li>Уточнение деталей проблемы у сотрудника</li>
<li>Назначение исполнителя</li>
<li>Определение приоритетности заявки</li>
<h3>1.8 Ремонт оборудования: </h3>
<li>Заказ запчастей</li>
<li>Координация работ с другими сотрудниками</li>
<li>Информация о затраченных ресурсах (время, материалы, стоимость)</li>
<li>Причина неисправности</li>
<li>Оказанная помощь</li>
<h2>2. Нефункциональные требования</h2>
<h3>2.1 Кроссплатформенность</h3>
<li>Поддержка работы на ОС семейства Windows</li>
<h3>2.2 Безопасность</h3>
<li>Логин и пароль для доступа к приложению</li>
<li>Доступ к данным должен быть ограничен в зависимости от роли пользователя</li>
<h3>2.3 Удобство использования</h3>
<li>Простой и интуитивный интерфейс</li>
<li>Информативные уведомления и подсказки</li>
<h3>2.4 Производительность</h3>
<li>Приложение должно иметь быстрый доступ к данным</li>
<li>Минимальное время отклика на запросы пользователя</li>
<h2>3. Требования к реализации</h2>
<h3>3.1 Язык программирования: C#</h3>
<h3>3.2 СУБД: MySQL</h3>

# ER-диаграмма
![image](https://github.com/lonagraf/PZ23/assets/122952983/6d79244f-eb27-4d97-bfbf-99ea7bf2c5d0)


# Объекты БД
![image](https://github.com/lonagraf/PZ23/assets/122952983/b615f3b6-fb89-4342-8822-ba001b54750b)


