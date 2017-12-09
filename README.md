## Демонстрация работы Microsoft Bot Framework с Cognitive Services

### План занятия
1. Рассказ о чат ботах и их возможностях
1. Рассказ о Microsoft Cognitive Services
1. Подготовка рабочего места
    1. Установка эмулятора 
    1. Установка шаблона
    1. Скачивание репозитория 
1. Создание эхо бота и тестирование его на эмуляторе
1. Определение количества людей на фотографии
1. Получение информации о человеке на фото (Пол, возраст)
1. Расширенный вывод информации о человеке (цвет волос, настроение, макияж)
1. Публикация бота в интернете

### Дополнительные материалы
* [Create a bot with the Bot Builder SDK for .NET](https://docs.microsoft.com/en-us/bot-framework/dotnet/bot-builder-dotnet-quickstart)
* [Getting Started with Face API in C# Tutorial](https://docs.microsoft.com/ru-ru/azure/cognitive-services/face/tutorials/faceapiincsharptutorial)
* [Microsoft Project Oxford Habrahabr](https://habrahabr.ru/company/microsoft/blog/263635/)
* [Cognitive-Face-Windows Samples](https://github.com/Microsoft/Cognitive-Face-Windows)
* [MS ModernAI Примеры кода AI](https://github.com/evangelism/ModernAI)
* [Microsoft Bot Framework](https://dev.botframework.com/)
* [BotFramework Emulator](https://github.com/Microsoft/BotFramework-Emulator/releases/)
* [NuGet Face API](https://www.nuget.org/packages/Microsoft.ProjectOxford.Face/)
* [Slides of master class](https://www.slideshare.net/ssuser147b88/ss-83742507)

### Установка шаблона бота
Скачайте файлы [Bot Application](http://aka.ms/bf-bc-vstemplate), [Bot Controller](http://aka.ms/bf-bc-vscontrollertemplate), и [Bot Dialog](http://aka.ms/bf-bc-vsdialogtemplate).

> **Установка:**
> - Файл **Bot Application.zip** нужно скопировать в папку `%USERPROFILE%\Documents\Visual Studio %VERSION%\Templates\ProjectTemplates\Visual C#\`
> - Файлы **Bot Controller.zip** и **Bot Dialog.zip** нужно скопировать в папку `%USERPROFILE%\Documents\Visual Studio %VERSION%\Templates\ItemTemplates\Visual C#\`
