using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static List<IResult> Run(params IResult[] checks)
        {
            List<IResult> result = new List<IResult>();
            foreach(var check in checks)
            {
                if (!check.Success)
                    result.Add(check);
            }
            return result;
        }
    }
}
