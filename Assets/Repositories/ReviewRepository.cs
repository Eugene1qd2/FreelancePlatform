using FreelancePlatform.Assets.Additional_Data;
using FreelancePlatform.Assets.MVVM.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.Repositories
{
    class ReviewRepository : RepositoryBase, IReviewRepository
    {
        public ErrorStatus Add(ReviewModel review)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();

                try
                {
                    command.CommandText = "insert into reviews(ID_profile,ID_user,Senddate,Text,Rate) value(@id_profile,@id_user,@senddate,@text,@rate)";
                    command.Parameters.Add("@id_profile", MySqlDbType.Int32).Value = review.Resiever.Id;
                    command.Parameters.Add("@id_user", MySqlDbType.Int32).Value = review.Sender.Id;
                    command.Parameters.Add("@senddate", MySqlDbType.DateTime).Value = review.Senddate;
                    command.Parameters.Add("@text", MySqlDbType.Text).Value = review.Text;
                    command.Parameters.Add("@rate", MySqlDbType.Int32).Value = review.Rate;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return ErrorStatus.RegistrationError;
                }
            }
            return ErrorStatus.NoError;
        }

        public void Edit(ReviewModel review)
        {
            throw new NotImplementedException();
        }

        public ReviewModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<ReviewModel> GetByUserId(int userId)
        {
            ObservableCollection<ReviewModel> reviews = new ObservableCollection<ReviewModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from reviews where ID_profile=@userId";
                command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
                MySqlDataReader reader = command.ExecuteReader();
                IUserRepository userRepository = new UserRepository();
                while (reader.Read())
                {
                    reviews.Add(new ReviewModel(userRepository.GetById(Convert.ToInt32(reader.GetValue(1))), Convert.ToString(reader.GetValue(3)), Convert.ToInt32(reader.GetValue(4)), Convert.ToDateTime(reader.GetValue(2)), userRepository.GetById(userId)));
                }
            }
            return reviews;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
