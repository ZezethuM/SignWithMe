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
    public class SignsRepo : ISigns
    {
        public SignsRepo(string pConString)
        {
            Connection = new NpgsqlConnection(pConString);
            Connection.Open();
            string CREATE_Sign_TABLE = @"create table if not exists alphabets (
	            Id SERIAL PRIMARY KEY,
	            Alphabet VARCHAR(50) NOT NULL,
                ImageFile VARCHAR(150) NOT NULL
            );";
            Connection.Execute(CREATE_Sign_TABLE);
        }
        public void AddSign(Sign pSign)
        {
            string addQsql = @"insert into alphabets(Alphabet, ImageFile)
                            values(@Alphabet, @ImageFile)";
            Connection.Execute(addQsql, new Sign(){ Alphabet= pSign.Alphabet, ImageFile = pSign.ImageFile});
        }

        public IEnumerable<Sign> GetAllSigns()
        {
             var Signs = Connection.Query<Sign>(@"select * from alphabets");
             return Signs;
        }

        public Sign GetSignByAlphabet(string pAlphabet)
        {
            var template = new Sign { Alphabet =  pAlphabet };
            var parameters = new DynamicParameters(template);
            string sql = @"select * from alphabets where id = @id";
            var sign = Connection.QueryFirstOrDefault<Sign>(sql, parameters);
            return sign ;
        }
        public void UpdateSign(Sign pSign)
        {
            var sign = GetSignByAlphabet(pSign.Alphabet);
            var template = new Sign { Id = sign.id, Alphabet = sign.Alphabet, ImageFile = pSign.ImageFile};
            var parameters = new DynamicParameters(template);
            string sql = @"update alphabets set ImageFile = @imageFile where Id = @id";
            Connection.Execute( sql, parameters);
        }
        private NpgsqlConnection Connection {get; set;}
    }
}