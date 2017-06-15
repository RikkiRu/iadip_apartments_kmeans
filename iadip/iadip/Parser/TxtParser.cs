using System;
using System.Collections.Generic;
using System.IO;

namespace iadip {

    enum ApartmentsParametres {
        Id = 0,
        Cost = 1,
        AreaSize = 2,
        RoomsCount = 3,
        BathroomsCount = 4,
        City = 5,
        Company = 8
    }

    class TxtParser : IParser {
        public static Action EndReadFile = delegate { };
        public static Action StartReadFile = delegate { };

        public List<Apartament> ReadFile(string path) {
            StartReadFile();

            List<Apartament> apartments = new List<Apartament>();

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default)) {
                string firstString = sr.ReadLine();
                string tempString = "";
                string[] tempStringArray;
                double parsedResult = 0;
                Apartament tempApartment = new Apartament();
                while (!sr.EndOfStream) {
                    tempString = sr.ReadLine();
                    tempStringArray = tempString.Split('\t');
                    
                    for(int i = 0; i < tempStringArray.Length; i++) {
                        bool isParsed = Double.TryParse(tempStringArray[i], out parsedResult);
                        switch (i) {
                            case (int)ApartmentsParametres.Id:             tempApartment.Id =                  isParsed ? (int)parsedResult : 0; break;
                            case (int)ApartmentsParametres.Cost:           tempApartment.Data.Cost =           isParsed ? parsedResult : 0; break;
                            case (int)ApartmentsParametres.AreaSize:       tempApartment.Data.AreaSize =       isParsed ? (int)parsedResult : 0; break;
                            case (int)ApartmentsParametres.RoomsCount:     tempApartment.Data.RoomsCount =     isParsed ? (int)parsedResult : 0; break;
                            case (int)ApartmentsParametres.BathroomsCount: tempApartment.Data.BathroomsCount = isParsed ? (int)parsedResult : 0; break;
                            case (int)ApartmentsParametres.City:           tempApartment.City = tempStringArray[i]; break;
                            case (int)ApartmentsParametres.Company:        tempApartment.Company = tempStringArray[i]; break;
                        }
                        
                    }

                    apartments.Add(new Apartament(tempApartment));
                }
            }

            EndReadFile();

            return apartments;
        }

    }

}
