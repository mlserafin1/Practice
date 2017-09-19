using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data.TestRepos
{
    public class TestStateTaxRepository : ITaxRepository
    {
        public static List<StateTax> _testState = new List<StateTax>();

        public TestStateTaxRepository()
        {
            if (!_testState.Any())
            {
                _testState.AddRange(new List<StateTax>()
                {
                    new StateTax()
                    {
                        StateAbbreviation = "OH",
                        StateName = "Ohio",
                        TaxRate = 6.25M
                    },
                    new StateTax()
                    {
                        StateAbbreviation = "PA",
                        StateName = "Pennsylvania",
                        TaxRate = 6.75M
                    },
                    new StateTax()
                    {
                        StateAbbreviation = "MI",
                        StateName = "Michigan",
                        TaxRate = 5.75M
                    },
                    new StateTax()
                    {
                        StateAbbreviation = "IN",
                        StateName = "Indiana",
                        TaxRate = 6.00M
                    }

                });
            }
        }

        public List<StateTax> GetAll()
        {
            return _testState;
        }

        public StateTax GetByName(string state)
        {
            StateTax newStateTax = new StateTax();
            newStateTax = null;
            foreach (var sta in _testState)
            {
                if (state.ToUpper() == sta.StateAbbreviation || state.ToUpper() == sta.StateName.ToUpper())
                {
                    newStateTax = sta;
                    return newStateTax;
                }
            }
            return newStateTax;
        }
    }
}
