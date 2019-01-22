using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sheeps3.Models
{
    public class SheepsDatabaseContext
    {
        private string _connectionString;

        public SheepsDatabaseContext(String connectionString)
        {
            _connectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public List<Hand> GetAllHands()
        {
            List<Hand> hands = new List<Hand>();

            MySqlConnection connection;
            MySqlCommand sqlCommand;
            MySqlDataReader dataReader;

            connection = GetConnection();
            connection.Open();

            sqlCommand = new MySqlCommand();
            sqlCommand.CommandText = "SELECT * FROM HAND";
            sqlCommand.Connection = connection;

            dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Hand hand = new Hand();

                hand.Id = dataReader.GetInt32("Id");
                hand.Deals = dataReader.GetInt32("Deals");
                hand.Dealer = dataReader.GetString("Dealer");
                hand.Picker = dataReader.GetString("Picker");
                hand.BQBlitz = dataReader.GetString("BQBlitz");
                hand.RQBlitz = dataReader.GetString("RQBlitz");
                hand.BJBlitz = dataReader.GetString("BJBlitz");
                hand.RJBlitz = dataReader.GetString("RJBlitz");
                hand.Crack = dataReader.GetString("Crack");
                hand.CrackBack = dataReader.GetString("CrackBack");
                hand.ReCrack = dataReader.GetString("ReCrack");
                hand.Result = dataReader.GetString("Result");
                


                hands.Add(hand);
            }

            dataReader.Close();
            connection.Close();

            return hands;
        }
        
        public List<Player> GetAllPlayers()
        {
            List<Player> players = new List<Player>();

            MySqlConnection connection;
            MySqlCommand sqlCommand;
            MySqlDataReader dataReader;

            connection = GetConnection();
            connection.Open();

            sqlCommand = new MySqlCommand();
            sqlCommand.CommandText = "SELECT * FROM PLAYER";
            sqlCommand.Connection = connection;

            dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Player player = new Player();

                player.Id = dataReader.GetInt32("Id");
                player.Name = dataReader.GetString("Name");

                players.Add(player);

            }

            dataReader.Close();
            connection.Close();

            return players;
        }

        public void AddHand(Hand hand)
        {
            MySqlConnection connection;
            MySqlCommand sqlCommand;

            connection = GetConnection();
            connection.Open();

            sqlCommand = new MySqlCommand();
            sqlCommand.Connection = connection;

            sqlCommand.CommandText = "INSERT INTO HAND VALUES(NULL, @, @)";

            sqlCommand.Parameters.AddWithValue("@Deals", hand.Deals);

            sqlCommand.Parameters.AddWithValue("@Dealer", hand.Dealer);
            sqlCommand.Parameters.AddWithValue("@Picker", hand.Picker);
            sqlCommand.Parameters.AddWithValue("@Partner", hand.Partner);
            sqlCommand.Parameters.AddWithValue("@BQBlitz", hand.BQBlitz);
            sqlCommand.Parameters.AddWithValue("@RQBlitz", hand.RQBlitz);
            sqlCommand.Parameters.AddWithValue("@BJBlitz", hand.BJBlitz);
            sqlCommand.Parameters.AddWithValue("@RJBlitz", hand.RJBlitz);
            sqlCommand.Parameters.AddWithValue("@Crack", hand.Crack);
            sqlCommand.Parameters.AddWithValue("@CrackBack", hand.CrackBack);
            sqlCommand.Parameters.AddWithValue("@ReCrack", hand.ReCrack);
            sqlCommand.Parameters.AddWithValue("@GameInt", hand.GameInt);
            sqlCommand.Parameters.AddWithValue("@GameHandNumber", hand.GameHandNumber);
            sqlCommand.Parameters.AddWithValue("@Doubler", hand.Doubler);
            sqlCommand.Parameters.AddWithValue("@Result", hand.Result);

            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }


        public void AddPlayer(Player player)
        {
            MySqlConnection connection;
            MySqlCommand sqlCommand;

            connection = GetConnection();
            connection.Open();

            sqlCommand = new MySqlCommand();
            sqlCommand.Connection = connection;

            sqlCommand.CommandText = "INSERT INTO PLAYER VALUES(NULL, @Name)";
            sqlCommand.Parameters.AddWithValue("@Name", player.Name);

            sqlCommand.ExecuteNonQuery();

            connection.Close();

        }
    }
}
