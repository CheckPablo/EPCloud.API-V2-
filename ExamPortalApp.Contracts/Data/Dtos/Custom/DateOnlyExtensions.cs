using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPortalApp.Contracts.Data.Dtos.Custom
{
    public struct DateOnly
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
    public static class DateOnlyExtensions
    {
        //public static DateOnly GetDateOnly(this DateTime dt)
        //{
        //    return new DateOnly
        //    {
        //        Day = dt.Day,
        //        Month = dt.Month,
        //        Year = dt.Year
        //    };
        //}

        public static DateOnly? GetDateOnly(this DateTime? dt)
        {
            return new DateOnly
            {
                Day = dt.HasValue ? dt.Value.Day : 0,
                Month = dt.HasValue ? dt.Value.Month:0,
                Year = dt.HasValue ? dt.Value.Year: 0
            };
        }

        //public static DateTime? GetDateOnly(DateTime? modifiedDate) => new DateOnly
        //{
        //    Day = modifiedDate.Day,
        //    Month = modifiedDate.Month,
        //    Year = modifiedDate.Year
        //};//throw new NotImplementedException();
    }
}
