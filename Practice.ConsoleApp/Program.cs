using Ans.Net10.Common;
using Practice.ConsoleApp.Models;
using System.Text;
using System.Xml.Linq;

namespace Practice.ConsoleApp
{

    //public static void PrepodaArray(string[] prep)
    //    {
    //        foreach (var element1 in obj1.Subject)
    //        {

    //            if (element1.Id_prep?.Length > 1)
    //            {
    //                Console.Write($"Дата: {element1.DayRaw} = {element1.Day} ");
    //                Console.Write($"Преподы: {string.Join(",", element1.Id_prep)}");
    //                Console.WriteLine();
    //            }


    //        }
    //    }



    // Дату изменить тип значения на Date.Time
    // Изменить тип значения для Id_group и Id_prep, чтобы можно было вывести их как Int(подсказка: нужно выводить их как массив данных)
    /* https://translated.turbopages.org/proxy_u/en-ru.ru.8559a855-6a198994-7364fb80-74722d776562/https/stackoverflow.com/questions/20646278/split-field-value-from-xml-string-not-formatted */

    public class Program
    {



        static void Main()
        {



            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using var client1 = new HttpClient();
            string url1 = "https://guap.ru/content/rasp/exam/current.xml";


            string data1 = client1.GetStringAsync(url1).Result;

            var obj1 = SuppXml.GetObjectFromXml<RaspModel>(data1);

            var preps1 = new List<PrepModel>();
            var group1 = new List<GroupModel>();

            foreach (var element1 in obj1.Subject)
            {
                Console.Write(element1.Day + " ");
                if (element1.PrepIds?.Length > 0)


                    for (int i1 = 0; i1 < ; })

                    foreach (var prep1 in element1.PrepIds)
                    {
                        Console.Write(prep1 + ", ");
                    }
                Console.WriteLine();
            }


            Console.ReadLine();

        }






        static void OutItem(
          SubjectModel item)
        {
            Console.WriteLine($"Дата: {item.DayRaw} = {item.Day}");
            Console.Write($"   Преподы: {item.PrepIds.MakeFromCollection(x => x.ToString(), "[{0}]", null, ", ")} ");
            Console.WriteLine(item.PrepNames.MakeFromCollection(x => x, null, "\"{0}\"", ", "));
            Console.Write($"   Группы: {item.GroupIds.MakeFromCollection(x => x.ToString(), "[{0}]", null, ", ")} ");
            Console.WriteLine(item.GroupNames.MakeFromCollection(x => x, null, "\"{0}\"", ", "));
        }


    }


}






