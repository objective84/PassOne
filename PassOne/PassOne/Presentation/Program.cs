using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PassOne.Presentation;
using View = PassOne.Presentation.PassOneView;

namespace PassOne
{
    static class Program
    {
        private static PassOneModel _model;
        private static View _view;
        private static PassOneController _controller;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _model = new PassOneModel();
            _view = new View();
            _controller = new PassOneController();

            _model.View = _view;
            _view.Controller = _controller;
            _controller.Model = _model;
            _controller.ModelState = ModelStates.Login;
            _view.ConnectEventHandlers(_controller);
            Application.Run(_view.LoginForm);
        }
    }
}
