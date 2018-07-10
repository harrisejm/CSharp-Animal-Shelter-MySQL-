using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace AnimalShelter.Models
  {
    public class Dog
    {
      private string _name;
      private string _gender;
      private string _checkin;
      private string _breed;


      public Dog(string Name, string Gender, string Checkin, string Breed)
      {
        _name = Name;
        _gender = Gender;
        _checkin = Checkin;
        _breed = Breed;
      }
      public string GetName()
      {
        return _name;
      }
      public string GetGender()
      {
        return _gender;
      }
      public string GetCheckin()
      {
        return _checkin;
      }
      public string GetBreed()
      {
        return _breed;
      }

      public static List<Dog> GetAll()
    {
      List<Dog> allDog = new List<Dog> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM dog;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string dogName = rdr.GetString(0);
        string dogGender = rdr.GetString(1);
        string dogCheckin = rdr.GetString(2);
        string dogBreed = rdr.GetString(3);
        Dog newDog = new Dog(dogName, dogGender, dogCheckin, dogBreed);
        allDog.Add(newDog);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allDog;
    }

    public void SaveDog()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO dog (name, gender, checkin, breed) VALUES (@Name, @Gender, @Checkin, @Breed);";

          //  @"INSERT INTO city (`Name`) VALUES (@CityName);";

          MySqlParameter name = new MySqlParameter("@Name", _name);
          MySqlParameter gender = new MySqlParameter("@Gender", _gender);
          MySqlParameter checkin = new MySqlParameter("@Checkin", _checkin);
          MySqlParameter breed = new MySqlParameter("@Breed", _breed);
          cmd.Parameters.Add(name);
          cmd.Parameters.Add(gender);
          cmd.Parameters.Add(checkin);
          cmd.Parameters.Add(breed);
          cmd.ExecuteNonQuery();    // This line is new!
          //_id = (int) cmd.LastInsertedId;
          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
        }


    }
  }
