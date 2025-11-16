using System;
using System.Windows.Forms;
using Computer_Parts_Store.Forms;
using Computer_Parts_Store.Data;

namespace Computer_Parts_Store
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Додаємо ініціалізацію бази даних перед запуском форми
            InitializeDatabase();

            Application.Run(new MainForm());
        }

        private static void InitializeDatabase()
        {
            try
            {
                Console.WriteLine("Запуск ініціалізації бази даних...");

                // Викликаємо ваш існуючий ініціалізатор
                DatabaseInitializer.InitializeDatabase();

                // Опціонально: показуємо інформацію про базу
                DatabaseInitializer.DisplayDatabaseInfo();

                Console.WriteLine("База даних успішно ініціалізована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Критична помилка ініціалізації бази даних:\n{ex.Message}\n\n" +
                    "Додаток не може продовжити роботу. Будь ласка, перевірте налаштування підключення до бази даних.",
                    "Помилка бази даних",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Завершуємо роботу додатку при критичній помилці БД
                Environment.Exit(1);
            }
        }
    }
}