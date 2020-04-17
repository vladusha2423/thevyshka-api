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
`GET /api/post/all/{page}-{count}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| page  | int  | Номер "страницы" |
| count  | int  | Количество элементов на "странице" |


Ответ: 
```
{
	count: string,
	posts: List<Post>
}
```

- ### Список статей по рубрике

Запрос:
`GET /api/post/category/{categoryId}/{page}-{count}`

| Параметр  | Тип данных  | Значение |
| :------------ | :------------ | :------------ |
| categoryId  | int  | ID необходимой рубрики (см. "Список категорий") |
| page  | int  | Номер "страницы" |
| count  | int  | Количество элементов на "странице" |


Ответ: 
```
{
	count: string,
	posts: List<Post>
}
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
