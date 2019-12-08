using LuisAI.Dtos;
using LuisAI.RelatedValues;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoLuisRelatedValues
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool add = true;
            bool repeat = true;
            LuisParams luisParams = new LuisParams
            {
                AppId = "<App Key>",
                VersionId = "<App version e.g 0.1>",
                SubsKey = "<Luis Subscription Key>",
                //this is only used when you have already the ID
                PhraseListId = "<Luis PhaseList ID>",
                Endpoint = Region.WestEurope
            };
            ILuis luis = new Luis(luisParams);
            
            //// This step is one Time only to get a phaselist ID in order to use it as param for the  RelatedValuesAsync method
            ////CreatePhaseListAsync method doesn't need the PhraseListId as property in the luisParams object
            ////In case of lost of the phaseListID you can use the overrided method of CreatePhaseListAsync by passing a name for your phaselist. exmaple .CreatePhaseListAsync("phaseListTest")
            //var phaseListID = await luis.CreatePhaseListAsync();
            //Console.WriteLine(phaseListID);
            
            while (repeat)
            {
                List<string> keywords = new List<string>();
                while (add)
                {
                    Console.WriteLine("Give us a word to search for a related value");
                    string word = Console.ReadLine();
                    keywords.Add(word);
                    Console.WriteLine("Do you want to add more: y/n");
                    char reply1 = Console.ReadLine()[0];
                    if (reply1.ToString().ToLower() != "y")
                    {
                        add = false;
                    }
                }
                Console.WriteLine("Give us the number of Top elements");
                int number = int.Parse(Console.ReadLine());

                Console.WriteLine("++++++++++++++++The related Values++++++++++++++++++");
                
                //RelatedValuesAsync method take as params keywords wich is List<string> and number of related values to get as result
                //keywords could be one to * but, more that it better to give a list of maximum 3
                var response = await luis.RelatedValuesAsync(keywords, number);


                foreach (var item in response)
                {
                    Console.WriteLine(item);

                }
                Console.WriteLine("Do you want to repeat : y/n");
                char reply = Console.ReadLine()[0];
                if (reply.ToString().ToLower() != "y")
                {
                    repeat = false;
                }
                add = true;
            }

            Console.ReadLine();
        }
    }
}
