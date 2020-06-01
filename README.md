# Monify

## Виконали студенти 2 курсу ІО-83 ФІОТ Кондрацький Владислав,Мітячкін Денис, Дяченко Владислав

## Про WebAPI 
WEBApi - це серверна сторона, яка написана на мові C# (ASP.NET Core) в якій є многорівнева архітектура (WebApi - Presentation Layer,WEB.ApiBLL - Business Logic Layer, WEBApi.DAL - Data Access Layer)

### WebApi.DAL
В DAL створено дві сущності(таблиці), а саме User та Finance
створено паттерн Repository та UnitOfWork, а також паттерн Disposing і Підключення до бази данних в MonifyContext.

### WebApi.BLL

В BLL створено Services FinanceService та UserService в яких реалізовано CRUD операції, є Exceptions: NotFoundException та ValidationException, AutoMapper для перетворення обьектів з BLL в DAL та навпаки. 

### WebApi.PL
В PL є Startup знаходяться конфігурації сервера в Controllers знаходяться запросы на сервер
