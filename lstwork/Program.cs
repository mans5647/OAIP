namespace lstwork
{
    class Main_prog
    {
        static void Main()
        {
            string path = Directory.GetCurrentDirectory();
            string full_path = path + "\\My_directory";
            Directory.CreateDirectory(full_path);
            int i = Login.login_daemon();
        }
    }
}

