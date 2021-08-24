
using System;
using System.Collections.Generic;
using Microsoft.ML.Probabilistic.Distributions;


namespace ReviewerCalibration
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Review[] reviews = new Review[17];
            Submission a = new Submission(1);
            Submission b= new Submission(2);
            Submission c= new Submission(3);
            Submission d= new Submission(4);
            Submission e= new Submission(5);
            
            Reviewer aa = new Reviewer(1);
            Reviewer bb = new Reviewer(2);
            Reviewer cc = new Reviewer(3);
            Reviewer dd = new Reviewer(4);
            Reviewer ee = new Reviewer(5);

            reviews[0] = new Review(aa, a, 5, 1);
            reviews[1] = new Review(aa, c, 5, 1);
            reviews[2] = new Review(aa, d, 6, 1);

            reviews[3] = new Review(bb, a, 2, 3);
            reviews[4] = new Review(bb, d, 4, 3);
            reviews[5] = new Review(bb, e, 5, 3);

            reviews[6] = new Review(cc, a, 2, 2);
            reviews[7] = new Review(cc, b, 4, 2);
            reviews[8] = new Review(cc, c, 3, 2);

            reviews[9] = new Review(dd, b, 2, 3);
            reviews[10] = new Review(dd, c, 3, 3);
            reviews[11] = new Review(dd, d, 4, 3);
            reviews[12] = new Review(dd, e, 1, 3);

            reviews[13] = new Review(ee, a, 1, 2);
            reviews[14] = new Review(ee, b, 3, 2);
            reviews[15] = new Review(ee, d, 4, 2);
            reviews[16] = new Review(ee, e, 5, 2);



            ReviewerCalibration reviewerCalibration = new ReviewerCalibration();
            var results = reviewerCalibration.Run(reviews);

            // Display the results here
            Console.WriteLine("------------------- Accuracy ---------------------");
            foreach (KeyValuePair<Reviewer, Gamma> ele1 in results.Accuracy)
            {
                Console.WriteLine("{0} and {1}",
                          ele1.Key.Name, ele1.Value);
            }
            Console.WriteLine();
            Console.WriteLine("------------------- ExpertPrecision ---------------------");
            foreach (KeyValuePair<Expertise, Gamma> ele1 in results.ExpertPrecision)
            {
                Console.WriteLine("{0} and {1}",
                          ele1.Key, ele1.Value);
            }
            Console.WriteLine();
            Console.WriteLine("------------------- Quality ---------------------");
            foreach (KeyValuePair<Submission, Gaussian> ele1 in results.Quality)
            {
                Console.WriteLine("{0} and {1}",
                          ele1.Key.Title, ele1.Value);
            }
            Console.WriteLine();
            Console.WriteLine("------------------- Thresholds ---------------------");
            foreach (KeyValuePair<Reviewer, Gaussian[]> ele1 in results.Thresholds)
            {
                Console.WriteLine(" ------------- " + ele1.Key.Name + " ------------- ");
                for (int i = 0; i < ele1.Value.Length; i++)
                {
                    Console.WriteLine(ele1.Value[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
