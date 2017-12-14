using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFWebService
{
    public class WebService : IWebService
    {

        public dbEntities db = new dbEntities();

        public string Create(string firstname, string lastname, int age, string gender)
        {
            try
            {
                Person person = new Person();
                person.Firstname = firstname;
                person.Lastname = lastname;
                person.Age = age;
                person.Gender = gender;
                db.People.Add(person);
                db.SaveChanges();

                return "Success";

            }
            catch (Exception e) {
                return "Failed";
            }

        }

        public string Delete(int id)
        {
            try
            {
                Person person = db.People.FirstOrDefault(i => i.Id == id);
                db.People.Attach(person);
                db.People.Remove(person);
                db.SaveChanges();

                return "Success";
            }
            catch (Exception e) {
                return "Failed";
            }

        }

        public List<Person> GetAllPersons()
        {
            List<Person> personList = db.People.ToList();
            return personList;
        }

        public Person GetPersonById(int id)
        {
            Person person = db.People.FirstOrDefault(i => i.Id == id);
            return person;
        }

        public string Update(int id, string firstname, string lastname, int age, string gender)
        {
            try
            {
                Person person = db.People.FirstOrDefault(i => i.Id == id);
                person.Firstname = firstname;
                person.Lastname = lastname;
                person.Age = age;
                person.Gender = gender;
                db.SaveChanges();

                return "Success";
            }
            catch (Exception e)
            {
                return "Failed";
            }
        }
    }
}
