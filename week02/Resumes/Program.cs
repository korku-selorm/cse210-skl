using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Junior Drone Engineer";
        job1._company = "Soko Aerial";
        job1._startYear = 2023;
        job1._endYear = 2024;


        Job job2 = new Job();
        job2._jobTitle = "Software Developer";
        job2._company = "Amalitech";
        job2._startYear = 2024;
        job2._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Selorm Korku Ladzekpo";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

        //Console.WriteLine(myResume._jobs[0]._jobTitle);
    }
}