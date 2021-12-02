using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LessonLern
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            //Создаём переменные login и password
            string login = textBoxLogin.Text;
            string password = passBox.Password;

            //Если длина переменной login больше 2 и password больше или равно 3, то идёт подключение к базе
            if (login.Length > 2 && password.Length >= 3)
            {
                //Проверка правильности введённых данных
                using (modessDBEntities3 bd = new modessDBEntities3())
                {
                    //Запрос, где login и password должны совпадать с данными в БД
                    var query = bd.regpass.Where(x => x.login == login && x.password == password).FirstOrDefault();

                    // Если у запроса не значение null, то открывается личный кабинет
                    if (query != null)
                    {
                        MessageBox.Show("Вы вошли в свой личный кабинет!");
                        
                        //Закрытие этого окна и открытие окна личного кабнета
                        LessonLern.Window2 Window = new Window2();
                        this.Close();
                        Window.Show();
                    }
                    
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }
        private void agreedReg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Window = new MainWindow();
            Window.Show();
        }

        //Закрытие этого окна и открытие окна регистрации
        private void gotoReg_Click(object sender, RoutedEventArgs e)
        {
            LessonLern.MainWindow Window = new MainWindow();
            this.Close();
            Window.Show();
        }
    }
}
    