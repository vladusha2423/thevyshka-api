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

- ### Список статей по рубрике

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
