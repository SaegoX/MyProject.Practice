using Ans.Net10.Common;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Practice.ConsoleApp
{

    [XmlRoot("rasp")]
    public class RaspModel
    {
        [XmlElement("subject")]
        public SubjectModel[] Subject { get; set; }
    }


    public class SubjectModel
    {

        /* serialization properties */

        [XmlAttribute("IDSubg")]
        public string IDSubg { get; set; }

        [XmlAttribute("disc")]
        public string Disc { get; set; }

        [XmlAttribute("chair")]
        public string Chair { get; set; }

        [XmlAttribute("id_prep")]
        public string Id_prepRaw { get; set; }

        [XmlAttribute("prep")]
        public string PrepRaw { get; set; }

        [XmlAttribute("id_group")]
        public string Id_groupRaw { get; set; }

        [XmlAttribute("group")]
        public string GroupRaw { get; set; }

        [XmlAttribute("day")]
        public string DayRaw { get; set; }

        [XmlAttribute("less")]
        public string Less { get; set; }

        [XmlAttribute("buildings")]
        public string buildings { get; set; }

        [XmlAttribute("rooms")]
        public string rooms { get; set; }

        /* readonly properties */

        [XmlIgnore]
        public DateOnly? Day
        {
            get => field ??= DayRaw.ToDateOnly();
        }

        [XmlIgnore]
        public int[] Id_prep
        {
            get => field ??= Id_prepRaw.ToIntArray();
        }
        [XmlIgnore]
        public int[] Id_group
        {
            get => field ??= Id_groupRaw.ToIntArray();
        }
        [XmlIgnore]
        public string[] Prep
        {
            get
            {
                if (string.IsNullOrWhiteSpace(PrepRaw))
                    return Array.Empty<string>();

                return PrepRaw
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(item => item.Trim())
                    .ToArray();
            }
        }
    }

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

            foreach (var element1 in obj1.Subject)
            {

                if (element1.Id_prep?.Length > 1)
                {
                    Console.Write($"Дата: {element1.DayRaw} = {element1.Day} ");
                    Console.Write($"Преподы: {string.Join(",", element1.Id_prep)}");
                    // *Проблема - при дальнейшей работе с данными Id_prep они безвозвратно становятся типом string, а так же единой строкой. 



                    //Console.Write($"Дата: {element1.DayRaw} = {element1.Day} ");                  \
                    //Console.Write("Преподы: ");                                               Оригинал
                    //foreach (var prep1 in element1.Id_prep)                                        |   
                    //    Console.Write($"{prep1},");                                               /


                    //Console.Write("Группы: ");                            \
                    //foreach (var group1 in element1.Id_group)     Аналогия с id групп
                    //    Console.Write($"{group1},");                      /


                    Console.WriteLine();
                }


            }

            foreach (var element2 in obj1.Subject)
            {
                if (element2.Prep?.Length > 1)
                {
                    Console.Write($"ФИО препода: {string.Join(", ", element2.Prep)}");
                    Console.WriteLine();
                }
            }

            Console.ReadLine();

        }

    }
}




