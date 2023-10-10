namespace emis2
{
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;
    using System;
    using System.Data;
    

    class Program
    {
        static void Main()
        {
            var Diaglist = new List<Patient>();
            var readList = new List<Patient>();
            var cancerList = new List<Patient>();
            var ageList = new List<Patient>();
            var maleList = new List<Patient>();

            Patient p = new Patient();
            
            //get data
            readList = p.readdata();

            // get average age
            float aveAge = p.AveAge(readList);
            Console.WriteLine("Average age = " + aveAge);

            // get diagnosis
            Diaglist = p.DiagList(readList,"Broken Leg");
            p.DisplayList(Diaglist,"People with a Broken Leg");

            //get ages
            ageList = p.GetPatientsByAgeRange(readList,20, 30);
            p.DisplayList(ageList, "Age list");

            maleList = p.getMalePatients(readList);
            p.DisplayList(maleList, "Male Patients");
            

        }
    }
}
