using System;
using System.Collections.Generic;
abstract class JobRole
{
    public string Name;
    public abstract void RoleName();
}

class Software : JobRole
{
    public Software()
    {
        Name = "Software";
    }
    public override void RoleName()
    {
        Console.WriteLine("Software Engineer");
    }
}

class DataScientist : JobRole
{
    public DataScientist()
    {
        Name = "Data Scientist";
    }
    public override void RoleName()
    {
        Console.WriteLine("Data Scientist Engineer");
    }
}

class Resume<T> where T : JobRole
{
    public string CandidateName;
    public T JobRole;
    public Resume(string candidatename,T jobRole)
    {
        CandidateName = candidatename;
        JobRole = jobRole;
    }

    public void Display()
    {
        Console.WriteLine("Candidate Name: "+CandidateName+" \nJob Role: ");
        JobRole.RoleName();
    }
}


class ResumeScreeningSystem<T> where T : JobRole
{
    public List<Resume<T>> resumes = new List<Resume<T>>();

    public void AddResume(Resume<T> resume)
    {
        resumes.Add(resume);
    }

    public void ShowResume()
    {
        for(int i = 0; i < resumes.Count; i++)
        {
            resumes[i].Display();
        }
    }
}
class ResumeScreening
{
    static void Main(string[] args)
    {
        Software software = new Software();
        DataScientist dataScientist = new DataScientist();

        Resume<Software> SoftwareResume = new Resume<Software>("Devansh Singh",software);
        Resume<DataScientist> DataScientistResume = new Resume<DataScientist>("Rohit Kumar",dataScientist);

        ResumeScreeningSystem<Software> Soft = new ResumeScreeningSystem<Software>();
        ResumeScreeningSystem<DataScientist> Data = new ResumeScreeningSystem<DataScientist>();

        Soft.AddResume(SoftwareResume);
        Data.AddResume(DataScientistResume);

        Soft.ShowResume();
        Data.ShowResume();
    }
}