using Newtonsoft.Json;

namespace lstwork;

interface CRUD
{
    void Create();
    void Read();
    void Upd();
    void Del();
    void SearchByArrt();
}

public class User_common
{
    public string username;
    public string password;
    public int id;
    public int role;
}
public class User_managment : CRUD
{
    static private string full_path = "C:\\Users\\mansu\\RiderProjects\\lpw\\lstwork\\My_directory\\Users.json";
    private List<User_common> usr_Table = new List<User_common>();
    
    public void Create()
    {
        Console.Clear();
        User_common new_user = new User_common();
        Console.Write("Enter users name: ");
        new_user.username = Console.ReadLine();
        Console.Write("Enter users password: ");
        new_user.password = Console.ReadLine();
        Console.Write("Enter users id: ");
        new_user.id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter users role: ");
        new_user.role = Convert.ToInt32(Console.ReadLine());
        usr_Table.Add(new_user);
        string res = JsonConvert.SerializeObject(usr_Table);
        if (File.Exists(full_path))
        {
            File.AppendAllText(full_path, '\n'+res);
        }
        else
        {
            File.WriteAllText(full_path, res);
        }
        Console.Write("Press any key to exit: ");
        ConsoleKeyInfo exit_key = Console.ReadKey();
        switch (exit_key.Key)
        {
            default:
                return;
        }
    }
    public void Read()
    {
        Console.Clear();
        string read_all = File.ReadAllText(full_path);
        List<User_common> result = JsonConvert.DeserializeObject<List<User_common>>(read_all);
        Console.WriteLine("Login                        Password                        ID                      ROLE");
        foreach(User_common r in result)
        {
            Console.WriteLine($"{r.username}\t\t\t{r.password}\t\t\t{r.id}\t\t\t{r.role}");
        }
        Console.Write("Press any key to exit: ");
        ConsoleKeyInfo exit_key = Console.ReadKey();
        switch(exit_key.Key)
        {
            default:
                return;
        }
    }
    public void Upd()
    {
        string read_all = File.ReadAllText(full_path);
        List<User_common> result = JsonConvert.DeserializeObject<List<User_common>>(read_all);
        User_common editing = result.FirstOrDefault();
        if (editing != null)
        {
            editing.username = Console.ReadLine();
            editing.password = Console.ReadLine();
            editing.id = Convert.ToInt32(Console.ReadLine());
            editing.role = Convert.ToInt32(Console.ReadLine());
            result[0] = editing;
            string res = JsonConvert.SerializeObject(result);
            File.WriteAllText(full_path, res);
            Console.Write("Press any key to exit: ");
            ConsoleKeyInfo exit_key = Console.ReadKey();
            switch(exit_key.Key)
            {
                default:
                    return;
            }
        }
    }
    public void Del()
    {
        string read_all = File.ReadAllText(full_path);
        List<User_common> result = JsonConvert.DeserializeObject<List<User_common>>(read_all);
        Console.Write("Enter name of user to delete it: ");
        string usr_del = Console.ReadLine();
        foreach(User_common i in result)
        {
            if (usr_del == i.username)
            {
                result.Remove(i);
                break;
            }
            else
            {
                Console.WriteLine("User not found!\n\n");
                break;
            }
        }
        string res = JsonConvert.SerializeObject(result);
        File.WriteAllText(full_path, res);
        Console.Write("Press any key to exit: ");
            ConsoleKeyInfo exit_key = Console.ReadKey();
            switch(exit_key.Key)
            {
                default:
                    return;
            }
    }
    public void SearchByArrt()
    {
        string read_all = File.ReadAllText(full_path);
        List<User_common> result = JsonConvert.DeserializeObject<List<User_common>>(read_all);
        Console.Write("1. Search by name\n2. Search by password\n3. Search by id\n4. Search by role\n");
        Console.Write(": ");
        int act = Convert.ToInt32(Console.ReadLine());
        switch (act)
        {
            case 1:
                Console.Write("enter a name of person: ");
                string name_attr = Console.ReadLine();
                foreach (User_common M in result)
                {
                    if (name_attr.Equals(M.username))
                    {
                        Console.Write($"{M.username}\n\n");
                        break;
                    }
                    else
                    {
                        Console.Write("Not found!\n\n");
                        Thread.Sleep(2000);
                        return;
                    }
                }
                break;
            case 2:
                Console.Write("enter a password of person: ");
                string pas_attr = Console.ReadLine();
                foreach (User_common M in result)
                {
                    if (pas_attr.Equals(M.password))
                    {
                        Console.Write($"{M.password}\n\n");
                        break;
                    }
                    else
                    {
                        Console.Write("Not found!\n\n");
                        Thread.Sleep(2000);
                        return;
                    }
                }
                break;
            case 3:
                Console.Write("enter an user id: ");
                int id_attr = Convert.ToInt32(Console.ReadLine());
                foreach (User_common M in result)
                {
                    if (id_attr.Equals(M.id))
                    {
                        Console.Write($"{M.username}\n\n");
                        break;
                    }
                    else
                    {
                        Console.Write("Not found!\n\n");
                        Thread.Sleep(2000);
                        return;
                    }
                }
                break;
            case 4:
                Console.Write("enter an user role: ");
                int role_attr = Convert.ToInt32(Console.ReadLine());
                foreach (User_common M in result)
                {
                    if (role_attr.Equals(M.role))
                    {
                        Console.Write($"{M.role}\n\n");
                        break;
                    }
                    else
                    {
                        Console.Write("Not found!\n\n");
                        Thread.Sleep(2000);
                        return;
                    }
                }
                break;
            default:
                Console.Write("Try again!\n\n");
                Thread.Sleep(2000);
                return;
        }
    }
    
}


