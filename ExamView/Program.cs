using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.BusinessLogics;
using ExamDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;


namespace ExamView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IFirstStorage, FirstStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISecondStorage, SecondStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<FirstLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<SecondLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
