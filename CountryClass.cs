namespace AntiSngEx
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
	
    public class ContryClass
    {
	// Сюда заносим список всех стран для блокировки
	private static List<string> ListContry = new List<string>
        {
            "Russia", "Russ", "Azerbai", "Armen", "Beloru", "Georg", "Kazakhs", "Kyrgyzs",
            "Moldav", "Tajiki", "Turkmeni", "Uzbekis","Ukrai",
        };
		
	// Создаём метод для получения содержимого текста по ссылке
	public static string GetContryFromLink(string link) 
        {
            string status = string.Empty;
            try
            {
                using (var client = new WebClient())
                {
                    client.Proxy = null; // Не устанавливаем Прокси
                    if (!client.IsBusy) // Если не веб запрос
                    {
                        status = client.DownloadString(new Uri(link)); // То получаем данные
                    }
                }
            }
            catch { }
            return status; // Возарвщяем данные в виде строки
        }
		
	// Метод для проверки стран
	public static bool CheckContry()
        {
            string server = GetContryFromLink("http://ip-api.com/line/?fields=country"); // Получаем страну онлайн
            foreach (string list in ListContry) // Проходимся по списку List<string> ListContry
            {
                if (!server.Contains(list)) // Сверяем данные с сервера и списка ListContry
                {
                    return false;
                }
                break;
            }
            return true;
        }
    }
}
