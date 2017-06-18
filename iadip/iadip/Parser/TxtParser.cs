using System;
using System.Collections.Generic;
using System.IO;

namespace iadip {

    enum ApartmentsParametres {
        Id = 0,
        City = 6,
        Company = 8
    }

    class TxtParser : IParser {
        public static Action EndReadFile = delegate { };
        public static Action StartReadFile = delegate { };

        public List<SourceDataRow> ReadFile(string path) {
            StartReadFile();

            List<SourceDataRow> apartments = new List<SourceDataRow>();

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default)) {
                string firstString = sr.ReadLine();
                string tempString = "";
                string[] tempStringArray;
                double parsedResult = 0;
                SourceDataRow tempApartment = new SourceDataRow();
                while (!sr.EndOfStream) {
                    tempString = sr.ReadLine();
                    tempStringArray = tempString.Split('\t');

                    if (Double.TryParse(tempStringArray[0], out parsedResult)) {
                        for (int i = 0; i < tempStringArray.Length; i++) {
                            bool isParsed = Double.TryParse(tempStringArray[i], out parsedResult);

                            if (Program.DataExample.ParamValues.ContainsKey(i))
                                tempApartment.Data.Set(i, isParsed ? (int)parsedResult : 0);
                            else
                            {
                                switch (i)
                                {
                                    case (int)ApartmentsParametres.Id: tempApartment.Id = isParsed ? (int)parsedResult : 0; break;
                                    case (int)ApartmentsParametres.City: tempApartment.City = tempStringArray[i]; break;
                                    case (int)ApartmentsParametres.Company: tempApartment.Company = tempStringArray[i]; break;
                                }
                            }
                        }

                        apartments.Add(new SourceDataRow(tempApartment));
                    }                    
                }
            }

            EndReadFile();

            return apartments;
        }

    }

}
