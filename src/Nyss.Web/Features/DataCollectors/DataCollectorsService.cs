using System;
using System.Collections.Generic;
using RandomNameGeneratorLibrary;

namespace Nyss.Web.Features.DataCollectors
{
    public class DataCollectorsService : IDataCollectorsService
    {
        public IEnumerable<DataCollectorViewModel> All()
        {
            var personGenerator = new PersonNameGenerator();

            var dataCollectors = new List<DataCollectorViewModel>();
            for (var i = 0; i < 100; ++i)
            {
                //Cleanup function
                var rand = new Random();
                var sex = rand.Next(0,2);
                string s = "";
                if(sex == 0){
                    s = "Male";
                }
                else{
                    s = "Female";
                }
                var language = rand.Next(0,2);
                string l = "";
                if(language == 0){
                    l = "English";
                }
                else{
                    l = "French";
                }
    
                var latitude = rand.NextDouble() * 180 - 90;
                var longtitude = rand.NextDouble() * 360 - 180;
                var phonenumber = "0";
                for(int x = 0; x < 10; x++){
                    phonenumber += rand.Next(0,10);
                }

                dataCollectors.Add(new DataCollectorViewModel
                {
                    FullName = personGenerator.GenerateRandomFirstName(),
                    DisplayName = personGenerator.GenerateRandomFirstAndLastName(),
                    YearOfBirth = rand.Next(1900, 2019),
                    Sex = s,
                    Language = l,
                    Latitude = latitude,
                    Longtitude = longtitude,
                    Region = personGenerator.GenerateRandomFirstName(),
                    District = personGenerator.GenerateRandomLastName(),
                    Village = personGenerator.GenerateRandomFirstAndLastName(),
                    PhoneNumbers = new List<string> { phonenumber}

                });
            }
            return dataCollectors;
        }
    }
}