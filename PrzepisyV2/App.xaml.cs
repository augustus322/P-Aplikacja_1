using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrzepisyV2.Domain.Commands;
using PrzepisyV2.Domain.Queries;
using PrzepisyV2.EntityFramework;
using PrzepisyV2.EntityFramework.Commands;
using PrzepisyV2.EntityFramework.Queries;
using PrzepisyV2.Stores;
using PrzepisyV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrzepisyV2
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => 
                {
                    string connectionString = "Data Source=Recipes.db";

                    services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
                    services.AddSingleton<RecipeDbContextFactory>();

                    services.AddSingleton<IGetAllRecipesQuery, GetAllRecipesQuery>();
                    services.AddSingleton<ICreateRecipeCommand, CreateRecipeCommand>();
                    services.AddSingleton<IUpdateRecipeCommand, UpdateRecipeCommand>();
                    services.AddSingleton<IDeleteRecipeCommand, DeleteRecipeCommand>();

                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<RecipeStore>();
                    services.AddSingleton<SelectedRecipeStore>();

                    services.AddTransient<RecipeViewViewModel>(CreateRecipeViewViewModel);
                    services.AddSingleton<MainViewModel>();

                    services.AddSingleton<MainWindow>((services) => new PrzepisyV2.MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    }
                    );
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            var recipeDbContextFactory = _host.Services.GetRequiredService<RecipeDbContextFactory>();
            using (RecipeDbContext context = recipeDbContextFactory.Create()) 
            {
                context.Database.Migrate();
            }

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }

        private RecipeViewViewModel CreateRecipeViewViewModel(IServiceProvider services)
        {
            RecipeViewViewModel recipeviewmodel = new RecipeViewViewModel(
                services.GetRequiredService<RecipeStore>(),
                services.GetRequiredService<SelectedRecipeStore>(),
                services.GetRequiredService<ModalNavigationStore>()
                );

            return recipeviewmodel;
        }
    }
}
