using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class StackOverflow
    {

        public void AssignValue()
        {
            try
            {
                Transaction transaction = new ();
                //Transaction OperatorExtensions.extension(Transaction).operator +(Transaction transaction, double b)
                transaction += 20; 

                //Transaction OperatorExtensions.extension(Transaction).operator -(Transaction transaction, double b)
                transaction -= 25; 

                //Transaction OperatorExtensions.extension(Transaction).operator >(Transaction transaction, double b)
                transaction = transaction > 10; 
                
                Console.WriteLine("Credit: " + transaction.Credit);
                Console.WriteLine("Discount: " + transaction.Discount);
                Console.WriteLine("Max: " + transaction.Max);
                // Values
                // Credit [double?] = 20
                // Debit [double?] = -25
                // Max [double] = 10
               
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine($"Stack overflow error: {ex.Message}");
            }
        }
    }

    public class Transaction
    {
        public double? Discount { get; set; }
        public double? Credit { get; set; }
        
        public double Max { get; set; } = 0;
    }


    public static class OperatorExtensions
    {
        extension(Transaction)
        {
            public static Transaction operator +(Transaction transaction, double b)
            {
                transaction.Credit = transaction.Credit.HasValue ? transaction.Credit + b : b;
                return transaction;
            }
            public static Transaction operator -(Transaction transaction, double b)
            {
                transaction.Discount = transaction.Discount.HasValue ? transaction.Discount - b : -b;
                return transaction;
            }

            public static Transaction operator <(Transaction transaction, double b)
            {
                transaction.Max = transaction.Max < b ? b : transaction.Max;
                return transaction;
            }

            public static Transaction operator >(Transaction transaction, double b)
            {
                transaction.Max = transaction.Max > b ? transaction.Max : b;
                return transaction;
            }
        }

        extension<TSource>(IEnumerable<TSource>)
        {
            public static IEnumerable<TSource> operator + (IEnumerable<TSource> left, IEnumerable<TSource> right) => left.Concat(right);
        }

    }
} 


