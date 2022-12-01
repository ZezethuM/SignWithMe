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
    public class UserRepo : IUser
    {
        public UserRepo(string pConString)
        {
            Connection = new NpgsqlConnection(pConString);
            Connection.Open();
            string CREATE_USER_TABLE = @"create table if not exists players(
	            Id SERIAL PRIMARY KEY,
	            Username VARCHAR(50) UNIQUE NOT NULL,
	            Password VARCHAR(50) NOT NULL,
	            Level VARCHAR(50) NOT NULL,
                Score VARCHAR(50) NOT NULL,
                Result VARCHAR(50) NOT NULL
            );";
            Connection.Execute(CREATE_USER_TABLE);
            Connection.Close();
        }
        public void AddUser(User user)
        {
            Connection.Open();
            string addQsql = @"insert into players(Username,Password,Level,Score,Result)
                            values(@Username,@Password,@Level,@Score,@Result)";

            Connection.Execute(addQsql, 
            new User()
            {
                 Username = user.Username,
                 Password = user.Password,
                 Level = user.Level,
                 Score = user.Score,
                 Result = user.Result
            });
            Connection.Close();
        }

        public bool AuthUser(User pUser)
        {
            Connection.Open();
            var user = UserbyName(pUser.Username);
            if(user.Password == pUser.Password)
            {
                return true;
            }
            Connection.Close();
            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
             Connection.Open();
             var users = Connection.Query<User>(@"select * from players");
             Connection.Close();
             return users;
        }

        public User UserbyName(string pUsername)
        {
             Connection.Open();
            var template = new User{ Username =  pUsername };
            var parameters = new DynamicParameters(template);
            string sql = @"select * from players where Username = @Username";
            var user = Connection.QueryFirstOrDefault<User>(sql, parameters);
            Connection.Close();
            return user ;
        }
        private NpgsqlConnection Connection {get; set;}
    }
}