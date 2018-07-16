using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VickyHomeWork1.Models.ViewModels;
using System.IO;
using System.Web.Hosting;

namespace VickyHomeWork1.Models.ViewModels
{
    public class MoneyDataList
    {
        public static IEnumerable<MoneyViewModel> GetMoneyList()
        {
            var fileContents = File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/file.txt"));
            var source = fileContents.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                                     .ToList();
            var moneyList = from line in source
                            let item = line.Split(';')
                            select new MoneyViewModel
                            {
                                Date     = item[0],
                                Category = item[1],
                                Amount   = int.Parse(item[2])
                            };

            return moneyList;


            //Random gen = new Random((int)DateTime.Now.Ticks);
            //int CgRange = 2;
            //int AmtRange = 10000;
            //int DateRange = 365;
            //List<MoneyViewModel> moneyList = new List<MoneyViewModel>();
            //for (int i = 0; i < 50; i++)
            //{
            //    moneyList.Add(new MoneyViewModel()
            //    {
            //        Category = gen.Next(CgRange) == 1 ? IncomeStatement.支出 : IncomeStatement.收入,
            //        Amount = gen.Next(AmtRange),
            //        Date = DateTime.Today.AddDays(gen.Next(DateRange))
            //    });
            //}
            //return moneyList;
        }
    }
}