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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LessonLern
{
    public partial class MainWindow : Window
    {   
        modessDBEntities3 dataBase = new modessDBEntities3();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void agreedReg_Click(object sender, RoutedEventArgs e)
        {   
            //Переменные login и password
            string login = mailBox.Text;
            string password = passBox.Password;
            if (login.Length > 2 && password.Length > 2)
            {   
                //Если пароли совпадают
                if (passBox.Password == repassBox.Password)
                {   
                    //Использование БД для создания нового пользователя
                    using (modessDBEntities3 dataBase = new modessDBEntities3())
                    {
                        //Запрос к БД
                        var query = dataBase.regpass.Where(x => x.login.Equals(mailBox.Text)).FirstOrDefault();
                        //Если login в БД нет, то он вносится в БД
                        {
                            //Добавление нового пользователя
                            if (query == null)
                            {
                                dataBase.regpass.Add(new regpass
                                {
                                    login = mailBox.Text,
                                    password = passBox.Password
                                });

                                MessageBox.Show("Вы успешно зарегистрировались!");
                                
                                //Сохраняем изменения
                                dataBase.SaveChanges();
                                
                                LessonLern.Window1 Window = new Window1();
                                
                                this.Close();
                                Window.Show();
                            }
                            else
                            {
                                MessageBox.Show("Данный логин занят!");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
            }
            else
            {
                MessageBox.Show("Ненадёжный логин или пароль!");
            }
        }
    }
}
