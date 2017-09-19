using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class FileStateTaxRepository : ITaxRepository
    {
        private string _fileName;

        public FileStateTaxRepository(string filename)
        {
            _fileName = filename;
        }

        public List<StateTax> GetAll()
        {
            throw new NotImplementedException();
        }

        public StateTax GetByName(string state)
        {

            StateTax tax = new StateTax();
            tax = null;
            using (StreamReader sr = new StreamReader(_fileName))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    StateTax temp = new StateTax();

                    string[] fields = line.Split('|');
                    try
                    {
                        temp.StateAbbreviation = fields[0];
                        temp.StateName = fields[1];
                        temp.TaxRate = decimal.Parse(fields[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message +
                                          " Contact IT."); //wont console write message if the error occurs anywhere other than the first string in file
                    }

                    if (temp.StateAbbreviation == state.ToUpper() || temp.StateName.ToUpper() == state.ToUpper())
                    {
                        tax = temp;
                    }
                }
            }
            return tax;
        }
    }
}
