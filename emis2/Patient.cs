using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace emis2
{

        public class Patient
        {
            public String Id { get; set; }

            public int Age { get; set; }
          
            public char Sex { get; set; }
            public string Diagnosis { get; set; }
            public string Name { get; set; }
            public string Treatment { get; set; }

         public List<Patient> readdata()
        {
            try
            {

                string cs = @"server=localhost;userid=mc;password=Donald2022!;database=emistest";
                using var con = new MySqlConnection(cs);
                con.Open();

                string sql = "SELECT * FROM patients";
                using var cmd = new MySqlCommand(sql, con);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Patient> allPatients = new List<Patient>();
                    Patient pat1 = new Patient();
                    while (reader.Read())
                    {
                        Patient o = new Patient()
                        {
                            Name = reader["name"].ToString(),
                            Age = Convert.ToInt32(reader["age"]),
                            Sex = Convert.ToChar(reader["sex"]),
                            Diagnosis = Convert.ToString(reader["diagnosis"]),
                            Treatment = Convert.ToString(reader["treatment"])
                        };
                        allPatients.Add(o);
                    }
                    return allPatients;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Readdata exception : " + e);
                return null;
            }
         }

        public float AveAge(List<Patient> patientList)
        {
            float totalAge = 0;
            float count = 0;
            foreach(Patient p in patientList)
            {
                totalAge = totalAge + p.Age;
                count++;
            }
            return (totalAge / count);
        }

        public List<Patient> DiagList(List<Patient> patientList,string In_Diagnosis)
        {
            try
            {
                List<Patient> diglist = new List<Patient>();
                diglist = patientList.FindAll(item => item.Diagnosis == In_Diagnosis);

                return (diglist);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error DiagList :" + e);
                return null;
            }
        }

        public void DisplayList(List<Patient> patientList, string listTitle)
        {
            try
            {
                Console.WriteLine("=================");
                Console.WriteLine(listTitle + " List");
                foreach (Patient g in patientList)
                {
                    Console.WriteLine("Name : " + g.Name);
                    Console.WriteLine("Age : " + g.Age);
                    Console.WriteLine("Gender : " + g.Sex);
                    Console.WriteLine("Diagnosis : " + g.Diagnosis);
                    Console.WriteLine("Treatment : " + g.Treatment);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error DisplayList :" + e);
            }
            
        }

        public List<Patient> GetPatientsByAgeRange(List<Patient> patientList,int minAge, int maxAge)
        {
            try
            {
                List<Patient> ageList = new List<Patient>();
                ageList = patientList.FindAll(item => item.Age >= minAge && item.Age <= maxAge);
                return (ageList);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error GetPatientsByAgeRange " + e);
                return null;

            }
        }

        public List<Patient> getMalePatients(List<Patient> patientList)
        {
            try
            {
                List<Patient> maleList = new List<Patient>();
                maleList = patientList.FindAll(item => item.Sex == 'M');
                return maleList;
            }
            catch(Exception e)
            {
                Console.WriteLine("GetMalePatients error : " + e);
                return null;
            }
        }

    }


    
}
