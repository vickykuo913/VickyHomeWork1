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
        public int No { get; set; }
        public string Class { get; set; }
        public DateTime Date { get; set; }
        public string Money { get; set; }


        public static List<MoneyViewModel> GetMoneyList()
        {
            //var fileContents =File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/file.txt"));
            
            List<MoneyViewModel> moneyList = new List<MoneyViewModel>();

            string[] aryDA;
            string line = string.Empty;
            string fileName = HostingEnvironment.MapPath(@"~/App_Data/file.txt");
            StreamReader sr = new StreamReader(fileName);

            while ((line = sr.ReadLine()) != null)
            {
                aryDA=line.Split(char.Parse(";"));

                moneyList.Add(new MoneyViewModel()
                {
                    Date = aryDA[0],
                    Category = aryDA[1],
                    Amount = int.Parse( aryDA[2])
                });
            }
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