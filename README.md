# AspWithWCF
## Описание
Минималистичный пример использования приложения на ASP.NET Core в связке с WCF
и консольным .NET клиентом веб-службы.
## Установка
Выполните эту команду в командной строке Windows:
'''bash
git clone https://github.com/xamar-sharp/AspWithWCF.git
'''
## Использование
1.	Перейдите в папку AspWithWCF/AspWithWCF и выполните в консоли команду
	для запуска веб-службы локально:
	'''bash 
	dotnet run
	'''
2.	В своем C# проекте установите nuget-пакет System.ServiceModel.Http
3.	Объявите такой интерфейс:
	'''C#
	[ServiceContract]
	public interface IOSStatePresentor
	{
		[OperationContract]
		string GetState(bool detailed);
	}
	'''
4.	Теперь вы можете обратиться к раннее запущенной веб-службе WCF:
	'''C#
		var httpBinding = new System.ServiceModel.BasicHttpBinding();
		var endpoint = new System.ServiceModel.EndpointAddress("http://localhost:5000/EnvironmentOSStatePresentor/basichttp");
		var channelFactory = new ChannelFactory<IOSStatePresentor>(httpBinding, endpoint);
		var client = channelFactory.CreateChannel();
		Console.WriteLine(client.GetState(true));
	'''
Выше представлена минималистичная реализация клиента веб-службы,
реаизацию которой вы можете найти в папке WcfClient.
## Лицензия 
MIT