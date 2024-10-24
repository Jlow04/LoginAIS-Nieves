
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginAIS_Nieves
{
    public class dbconnect
    {
        public MySqlConnection connection { get; set; }
        public string server { get; set; }
        public string database { get; set; }
        public string uid { get; set; }
        public string password { get; set; }
        public string connectionString { get; set; }

        public DataTable dataTable { get; set; }
        public MySqlCommand command { get; set; }
        public MySqlDataAdapter adapter { get; set; }

        public dbconnect()
        {
            connection = new MySqlConnection();
            server = "localhost";
            database = "loginDB";
            uid = "root";
            password = "root";
            command = new MySqlCommand();
            adapter = new MySqlDataAdapter();
            dataTable = new DataTable();
        }

        public void OpenDB()
        {
            try
            {
                connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public void CloseDB()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Method to fetch all users for displaying in DataGridView
        public DataTable GetUsers()
        {
            OpenDB();
            string sql = "SELECT id, username, password, login_attempts, access_code, status, role FROM users";
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            CloseDB();
            return dt;
        }

        public DataTable GetUserAttemps(string username)
        {
            DataTable dataTable = new DataTable();

            try
            {
                OpenDB();
                string query = "SELECT * FROM users WHERE username = @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseDB();
            }

            return dataTable;
        }

        public void UpdateLoginAttempts(string username, int attempts)
        {
            try
            {
                OpenDB();
                string query = "UPDATE users SET login_attempts = @attempts WHERE username = @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@attempts", attempts);
                command.Parameters.AddWithValue("@username", username);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseDB();
            }
        }

        public DataTable Login()
        {
            OpenDB();
            string sql = "SELECT id, username, password, access_code FROM users";
            dataTable = new DataTable();
            command = new MySqlCommand(sql, connection);
            dataTable.Load(command.ExecuteReader());
            CloseDB();
            return dataTable;

        }

        // Method to update user information (for Admin Form)
        public void UpdateUser(int id, string username, string password)
        {
            OpenDB();
            string sql = "UPDATE users SET username = @username, password = @password WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            CloseDB();
        }



        // Method to update the access code
        public void UpdateAccessCode(string username, string accessCode)
        {
            try
            {
                OpenDB();  // Open the database connection

                string query = "UPDATE users SET access_code = @accesscode WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@accesscode", accessCode);

                cmd.ExecuteNonQuery();  // Execute the query
                CloseDB();  // Close the database connection
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error updating access code: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Method to delete a user from the database (for Admin Form)
        public void DeleteUser(int id)
        {
            OpenDB();
            string sql = "DELETE FROM users WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            CloseDB();
        }

        public void UpdateUserStatus(int id, string newStatus)
        {
            try
            {
                OpenDB();
                string query = "UPDATE users SET status = @status WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", newStatus);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseDB();
            }
        }

        //  db.UpdateUserRole(id, newRole);
        public void UpdateUserRole(int id, string newRole)
        {
            try
            {
                OpenDB();
                string query = "UPDATE users SET role = @role WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@role", newRole);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseDB();
            }
        }

        public void LogAction(string username, string action, string details)
        {
            try
            {
                OpenDB();
                string query = "INSERT INTO action_logs (username, action, details, timestamp) VALUES (@username, @action, @details, @timestamp)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@action", action);
                command.Parameters.AddWithValue("@details", details);
                command.Parameters.AddWithValue("@timestamp", DateTime.Now);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseDB();
            }
        }


    }
}