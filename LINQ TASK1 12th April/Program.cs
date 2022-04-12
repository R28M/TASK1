using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



//student class
public class student
{
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public string? smailid { get; set; }
    public string? branch { get; set; }
    public double  per { get; set; }

    public List<string>? skills { get; set; }
}

//student data
class program
{
    static void Main(string[] args)
    {
        List<student> students = new List<student>()
        {
            new student(){firstname="ram",lastname="mohan",smailid="ram@gmail",branch="ece",skills = new List<string> { "c#", "python", "java" },per=74},
            new student(){firstname="sam",lastname="sundar",smailid="sam@gmail",branch="ece",skills = new List<string> { "c#", "python", "java" },per=82},
            new student(){firstname="kamesh",lastname="chaganti",smailid="kam@gmail",branch="ece",skills = new List<string> { "c#", "python", "java" },per=76},
            new student(){firstname="leela",lastname="mohan",smailid="leela@gmail",branch="ece",skills = new List<string> { "c#", "python", "java" },per=74},
            new student(){firstname="aditya",lastname="arunahcalam",smailid="aditya@gmail",branch="ece",skills = new List<string> { "c#", "python", "java" },per=92}
        };


        //queries using LINQ and LAMDA expression

        // 1.select,where,take,takewhile,skip,skipwhile

        var query1 =from i in students select i;
        foreach (var i in query1)
        {
            Console.WriteLine(i.firstname + "," + i.lastname + "," + i.branch + "," + i.smailid + "," + i.per);
        }
        var query2 = from i in students where i.per >= 85 select i;
        foreach (var i in query2)
        {
            Console.WriteLine(i.firstname + "," + i.lastname + "," + i.branch + "," + i.smailid + "," + i.per);
        }
        Console.WriteLine("\n----take----");
        var take = students.Select(i => i).Take(3);
        foreach (var i in take)
        {
            Console.WriteLine(i.firstname + "," + i.lastname + "," + i.branch + "," + i.smailid + "," + i.per);
        }
        Console.WriteLine("\n----takewhile---- ");
        var takewhile = students.TakeWhile(i=>i.per>85);
        foreach (var i in takewhile)
        {
            Console.WriteLine(i.firstname + "," + i.lastname + "," + i.branch + "," + i.smailid + "," + i.per);
        }
        Console.WriteLine("\n----skip----");
         var skip= students.Select(i=>i).Skip(3);
        foreach (var i in skip)
        {
            Console.WriteLine(i.firstname + "," + i.lastname + "," + i.branch + "," + i.smailid + "," + i.per);
        }
        Console.WriteLine("\n----skipwhile----");
        var skipwhile = students.Select(i => i).SkipWhile(i=>i.per>=82);
        foreach (var i in skipwhile)
        {
            Console.WriteLine(i.firstname + "," + i.lastname + "," + i.branch + "," + i.smailid + "," + i.per);
        }


        //2 Orderby asc and desc and groupby
        Console.WriteLine("\n---orderby ascending----");
        var query3 = from i in students orderby i.per ascending select i;
        foreach (var i in query3)
        {
            Console.WriteLine(i.firstname + "," + i.lastname + "," + i.branch + "," + i.smailid + "," + i.per);
        }
        Console.WriteLine("\n---orderby descending----");

        Console.WriteLine(" ");
        var query4 = from i in students orderby i.per descending select i;
       
        foreach (var i in query4)
        {
            Console.WriteLine(i.firstname + "," + i.lastname + "," + i.branch + "," + i.smailid + "," + i.per);
        }
        Console.WriteLine("\n-----groupby----- ");

        var query5 = students.GroupBy(i => i.per > 80);
        foreach (var i in query5)
        {
            Console.WriteLine(i.Key);
            foreach(var j in i)
            {
                Console.WriteLine(j.firstname+","+j.lastname+","+j.branch+","+j.smailid+","+j.per);
            }
        }

        //3 select ,selectmany
        //Console.WriteLine("\n-----selectmany----- ");

        students.Add(new student { firstname = "tom", lastname = "hillend", branch = "IT", smailid = "tom@gmail.com", skills = new List<string> { "c#", "python", "java" } });
        var query6 = students.SelectMany(i => i.skills);
        foreach (var i in query6)
        { Console.WriteLine(i); }

        //4 aggregate functions
        Console.WriteLine("\n---aggregate functions-----");
        double sum = students.Select(i => i.per).Sum();
         Console.WriteLine(sum);
        double max = students.Select(i => i.per).Max();
        Console.WriteLine(max);
        double min = students.Select(i => i.per).Min();
        Console.WriteLine(min);
        double avg = students.Select(i => i.per).Average();
        Console.WriteLine(avg);
        int count = students.Select(i => i).Count();
        Console.WriteLine(count);
        var query7 = students.Select(i => i.per).Distinct();
        foreach (var i in query7)
        { Console.WriteLine(i); }

        //5 let,into
        Console.WriteLine("\n----let----");
        var query8 = from i in students let res = i.per + 5 select res;
        foreach(var i in query8)
        { Console.WriteLine(i); }

        Console.WriteLine("\n----into---");
        var into = from i in students where i.per > 90 select i into name where name.firstname.StartsWith('a') select name;
        foreach (var j in into)
        {
            Console.WriteLine(j.firstname + "," + j.lastname + "," + j.branch + "," + j.smailid + "," + j.per);
        }
       

        //6 first, firstordefault,last,lastordefault,single,singleordefault,elementat
        Console.WriteLine("\n-----first----");
        var first= students.Where(i=>i.per==74).Select(i=>i).First();
        Console.WriteLine(first.firstname+","+first.lastname+","+first.branch+","+first.smailid+","+first.per);


        Console.WriteLine("\n-----firstordefault----");
        var firstordefault = students.Where(i => i.per == 92).Select(i => i).FirstOrDefault();
        Console.WriteLine(firstordefault.firstname + "," + firstordefault.lastname + "," + firstordefault.branch + "," + firstordefault.smailid + "," + firstordefault.per);


        Console.WriteLine("\n-----last----");
        var last = students.Where(i => i.per == 74).Select(i => i).Last();
        Console.WriteLine(last.firstname + "," + last.lastname + "," + last.branch + "," + last.smailid + "," + last.per);


        Console.WriteLine("\n-----lastordefault----");
        var lastordefault = students.Where(i => i.per == 74).Select(i => i).LastOrDefault();
        Console.WriteLine(lastordefault.firstname + "," + lastordefault.lastname + "," + lastordefault.branch + "," + lastordefault.smailid + "," + lastordefault.per);

        Console.WriteLine("\n-----single----");
        var single = students.Where(i => i.per == 92).Select(i => i).Single();
        Console.WriteLine(single.firstname + "," + single.lastname + "," + single.branch + "," + single.smailid + "," + single.per);

        Console.WriteLine("\n-----singleordefault----");
        var singleordefault = students.Where(i => i.per == 92).Select(i => i).SingleOrDefault();
        Console.WriteLine(singleordefault.firstname + "," + singleordefault.lastname + "," + singleordefault.branch + "," + singleordefault.smailid + "," + singleordefault.per);

        //7 immediate execution and differed execution
        Console.WriteLine("\n----immediate execution---");
        double summer = students.Select(i => i.per).Sum();
        Console.WriteLine(summer);

        Console.WriteLine("\n---differed execution----");
        var all = students.Select(i => i);
        students.Add(new student { firstname = "new firstname", lastname = "new lastname", branch = "new branch", smailid = "new smail@gmail.com" ,per=95});



        //8 startswith, endswith, contain
        Console.WriteLine("\n----startswith-----");
        var startswith = students.Where(i => i.firstname.StartsWith('r')).Select(i=>i);
        foreach(var i in startswith)
        { Console.WriteLine(i.firstname); }

        Console.WriteLine("\n----endswith-----");
        var endswith = students.Where(i => i.firstname.EndsWith('m')).Select(i => i);
        foreach (var i in endswith)
        { Console.WriteLine(i.firstname); }

        Console.WriteLine("\n----contains-----");
        var contains = students.Where(i => i.firstname.Contains('m')).Select(i => i);
        foreach (var i in contains)
        { Console.WriteLine(i.firstname); }

        //9 ienumereable and iquerable
        Console.WriteLine("\n---ienumerable----");
        IEnumerable<student> q1 = students.Select(i => i).AsQueryable();
        foreach(var i in q1)
        { Console.WriteLine(i.firstname+","+i.lastname+","+i.branch+","+i.per); }

        Console.WriteLine("\n----iquerable----");
        IQueryable<student> q2 = students.Select(i=>i).AsQueryable();
        foreach (var i in q2)
        { Console.WriteLine(i.firstname + "," + i.lastname + "," + i.branch + "," + i.per); }
















    }
}