enum Roles_id
{
    Admin = 1,
    pmaster = 2,
    manager = 3,
    wmanager = 4,
    acc = 5
}
public class Warehouse
{
    public string username = string.Empty;
    public string password = String.Empty;
    public int id;
    public int role;
    public Warehouse(string uname , string passwd, int id_i, int role_new)
    {
        this.username = uname;
        this.password = passwd;
        this.id = id_i;
        this.role = role_new;
    }
}



public class Admin : Warehouse
{
    
    string username = String.Empty;
    string password = String.Empty;
    int id = 0;
    int role;
    public Admin(string rname, string p, int ident, int rl) : base("admin", "1234", 1, (int)Roles_id.Admin)
    {
        this.username = rname;
        this.password = p;
        this.id = ident;
        this.role = rl;
    }
    private string Welcome_message()
    {
        Console.Clear();
        string say = $"Logged as {this.username}. Now you can manage users\n\n";
        return say;
    }

    public void ManageUsers()
    {
        Welcome_message();
        ConsoleKeyInfo Bysteps;
        int pos = 1;
        Console.SetCursorPosition(0, pos);
        string read_text = File.ReadAllText("C:\\Users\\mansu\\RiderProjects\\lpw\\lstwork\\My_directory\\Users.json");
        List<User_common> all = JsonConvert.DeserializeObject<List<User_common>>(read_text);
        Console.Write("\n  1. Create user\n  2. Read file with users\n  3. Update information\n  4. Remove user\n  5. Search by attributes\n  6. Write changes\n");
         foreach(User_common i in all)
         {
             Console.WriteLine($"{i.username}\t\t\t{i.password}\t\t\t{i.id}\t\t\t{i.role}");
            }
        while (true)
        {
            Bysteps = Console.ReadKey();
            switch (Bysteps.Key)
            {
                case ConsoleKey.UpArrow:
                    pos--;
                    break;
                case ConsoleKey.DownArrow:
                    pos++;
                    break;
                case ConsoleKey.Enter:
                    if (pos == 1)
                    {
                        User_managment new_inc = new User_managment();
                        new_inc.Create();
                    }
                    else if (pos == 2)
                    {
                        User_managment new_inc = new User_managment();
                        new_inc.Read();
                    }
                    else if (pos == 3)
                    {
                        User_managment new_inc = new User_managment();
                        new_inc.Upd();
                    }
                    else if (pos == 4)
                    {
                        User_managment new_inc = new User_managment();
                        new_inc.Del();
                    }
                    else if (pos == 5)
                    {
                        User_managment new_inc = new User_managment();
                        new_inc.SearchByArrt();
                    }
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
            Console.Clear();
            Console.Write("\n  1. Create user\n  2. Read file with users\n  3. Update information\n  4. Remove user\n  5. Search by attributes\n  6. Write changes\n");
            foreach(User_common i in all)
                {
            Console.WriteLine($"{i.username}\t\t\t{i.password}\t\t\t{i.id}\t\t\t{i.role}");
                }
            Console.SetCursorPosition(0, pos);
            Console.WriteLine(">");
        }
    }

}


static class Login
{
    static bool Check(string login, string password, int role)
    {
        Admin Main_user = new Admin("admin", "1234", 1, (int)Roles_id.Admin);
        if (login.Equals(Main_user.username))
        {
            if (password.Equals(Main_user.password))
            {
                if (role == Main_user.role)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect role!\n\n");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Incorrect password!\n");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Incorrect username!\n");
            return false;
        }
    }
    public static int login_daemon()
    {
        Console.Clear();
        int next = 14;
        ConsoleKeyInfo login_key, password_key;
        int isSuccessful = 1;
        string username = String.Empty;
        string password = String.Empty;
        Console.Write("Enter login: ");
        Console.SetCursorPosition(next,0);
        for (int i = 0; i < 1000; i++)
        {
            login_key = Console.ReadKey(true);
            username += login_key.KeyChar;
            Console.Write("*");
            next++;
            if (login_key.Key == ConsoleKey.Enter)
            {
                username = username.Remove(username.Length - 1);
                Console.Write('\n');
                break;
            }

            else if (login_key.Key == ConsoleKey.Backspace)
            {
                next--;
                Console.SetCursorPosition(next, 0);
            }
            
            else if (username.Length == 0)
            {
                Console.WriteLine("   ");
                break;  
            }

            if (next <= 14)
            {
                next = 14;
            }
        }
        Console.Write("Enter password: ");
        for (int m = 0; m < 1000; m++)
        {
            password_key = Console.ReadKey(true);
            password += password_key.KeyChar;
            Console.Write("*");
            if (password_key.Key == ConsoleKey.Enter)
            {
                password = password.Remove(password.Length - 1);
                Console.Write('\n');
                break;
            }

            if (password.Length == 0)
            {
                Console.Write("  ");
                break;  
            }
        }
        Console.Write("Enter your role: ");
        try
        {

            int role = Convert.ToInt32(Console.ReadLine());
            bool result = Check(username, password, role);
            if (result)
            {
                Console.WriteLine($"Welcome! {username}\n\n");
                Admin newLogin = new Admin("admin", "1234", 1, (int)Roles_id.Admin);
                newLogin.ManageUsers();
            }
            else
            {
                Console.WriteLine("Incorrect credentials! Try again!\n\n\n");
                login_daemon();
            }
        }
        catch (Exception)
        {
            Console.Write("Wrong format\n");
            Console.Write('\n');
        }
        return isSuccessful;
    }
}