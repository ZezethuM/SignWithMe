using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using SignWithMe.Interfaces;
using SignWithMe.Models;

namespace SignWithMe.Repository
{
  public class WordsRepo : IWords
  {
    public WordsRepo(string pConString)
    {
      Connection = new NpgsqlConnection(pConString);
      Connection.Open();
      string CREATE_Words_TABLE = @"create table if not exists words (
	            Id SERIAL PRIMARY KEY,
	            Word VARCHAR(50) NOT NULL,
                ImageFile VARCHAR(150) NOT NULL
            );";
      Connection.Execute(CREATE_Words_TABLE);
    }
    public void AddSign(Words pWord)
    {
      string addQsql = @"insert into words(Word, ImageFile)
                            values(@Word, @ImageFile)";
      Connection.Execute(addQsql, new Words() { Word = pWord.Word, ImageFile = pWord.ImageFile });
    }

    public IEnumerable<Words> GetAllSigns()
    {
      var Words = Connection.Query<Words>(@"select * from words");
      return Words;
    }

    public Words GetSignByAlphabet(string pWord)
    {
      var template = new Words { Word = pWord };
      var parameters = new DynamicParameters(template);
      string sql = @"select * from words where id = @id";
      var sign = Connection.QueryFirstOrDefault<Words>(sql, parameters);
      return sign;
    }
    private NpgsqlConnection Connection { get; set; }
  }
}