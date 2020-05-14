# The Vyshka API

## Статьи

#### Post(Статья):
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

- ### Список опубликованных статей

Запрос:
`GET /api/post/all/{begin}-{end}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| begin  | int  | С какого по счету элемента |
| end  | int  | По какой элемент |


Ответ: 
```
{
	count: string,
	posts: List<Post>
}
```

- ### Список статей по ID

Запрос:
`GET /api/post/id/{id}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| id  | int  | ID публикации |
| begin  | int  | С какого по счету элемента |
| end  | int  | По какой элемент |


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
	count: string,
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
	count: string,
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
	count: string,
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


Ответ: 
```
Object<Post>
```

## Рубрики
#### Category(Рубрика):
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
List<Category>
```
