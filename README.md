# The Vyshka API

## Статьи

- ### Объект Post(Статья):
```
{
  "id": int,
  "title": string,
  "description": string,
  "date": "0001-01-01T00:00:00",
  "modifiedDate": "0001-01-01T00:00:00",
  "status": string,
  "viewType": string,
  "linkName": string,
  "image": string,
  "podcast": string,
  "content": string,
  "viewCount": int
}
```
| Аргумент  | Значение |
| :------------ | :------------ |
| title  | Заголовок статьи |
| description  | Описание статьи |
| date  | Дата создания |
| modifiedDate  | Дата последнего изменения |
| status  | Статус (published/draft) |
| viewType  | Тип отображения превью на главной странице (in dev) |
| linkName  | С какого по счету элемента |
| image  | Ссылка на изображение(баннер) |
| podcast  | Ссылка на подкаст (если таковой имеется) |
| content  | Контент статьи (html разметка) |
| viewCount  | Количество просмотров |


- ### Список опубликованных статей

Запрос:
`GET /api/post/{selection}/{begin}-{end}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| selection  | string  | Набор статей (all/published/draft) |
| begin  | int  | С какого по счету элемента |
| end  | int  | По какой элемент |


Ответ: 
```
{
	count: int,
	posts: List<Post>
}
```

- ### Статья по ID

Запрос:
`GET /api/post/id/{id}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| id  | int  | ID публикации |


Ответ: 
```
Object<Post>
```
- ### Список статей по ID рубрики

Запрос:
`GET /api/post/category/{categoryId}/{begin}-{end}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| categoryId  | int  | ID необходимой рубрики (см. "Список категорий") |
| begin  | int  | С какого по счету элемента |
| end  | int  | По какой элемент |


Ответ: 
```
{
	count: int,
	posts: List<Post>
}
```


- ### Список статей по ID пользователя

Запрос:
`GET /api/post/collab/{collabId}/{begin}-{end}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| collabId  | int  | ID участника (см. "Список участников") |
| begin  | int  | С какого по счету элемента |
| end  | int  | По какой элемент |


Ответ: 
```
{
	count: int,
	posts: List<Post>
}
```



- ### Список статей по ID тега

Запрос:
`GET /api/post/tag/{tagId}/{begin}-{end}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| tagId  | int  | ID тега (см. "Список тегов") |
| begin  | int  | С какого по счету элемента |
| end  | int  | По какой элемент |


Ответ: 
```
{
	count: int,
	posts: List<Post>
}
```



- ### Поиск статей по названию

Запрос:
`GET /api/post/search/{search}/{begin}-{end}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| search  | string  | Строка запроса |
| begin  | int  | С какого по счету элемента |
| end  | int  | По какой элемент |


Ответ: 
```
{
	count: int,
	posts: List<Post>
}
```

- ### Добавление статьи

Запрос:
`Post /api/post/`

Тело запроса:
```
{
  "title": string,
  "description": string,
  "date": "0001-01-01T00:00:00",
  "modifiedDate": "0001-01-01T00:00:00",
  "status": string,
  "viewType": string,
  "linkName": string,
  "image": string,
  "podcast": string,
  "content": string,
  "viewCount": int
}
```



Ответ: 
```
Object<Post>
```


- ### Изменение статьи

Запрос:
`Put /api/post/`

Тело запроса:
```
{
  "id": int,
  "title": string,
  "description": string,
  "date": "0001-01-01T00:00:00",
  "modifiedDate": "0001-01-01T00:00:00",
  "status": string,
  "viewType": string,
  "linkName": string,
  "image": string,
  "podcast": string,
  "content": string,
  "viewCount": int
}
```


Ответ: 
```
Boolean(true/false)
```

- ### Удаление статьи

Запрос:
`Delete /api/post/{id}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| Id  | int  | ID публикации которую надо удалить |


Ответ: 
```
Boolean(true/false)
```

## Теги

- ### Объект Tag(Тег):
```
{
  "id": int,
  "name": string
}
```

- ### Список тегов

Запрос:
`GET /api/tag/{begin}-{end}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| begin  | int  | С какого по счету элемента |
| end  | int  | По какой элемент |


Ответ: 
```
{
	count: int,
	tags: List<Tag>
}
```

- ### Тег по ID

