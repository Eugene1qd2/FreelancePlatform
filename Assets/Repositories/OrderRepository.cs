using FreelancePlatform.Assets.Additional_Data;
using FreelancePlatform.Assets.MVVM.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FreelancePlatform.Assets.Repositories
{
    class OrderRepository : RepositoryBase, IOrderRepository
    {
        public ErrorStatus Add(OrderModel order, UserModel user)
        {
            using (var connection = GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.CommandText = "insert into ads(ID_user, Topic, Type, Workplace, Address, Budget, Nonreldate, Lessoncount, Goal, Isaccepted) value(@id_user,@topic,@type, @workplace, @address, @budget, @nonreldate, @lessoncount, @goal, @isaccepted);";
                    command.Parameters.Add("@id_user", MySqlDbType.Int32).Value = user.Id;
                    command.Parameters.Add("@topic", MySqlDbType.VarChar).Value = order.Topic;
                    command.Parameters.Add("@type", MySqlDbType.VarChar).Value = order.Type;
                    command.Parameters.Add("@workplace", MySqlDbType.VarChar).Value = order.WorkPlace;
                    command.Parameters.Add("@address", MySqlDbType.VarChar).Value = order.Address;
                    command.Parameters.Add("@budget", MySqlDbType.Int32).Value = order.Budget;
                    command.Parameters.Add("@nonreldate", MySqlDbType.Date).Value = order.NonrelDate.ToString("yyyy-MM-dd");
                    command.Parameters.Add("@lessoncount", MySqlDbType.Int32).Value = order.LessonCount;
                    command.Parameters.Add("@goal", MySqlDbType.Text).Value = order.Goal;
                    command.Parameters.Add("@isaccepted", MySqlDbType.Bit).Value = false;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                int orderId = -1;
                using (var command = new MySqlCommand())
                {
                    command.CommandText = "SELECT LAST_INSERT_ID() from ads;";
                    command.Connection = connection;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        orderId = Convert.ToInt32(reader.GetValue(0));
                    }
                    reader.Close();
                }

                foreach (var skill in order.OrderSkills)
                {
                    using (var command = new MySqlCommand())
                    {
                        command.CommandText = "insert into ads_skills value(@id_skill,@id_order);";
                        command.Parameters.Add("@id_skill", MySqlDbType.Int32).Value = skill.Id;
                        command.Parameters.Add("@id_order", MySqlDbType.Int32).Value = orderId;
                        command.Connection = connection;
                        command.ExecuteNonQuery();
                    }
                }
            }
            return ErrorStatus.NoError;
        }

        public void Edit(OrderModel order)
        {
            using (var connection = GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.CommandText = "update ads set Topic=@topic, Type=@type, Workplace=@workplace, Address=@address, Budget=@budget, Nonreldate=@nonreldate, Lessoncount=@lessonscount, Goal=@goal, Isaccepted=@isaccpted where ID_ad=@id;";
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = order.Id;
                    command.Parameters.Add("@topic", MySqlDbType.VarChar).Value = order.Topic;
                    command.Parameters.Add("@type", MySqlDbType.VarChar).Value = order.Type;
                    command.Parameters.Add("@workplace", MySqlDbType.VarChar).Value = order.WorkPlace;
                    command.Parameters.Add("@address", MySqlDbType.VarChar).Value = order.Address;
                    command.Parameters.Add("@budget", MySqlDbType.Int32).Value = order.Budget;
                    command.Parameters.Add("@nonreldate", MySqlDbType.Date).Value = order.NonrelDate;
                    command.Parameters.Add("@lessonscount", MySqlDbType.Int32).Value = order.LessonCount;
                    command.Parameters.Add("@goal", MySqlDbType.Text).Value = order.Goal;
                    command.Parameters.Add("@isaccpted", MySqlDbType.Bit).Value = order.IsAccepted ? 1 : 0;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand())
                {
                    command.CommandText = "delete from ads_skills where ID_ad=@id;";
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = order.Id;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }


                foreach (var OrderSkill in order.OrderSkills)
                {
                    using (var command = new MySqlCommand())
                    {
                        command.CommandText = "insert into ads_skills values(@id_skill,@id_ad);";
                        command.Parameters.Add("@id_ad", MySqlDbType.Int32).Value = order.Id;
                        command.Parameters.Add("@id_skill", MySqlDbType.Int32).Value = OrderSkill.Id;
                        command.Connection = connection;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Remove(int id) // мб переделать или сделать каскадное удаление
        {
            using (var connection = GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.CommandText = "delete from ads where ID_ad=@id;";
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand())
                {
                    command.CommandText = "delete from ads_skills where ID_ad=@id;";
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
        }

        public OrderModel GetById(int Id)
        {
            OrderModel order = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from ads where ID_ad=@Id";
                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    order = new OrderModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        Topic = (string)reader.GetValue(2),
                        Type = (string)reader.GetValue(3),
                        WorkPlace = reader.GetValue(4).ToString() ?? string.Empty,
                        Address = reader.GetValue(5).ToString() ?? string.Empty,
                        Budget = Convert.ToInt32(reader.GetValue(6)),
                        NonrelDate = Convert.ToDateTime(reader.GetValue(7)),
                        LessonCount = Convert.ToInt32(reader.GetValue(8) ?? -1),
                        Goal = (string)reader.GetValue(9),
                        IsAccepted = Convert.ToBoolean(reader.GetValue(10))
                    };
                }
            }
            return order;
        }

        public List<OrderModel> GetByUserId(int userId)
        {
            List<OrderModel> orders = new List<OrderModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *,(select count(*) from responses where ID_ad=ads.ID_ad) from ads where ID_user=@userId";
                command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string address = (reader.GetValue(5) ?? string.Empty).ToString();
                    orders.Add(new OrderModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        Topic = (string)reader.GetValue(2),
                        Type = (string)reader.GetValue(3),
                        WorkPlace = (string)reader.GetValue(4),
                        Address = address,
                        Budget = Convert.ToInt32(reader.GetValue(6)),
                        NonrelDate = Convert.ToDateTime(reader.GetValue(7)),
                        LessonCount = Convert.ToInt32(reader.GetValue(8)),
                        Goal = (string)reader.GetValue(9),
                        IsAccepted = Convert.ToBoolean(reader.GetValue(10)),
                        ResponseCount = Convert.ToInt32(reader.GetValue(11)),
                    });
                }
            }
            return orders;
        }

        public List<ResponseModel> GetResponsesById(int orderId)
        {
            List<ResponseModel> responses = new List<ResponseModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from responses where ID_ad=@orderId";
                command.Parameters.Add("@orderId", MySqlDbType.Int32).Value = orderId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    responses.Add(new ResponseModel()
                    {
                        AdId = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        IsAccepted = Convert.ToBoolean(reader.GetValue(2)),
                    });
                }
            }
            responses.ForEach(x => x.UpdateResponse());
            return responses;
        }

        public ObservableCollection<OrderModel> GetAll()
        {
            ObservableCollection<OrderModel> orders = new ObservableCollection<OrderModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from ads limit 50;";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string address = (reader.GetValue(5) ?? string.Empty).ToString();
                    orders.Add(new OrderModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        Topic = (string)reader.GetValue(2),
                        Type = (string)reader.GetValue(3),
                        WorkPlace = (string)reader.GetValue(4),
                        Address = address,
                        Budget = Convert.ToInt32(reader.GetValue(6)),
                        NonrelDate = Convert.ToDateTime(reader.GetValue(7)),
                        LessonCount = Convert.ToInt32(reader.GetValue(8)),
                        Goal = (string)reader.GetValue(9),
                        IsAccepted = Convert.ToBoolean(reader.GetValue(10)),
                    });
                }
            }
            return orders;
        }

        public void AddResponse(OrderModel order, UserModel user)
        {
            using (var connection = GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.CommandText = "insert into responses value(@id_ad,@id_user,@isaccepted);";
                    command.Parameters.Add("@id_user", MySqlDbType.Int32).Value = user.Id;
                    command.Parameters.Add("@id_ad", MySqlDbType.Int32).Value = order.Id;
                    command.Parameters.Add("@isaccepted", MySqlDbType.Bit).Value = false;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ConfirmResponse(OrderModel order, ResponseModel Response)
        {
            using (var connection = GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.CommandText = "update responses set Isaccepted=@isaccepted where ID_ad=@adId and ID_user=@userId;";
                    command.Parameters.Add("@userId", MySqlDbType.Int32).Value = Response.UserId;
                    command.Parameters.Add("@adId", MySqlDbType.Int32).Value = Response.AdId;
                    command.Parameters.Add("@isaccepted", MySqlDbType.Bit).Value = true;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand())
                {
                    command.CommandText = "update ads set Isaccepted=@isaccepted where ID_ad=@adId;";
                    command.Parameters.Add("@adId", MySqlDbType.Int32).Value = Response.AdId;
                    command.Parameters.Add("@isaccepted", MySqlDbType.Bit).Value = true;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
        }

        public ObservableCollection<OrderModel> GetByUsername(string username)
        {
            IUserRepository userRepository = new UserRepository();
            UserModel userModel = userRepository.GetByUsername(username);
            if (userModel != null)
            {
                ObservableCollection<OrderModel> orders = new ObservableCollection<OrderModel>();
                using (var connection = GetConnection())
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"select * from ads where ID_user={userModel.Id} limit 50;";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string address = (reader.GetValue(5) ?? string.Empty).ToString();
                        orders.Add(new OrderModel()
                        {
                            Id = Convert.ToInt32(reader.GetValue(0)),
                            UserId = Convert.ToInt32(reader.GetValue(1)),
                            Topic = (string)reader.GetValue(2),
                            Type = (string)reader.GetValue(3),
                            WorkPlace = (string)reader.GetValue(4),
                            Address = address,
                            Budget = Convert.ToInt32(reader.GetValue(6)),
                            NonrelDate = Convert.ToDateTime(reader.GetValue(7)),
                            LessonCount = Convert.ToInt32(reader.GetValue(8)),
                            Goal = (string)reader.GetValue(9),
                            IsAccepted = Convert.ToBoolean(reader.GetValue(10)),
                        });
                    }
                }
                return orders;
            }
            else
            {
                return new ObservableCollection<OrderModel>();
            }
        }

        public ObservableCollection<OrderModel> GetBySkills(string[] skills)
        {
            IOrderSkillRepository orderSkillRepository = new OrderSkillRepository();
            ObservableCollection<OrderModel> orders = new ObservableCollection<OrderModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"select * from ads limit 50;";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string address = (reader.GetValue(5) ?? string.Empty).ToString();
                    OrderModel model = new OrderModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        Topic = (string)reader.GetValue(2),
                        Type = (string)reader.GetValue(3),
                        WorkPlace = (string)reader.GetValue(4),
                        Address = address,
                        Budget = Convert.ToInt32(reader.GetValue(6)),
                        NonrelDate = Convert.ToDateTime(reader.GetValue(7)),
                        LessonCount = Convert.ToInt32(reader.GetValue(8)),
                        Goal = (string)reader.GetValue(9),
                        IsAccepted = Convert.ToBoolean(reader.GetValue(10)),
                    };
                    model.OrderSkills = orderSkillRepository.GetByOrderId(model.Id);
                    bool brk = true;
                    foreach (string skill in skills)
                    {
                        if (model.OrderSkills.Count(x => x.Skill.Contains(skill))<=0)
                        {
                            brk=false;
                            break;
                        }
                    }
                    if (brk)
                    {
                        orders.Add(model);
                    }
                }
            }
            return orders;
        }

        public ObservableCollection<OrderModel> GetByTopic(string search)
        {
            ObservableCollection<OrderModel> orders = new ObservableCollection<OrderModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = $"select * from ads where Topic Like '%{search}%' limit 50;";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string address = (reader.GetValue(5) ?? string.Empty).ToString();
                    orders.Add(new OrderModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        Topic = (string)reader.GetValue(2),
                        Type = (string)reader.GetValue(3),
                        WorkPlace = (string)reader.GetValue(4),
                        Address = address,
                        Budget = Convert.ToInt32(reader.GetValue(6)),
                        NonrelDate = Convert.ToDateTime(reader.GetValue(7)),
                        LessonCount = Convert.ToInt32(reader.GetValue(8)),
                        Goal = (string)reader.GetValue(9),
                        IsAccepted = Convert.ToBoolean(reader.GetValue(10)),
                    });
                }
            }
            return orders;
        }
    }
}
