using System.Text;
using Ans.Net10.Common;

namespace Practice.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Console.WriteLine($"libcommoninfo.getname(): {LibCommonInfo.GetName()}");
            Console.WriteLine($"libcommoninfo.getdescription(): {LibCommonInfo.GetDescription()}");
            Console.WriteLine($"libcommoninfo.getversion(): {LibCommonInfo.GetVersion()}");
            Console.WriteLine();

            var s1 = _Consts.GET_RANDOM_SAMPLE_RU();

            Console.WriteLine($"sample: {s1.GetStartWithACapital()}");

            var a1 = s1.SplitFix(" ", 20);
            var i1 = 0;
            foreach (var item1 in a1)
            {
                Console.WriteLine($"{++i1}. {item1}");
            }
            Console.ReadLine();

            Console.WriteLine($"suppapp.currentpath: {SuppApp.CurrentPath}");
            Console.ReadLine();

            var amount1 = 12345;
            Console.WriteLine($"suppapp.currentpath: {SuppLangRu.GetAmountInRublesInWords(amount1, true)}");
            Console.ReadLine();
        }
    }
}
