using System;
using System.Collections.Generic;
using System.IO;

namespace iadip {

    enum ApartmentsParametres {
        Id = 0,
    }

    public class TxtParser : IParser {
        public static Action EndReadFile = delegate { };
        public static Action StartReadFile = delegate { };

        public ClasterizeData ReadFile(string path) {
            StartReadFile();

            List<SourceDataRow> apartments = new List<SourceDataRow>();
            string[] titles;

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default)) {
                char[] charSeparators = new char[] { ';' };
                string firstString = sr.ReadLine();
                titles = firstString.Split(charSeparators);
                string tempString = "";
                string[] tempStringArray;
                double parsedResult = 0;
                SourceDataRow tempApartment = new SourceDataRow();
                int line = 1;
                while (!sr.EndOfStream) {
                    tempString = sr.ReadLine();
                    char separator = ';';
                    tempStringArray = tempString.Split(charSeparators, StringSplitOptions.None);

                    //if (Double.TryParse(tempStringArray[0], out parsedResult)) {
                    //    for (int i = 0; i < tempStringArray.Length; i++) {
                    //        bool isParsed = Double.TryParse(tempStringArray[i], out parsedResult);

                    //        if (i == (int)ApartmentsParametres.Id)
                    //            tempApartment.Id = isParsed ? (int)parsedResult : 0;
                    //        else if (Program.DataExample.ParamValues.ContainsKey(i))
                    //            tempApartment.Data.Set(i, isParsed ? (int)parsedResult : 0);
                    //        else if (Program.AdditionalParams.Contains(i))
                    //            tempApartment.SetOtherData(i, tempStringArray[i]);
                    //    }

                    //    apartments.Add(new SourceDataRow(tempApartment));
                    //} else {
                        for (int i = 0; i < tempStringArray.Length; i++) {
                            tempApartment.SetOtherData(i, tempStringArray[i]);                                
                        }
                    tempApartment.Id = line;
                    apartments.Add(new SourceDataRow(tempApartment));
                    line++;
                    //}                  
                }
            }

            EndReadFile();

            return new ClasterizeData(apartments, titles);
        }

    }
}
