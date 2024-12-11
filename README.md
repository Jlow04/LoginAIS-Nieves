---

# LoginAIS-Nieves

## Features

### Register Form
1. Detects if the username and password are already taken.
2. Provides the option to hide/show the password.
3. Detects password strength (strong or weak).
4. Encrypts passwords using Visual Studio encryption.

### Login Form
1. Verifies if the username and password are correct.
2. Includes a hide/show password feature.
3. Requires an access code for old users.
4. Allows 3 login attempts before locking the account.
5. Provides a link for password/username/code recovery.

### Homepage Form (User Dashboard)
1. Displays a welcome label with the user's username.
2. Generates a 4-digit randomized access code every login.
3. Requires the user to copy the code before logging out.
4. Includes a menustrip with an idle timeout feature.

### Admin Form
1. Displays the user database in a `DataGridView` (DGV).
2. **Refresh Button:** Refreshes the DGV.
3. **Add User Button:** Allows the admin to add a new user.
4. **Edit User Button:** Enables editing of user information.
5. **Delete User Button:** Deletes a selected user.
6. **Reset Button:** Resets the login attempts of a user.
7. **Status Button:** Edits a user's account status:
   - `Pending:` Newly created accounts unable to log in.
   - `Active:` Approved accounts able to log in.
   - `Inactive:` Deactivates accounts due to exceeded attempts or manual admin action.
8. **Role Button:** Switches a user's role between Admin and User.
9. **Search Button:** Highlights a user's row in the DGV by entering the username in a textbox.
10. **Idle Timeout ComboBox:** Allows the admin to set an idle timeout for a selected user in the DGV.
11. **Backup and Restore Buttons:** Facilitates database backups and restores using `MySqlBackup.NET`. Includes a ComboBox to select from previous backups.

### Log Action Table (MySQL)
- Records all user and admin actions with corresponding date and time.

---

## Steps to Run the Project

1. **Create the Database:**
   - Server: `localhost`  
   - Database: `loginDB`  
   - User ID: `root`  
   - Password: `root`

2. **Setup the Database:**
   - Copy the MySQL code from the `loginIAS.sql` file and execute it in your MySQL query editor.

3. **Open the Project:**
   - Launch `LoginAIS-Nieves.sln` in Visual Studio.

4. **Install Dependencies:**
   - Open **Manage NuGet Packages for Solution** and install:
     - `MySql.Data`
     - `BouncyCastle.Cryptography`
     - `MySqlBackup.NET`
   - If any packages are missing, right-click the solution in Solution Explorer and click **Restore NuGet Packages**.

5. **Edit the path file in adminform:**
   - creata a folder for backups of the sql files and copy the path of that folder and paste it in the code:
   - private string backupDirectory = @"example: C:\Users\jelo\Desktop\DBBackups";
     

7. **Run the Project:**
   - Start the application and enjoy!

8. **Debugging:**
   - If there are errors in the code, use **GPT** or **Contact the owner** to assist with troubleshooting.

---

