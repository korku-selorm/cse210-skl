using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create video 1
        Video video1 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600);
        video1.SetComment("Alice123", "Great tutorial! Very clear explanation.");
        video1.SetComment("BobCode", "Thanks for the quick overview!");
        video1.SetComment("CharlieDev", "Can you make one about classes?");
        video1.SetComment("DanaLearn", "Really helpful, thanks!");
        video1.AddView(); // Add views
        video1.AddView();
        video1.AddView();
        videos.Add(video1);

        // Create video 2
        Video video2 = new Video("Advanced C# Techniques", "TechBit", 1200);
        video2.SetComment("EveCode", "This was super informative!");
        video2.SetComment("FrankDev", "The examples were spot on.");
        video2.SetComment("GraceLearn", "Please cover more advanced topics!");
        video2.AddView(); // Add views
        video2.AddView();
        videos.Add(video2);

        // Create video 3
        Video video3 = new Video("C# Project Walkthrough", "DevGuide", 1800);
        video3.SetComment("HenryCode", "Loved the practical approach!");
        video3.SetComment("IsabelDev", "Clear and concise, great job!");
        video3.SetComment("JackLearn", "This helped me with my project.");
        video3.SetComment("KellyCode", "Awesome walkthrough!");
        video3.AddView(); // Add views
        video3.AddView();
        video3.AddView();
        video3.AddView();
        videos.Add(video3);

        // Create video 4
        Video video4 = new Video("C# Best Practices", "CodePro", 900);
        video4.SetComment("LiamDev", "These tips are gold!");
        video4.SetComment("MiaCode", "Really improved my coding style.");
        video4.SetComment("NoahLearn", "Thanks for the best practices!");
        video4.AddView(); // Add views
        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}

// added a feature to keep track of views and comments to a particular video 