Запрос:
`GET /api/tag/{id}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| id  | int  | ID публикации |


Ответ: 
```
Object<Tag>
```


- ### Добавление тега

Запрос:
`Post /api/tag/`

Тело запроса:
```
{
  "name": string
}
```


Ответ: 
```
Object<Tag>
```


- ### Изменение тега

Запрос:
`Put /api/tag/`

Тело запроса:
```
{
  "id": int, 
  "name": string
}
```


Ответ: 
```
Boolean(true/false)
```

- ### Удаление тега

Запрос:
`Delete /api/tag/{id}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| Id  | int  | ID тега который надо удалить |


Ответ: 
```
Boolean(true/false)
```

## Участники организации

- ### Объект Collaborator(Участник):
```
{
  "id": int,
  "name": string,
  "role": string,
  "date": datetime,
  "photo": string,
  "description": string,
  "links": string
}
```
| Аргумент  | Значение |
| :------------ | :------------ |
| id  | Id участника |
| name  | Имя участника |
| role  | Роль участника |
| date  | Дата первого участия |
| photo  | Ава участника |
| description  | Описание участника |
| links  | Сслыка на ВК (in dev) |

- ### Список участников

Запрос:
`GET /api/collab/{begin}-{end}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| begin  | int  | С какого по счету элемента |
| end  | int  | По какой элемент |


Ответ: 
```
{
	count: string,
	tags: List<Collaborator>
}
```

- ### Участник по ID

Запрос:
`GET /api/collab/{id}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| id  | int  | ID участника |


Ответ: 
```
Object<Collab>
```


- ### Добавление участника

Запрос:
`Post /api/collab/`

Тело запроса:
```
{
  "name": string,
  "role": string,
  "photo": string,
  "date": datetime,
  "description": string,
  "links": string
}
```


Ответ: 
```
Object<Collaborator>
```


- ### Изменение тега

Запрос:
`Put /api/collab/`

Тело запроса:
```
{
  "id": int,
  "name": string,
  "role": string,
  "photo": string,
  "date": datetime,
  "description": string,
  "links": string
}
```


Ответ: 
```
Boolean(true/false)
```

- ### Удаление участника

Запрос:
`Delete /api/collab/{id}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| Id  | int  | ID участника который надо удалить |


Ответ: 
```
Boolean(true/false)
```

## Рубрики

- ### Объект Category(Рубрика):
```
{
  "id": int,
  "name": string
}
```

- ### Список рубрик

Запрос:
`GET /api/category/`


Ответ: 
```
{
	count: string,
	tags: List<Category>
}
```

- ### Рубрика по ID

Запрос:
`GET /api/category/{id}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| id  | int  | ID рубрики |


Ответ: 
```
Object<Сategory>
```


- ### Добавление рубрики

Запрос:
`Post /api/category/`

Тело запроса:
```
{
  "name": string
}
```


Ответ: 
```
Object<Category>
```


- ### Изменение рубрики

Запрос:
`Put /api/category/`

Тело запроса:
```
{
  "id": int, 
  "name": string
}
```


Ответ: 
```
Boolean(true/false)
```

- ### Удаление тега

Запрос:
`Delete /api/category/{id}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| Id  | int  | ID рубрики которую надо удалить |


Ответ: 
```
Boolean(true/false)
```

## Авторизация

- ### Объект User(Пользователь):
```
{
    "id": int,
    "name": string,
    "surname": string,
    "email": string,
    "password": string,
}
```
| Аргумент  | Значение |
| :------------ | :------------ |
| id  | Id пользователя |
| name  | Имя пользователя |
| surname  | Фамилия пользователя |
| email  | email )) |
| password  | Пароль |


- ### Список пользователей

Запрос:
`GET /api/user/`


Ответ: 
```
List<User>
```


- ### Добавление  пользователя

Запрос:
`Post /api/register/`

Тело запроса:
```
{
    "name": "Vlados",
    "surname": "Dmitriev",
    "email": "dvv2423@ya.ru",
    "password": "12345qwert"
}
```


Ответ: 
```
JWT (token)
```

- ### Добавление  пользователя

Запрос:
`Post /api/login/`

Тело запроса:
```
{
    "email": "dvv2423@ya.ru",
    "password": "12345qwert"
}
```


Ответ: 
```
JWT (token)
```


- ### Удаление  пользователя

Запрос:
`Post /api/user/{id}`

| Аргумент  | Значение |
| :------------ | :------------ |
| id  | Id пользователя |


Ответ: 
```
Boolean(true/false)
```


- ### Изменение роли пользователя

Запрос:
`Post /api/user/role/{role}/{userId}`

| Аргумент  | Значение |
| :------------ | :------------ |
| role  | роль (admin/editor) |
| userId  | Id пользователя |


Ответ: 
```
Boolean(true/false)
```
