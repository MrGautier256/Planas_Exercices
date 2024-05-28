﻿using Ninject;
using PeopleViewer.Presentation;
using PersonReader.Caching;
using PersonReader.CSV;
using PersonReader.Service;
using System.Reflection.PortableExecutable;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        IKernel Container = new StandardKernel();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ComposeObject();
            Application.Current.MainWindow.Show();
        }

        private void ComposeObject()
        {
            // TODO 3 : C'est désormais l'application qui va créer et choisir le repository  ainsi que le Viewmodel
            // TODO 3-1 : Créer le repository (i.e. instancier ServiceReader)
            //IRepository serviceReader = new ServiceReader();

            // TODO 4-3 : Au lieu d'intancier un ServiceReader, instancier un CSVReader
            // TODO 4-4 : Tester et vérifier qu'une personne supplémentaire est trouvée
            //IRepository csvReader = new CSVReader();

            // TODO 5-3 : Au lieu d'intancier un CSVReader, instancier un CachingReader qui va utiliser un ServiceReader
            // TODO 5-4 : Tester, couper le service web "People.Service". Vérifier qu'il est encore possible de récupérer les personnes encore pendant 30 secondes (durée du cache)
            //IRepository Reader = new CachingReader(serviceReader);
            //PeopleViewModel ViewModel = new PeopleViewModel(Reader);
            //Application.Current.MainWindow = new MainWindow(ViewModel);


            // TODO 8 : Utiliser un container IOC (NInject dans notre exemple)
            // TODO 8-1 : Rajouter le package Nuget "Ninject"
            // TODO 8-2 : Créer un champ dans la classe App avec cette déclaration : IKernel Container = new StandardKernel(); // Ceci créé le container pour l'IOC
            // TODO 8-3 : Commenter le contenu de cette méthode (ComposeObject), et rajouter le code suivant : Application.Current.MainWindow = Container.Get<MainWindow>();
            // TODO 8-4 : Rajouter avant la précédente ligne de code ajoutée, la configuration du container : Container.Bind<IRepository>().To<ServiceReader>(); // Configure le container pour qu'une demande d'un IRepository fournisse un ServiceReader
            // TODO 8-5 : Vérifier que l'application fonctionne toujours correctement
            // TODO 8-6 : Changer le binding du container pour fournir un CSVReader à la place du ServiceReader
            // TODO 8-7 : Configurer le binding pour qu'il utilise "InSingletonScope" (C.F. https://github.com/ninject/Ninject/wiki/Object-Scopes)
            // TODO 8-8 : Vérifier que l'application fonctionne toujours correctement et qu'elle utilise le fichier csv

            Container.Bind<IRepository>().To<CSVReader>().InSingletonScope(); // Configure le container pour qu'une demande d'un IRepository fournisse un ServiceReader
            Application.Current.MainWindow = Container.Get<MainWindow>();
        }
    }
}
